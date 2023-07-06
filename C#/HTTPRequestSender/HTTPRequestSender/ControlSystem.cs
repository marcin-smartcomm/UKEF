using System;
using Crestron.SimplSharp;                          	// For Basic SIMPL# Classes
using Crestron.SimplSharpPro;                       	// For Basic SIMPL#Pro classes
using Crestron.SimplSharpPro.CrestronThread;        	// For Threading
using Crestron.SimplSharpPro.Diagnostics;		    	// For System Monitor Access
using Crestron.SimplSharpPro.DeviceSupport;             // For Generic Device Support
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Crestron.SimplSharpPro.DM;
using Crestron.SimplSharpPro.EthernetCommunication;
using Crestron.SimplSharp.CrestronSockets;

namespace HTTPRequestSender
{
    public class ControlSystem : CrestronControlSystem
    {
        VirtualControlEISCClient _eISCServer;

        public ControlSystem()
            : base()
        {
            try
            {
                Thread.MaxNumberOfUserThreads = 20;

                //Subscribe to the controller events (System, Program, and Ethernet)
                CrestronEnvironment.SystemEventHandler += new SystemEventHandler(_ControllerSystemEventHandler);
                CrestronEnvironment.ProgramStatusEventHandler += new ProgramStatusEventHandler(_ControllerProgramEventHandler);
                CrestronEnvironment.EthernetEventHandler += new EthernetEventHandler(_ControllerEthernetEventHandler);
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error in the constructor: {0}", e.Message);
            }
        }

        /// <summary>
        /// InitializeSystem - this method gets called after the constructor 
        /// has finished. 
        /// 
        /// Use InitializeSystem to:
        /// * Start threads
        /// * Configure ports, such as serial and verisports
        /// * Start and initialize socket connections
        /// Send initial device configurations
        /// 
        /// Please be aware that InitializeSystem needs to exit quickly also; 
        /// if it doesn't exit in time, the SIMPL#Pro program will exit.
        /// </summary>
        public override void InitializeSystem()
        {
            try
            {
                ConsoleLogger.Start(55556);

                _eISCServer = new VirtualControlEISCClient(0x20, "1", this);
                if (_eISCServer.Register() != eDeviceRegistrationUnRegistrationResponse.Success)
                {
                    ConsoleLogger.WriteLine("Failed To Register EISCC Server");
                }
                else
                {
                    _eISCServer.SigChange += _eISCServer_SigChange;
                    _eISCServer.OnlineStatusChange += _eISCServer_OnlineStatusChange;
                }
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error in InitializeSystem: {0}", e.Message);
            }
        }

        private void _eISCServer_OnlineStatusChange(GenericBase currentDevice, OnlineOfflineEventArgs args)
        {
            ConsoleLogger.WriteLine("EISCC Client Connected !");
        }

        private void _eISCServer_SigChange(Crestron.SimplSharpPro.DeviceSupport.BasicTriList currentDevice, SigEventArgs args)
        {
            switch (args.Sig.Type)
            {
                case eSigType.Bool:
                    if (args.Sig.Number == 1)
                        if (args.Sig.BoolValue == true)
                            ChangeUSBStateRequest("False"); //Disable USB Aduio
                    if (args.Sig.Number == 2)
                        if (args.Sig.BoolValue == true)
                            ChangeUSBStateRequest("True"); //Enable USB Aduio
                    break;
            }
        }

        public void ChangeUSBStateRequest(string newState)
        {
            SendLogin();
            SendCommand(newState);
        }

        void SendLogin()
        {
            Task.Run(() =>
            {
                try
                {
                    ConsoleLogger.WriteLine("Trying to send a command to Poly");
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://10.0.5.12/rest/session");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.CookieContainer = new CookieContainer();
                    httpWebRequest.CookieContainer.Add(new Cookie("cookies.txt", ""));
                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = "{\"user\": \"admin\",\"password\": \"treasury\"}";

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        result = result.Replace('{', '(');
                        result = result.Replace('}', ')');
                        ConsoleLogger.WriteLine("Received Response from Poly: " + result.ToString());
                    }
                    ConsoleLogger.WriteLine("Command sent");
                }
                catch (Exception ex)
                {
                    ConsoleLogger.WriteLine("Problem Sending Login: " + ex.Message);
                }
            });
        }

        void SendCommand(string command)
        {
            Task.Run(() =>
            {
                try
                {
                    ConsoleLogger.WriteLine("Trying to send a command to Poly");
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://10.0.5.12/rest/config");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.CookieContainer = new CookieContainer();
                    httpWebRequest.CookieContainer.Add(new Cookie("cookies.txt", ""));
                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = "{\"vars\":[{\"name\":\"audio.qualityprocess.enableusbaudio\",\"value\":\" " + command + " \"}]}";

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        result = result.Replace('{', '(');
                        result = result.Replace('}', ')');
                        ConsoleLogger.WriteLine("Received Response from Poly: " + result.ToString());
                    }
                    ConsoleLogger.WriteLine("Command sent");
                }
                catch (Exception ex)
                {
                    ConsoleLogger.WriteLine("Problem Sending Login: " + ex.Message);
                }
            });
        }

        /// <summary>
        /// Event Handler for Ethernet events: Link Up and Link Down. 
        /// Use these events to close / re-open sockets, etc. 
        /// </summary>
        /// <param name="ethernetEventArgs">This parameter holds the values 
        /// such as whether it's a Link Up or Link Down event. It will also indicate 
        /// wich Ethernet adapter this event belongs to.
        /// </param>
        void _ControllerEthernetEventHandler(EthernetEventArgs ethernetEventArgs)
        {
            switch (ethernetEventArgs.EthernetEventType)
            {//Determine the event type Link Up or Link Down
                case (eEthernetEventType.LinkDown):
                    //Next need to determine which adapter the event is for. 
                    //LAN is the adapter is the port connected to external networks.
                    if (ethernetEventArgs.EthernetAdapter == EthernetAdapterType.EthernetLANAdapter)
                    {
                        //
                    }
                    break;
                case (eEthernetEventType.LinkUp):
                    if (ethernetEventArgs.EthernetAdapter == EthernetAdapterType.EthernetLANAdapter)
                    {

                    }
                    break;
            }
        }

        /// <summary>
        /// Event Handler for Programmatic events: Stop, Pause, Resume.
        /// Use this event to clean up when a program is stopping, pausing, and resuming.
        /// This event only applies to this SIMPL#Pro program, it doesn't receive events
        /// for other programs stopping
        /// </summary>
        /// <param name="programStatusEventType"></param>
        void _ControllerProgramEventHandler(eProgramStatusEventType programStatusEventType)
        {
            switch (programStatusEventType)
            {
                case (eProgramStatusEventType.Paused):
                    //The program has been paused.  Pause all user threads/timers as needed.
                    break;
                case (eProgramStatusEventType.Resumed):
                    //The program has been resumed. Resume all the user threads/timers as needed.
                    break;
                case (eProgramStatusEventType.Stopping):
                    //The program has been stopped.
                    //Close all threads. 
                    //Shutdown all Client/Servers in the system.
                    //General cleanup.
                    //Unsubscribe to all System Monitor events
                    break;
            }

        }

        /// <summary>
        /// Event Handler for system events, Disk Inserted/Ejected, and Reboot
        /// Use this event to clean up when someone types in reboot, or when your SD /USB
        /// removable media is ejected / re-inserted.
        /// </summary>
        /// <param name="systemEventType"></param>
        void _ControllerSystemEventHandler(eSystemEventType systemEventType)
        {
            switch (systemEventType)
            {
                case (eSystemEventType.DiskInserted):
                    //Removable media was detected on the system
                    break;
                case (eSystemEventType.DiskRemoved):
                    //Removable media was detached from the system
                    break;
                case (eSystemEventType.Rebooting):
                    //The system is rebooting. 
                    //Very limited time to preform clean up and save any settings to disk.
                    break;
            }

        }
    }
}