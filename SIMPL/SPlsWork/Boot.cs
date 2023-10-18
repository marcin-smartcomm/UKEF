using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_BOOT
{
    public class UserModuleClass_BOOT : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalOutput SYSTEM_INIT;
        Crestron.Logos.SplusObjects.DigitalOutput DIGITAL_1;
        public override object FunctionMain (  object __obj__ ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusFunctionMainStartCode();
                
                __context__.SourceCodeLine = 25;
                WaitForInitializationComplete ( ) ; 
                __context__.SourceCodeLine = 26;
                DIGITAL_1  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 27;
                CreateWait ( "__SPLS_TMPVAR__WAITLABEL_3__" , 20 , __SPLS_TMPVAR__WAITLABEL_3___Callback ) ;
                __context__.SourceCodeLine = 32;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.LFIRSTBOOT != 1447))  ) ) 
                    { 
                    __context__.SourceCodeLine = 33;
                    _SplusNVRAM.LFIRSTBOOT = (uint) ( 1447 ) ; 
                    __context__.SourceCodeLine = 34;
                    _SplusNVRAM.LREBOOTS = (uint) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 37;
                _SplusNVRAM.LREBOOTS = (uint) ( (_SplusNVRAM.LREBOOTS + 1) ) ; 
                __context__.SourceCodeLine = 38;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.LREBOOTS == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 39;
                    GenerateUserError ( "System has been rebooted: {0:d} time\r\n", (int)_SplusNVRAM.LREBOOTS) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 42;
                    GenerateUserError ( "System has been rebooted: {0:d} times\r\n", (int)_SplusNVRAM.LREBOOTS) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            return __obj__;
            }
            
        public void __SPLS_TMPVAR__WAITLABEL_3___CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 28;
            Functions.Pulse ( 100, SYSTEM_INIT ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        SYSTEM_INIT = new Crestron.Logos.SplusObjects.DigitalOutput( SYSTEM_INIT__DigitalOutput__, this );
        m_DigitalOutputList.Add( SYSTEM_INIT__DigitalOutput__, SYSTEM_INIT );
        
        DIGITAL_1 = new Crestron.Logos.SplusObjects.DigitalOutput( DIGITAL_1__DigitalOutput__, this );
        m_DigitalOutputList.Add( DIGITAL_1__DigitalOutput__, DIGITAL_1 );
        
        __SPLS_TMPVAR__WAITLABEL_3___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_3___CallbackFn );
        
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_BOOT ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    private WaitFunction __SPLS_TMPVAR__WAITLABEL_3___Callback;
    
    
    const uint SYSTEM_INIT__DigitalOutput__ = 0;
    const uint DIGITAL_1__DigitalOutput__ = 1;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        [SplusStructAttribute(0, false, true)]
            public uint LREBOOTS = 0;
            [SplusStructAttribute(1, false, true)]
            public uint LFIRSTBOOT = 0;
            
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
