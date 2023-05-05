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

namespace UserModule_MND17_SONY_FWL_VOLUME_BY_ANALOG_V1
{
    public class UserModuleClass_MND17_SONY_FWL_VOLUME_BY_ANALOG_V1 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.AnalogInput VOL_LEVEL;
        Crestron.Logos.SplusObjects.DigitalInput MUTE;
        Crestron.Logos.SplusObjects.StringOutput TX;
        Crestron.Logos.SplusObjects.StringInput RX;
        private void SET_VOLUME_LEVEL (  SplusExecutionContext __context__, ushort VOL_LEVEL ) 
            { 
            
            __context__.SourceCodeLine = 64;
            MakeString ( TX , "*SCVOLU0000000000000{0:d3}\u000A", (short)VOL_LEVEL) ; 
            
            }
            
        object VOL_LEVEL_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 73;
                _SplusNVRAM.VOLUME_LEVEL = (ushort) ( VOL_LEVEL  .UshortValue ) ; 
                __context__.SourceCodeLine = 74;
                SET_VOLUME_LEVEL (  __context__ , (ushort)( _SplusNVRAM.VOLUME_LEVEL )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object MUTE_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 81;
            SET_VOLUME_LEVEL (  __context__ , (ushort)( _SplusNVRAM.VOLUME_LEVEL )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object MUTE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 86;
        SET_VOLUME_LEVEL (  __context__ , (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    MUTE = new Crestron.Logos.SplusObjects.DigitalInput( MUTE__DigitalInput__, this );
    m_DigitalInputList.Add( MUTE__DigitalInput__, MUTE );
    
    VOL_LEVEL = new Crestron.Logos.SplusObjects.AnalogInput( VOL_LEVEL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VOL_LEVEL__AnalogSerialInput__, VOL_LEVEL );
    
    RX = new Crestron.Logos.SplusObjects.StringInput( RX__AnalogSerialInput__, 200, this );
    m_StringInputList.Add( RX__AnalogSerialInput__, RX );
    
    TX = new Crestron.Logos.SplusObjects.StringOutput( TX__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__AnalogSerialOutput__, TX );
    
    
    VOL_LEVEL.OnAnalogChange.Add( new InputChangeHandlerWrapper( VOL_LEVEL_OnChange_0, false ) );
    MUTE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( MUTE_OnRelease_1, false ) );
    MUTE.OnDigitalPush.Add( new InputChangeHandlerWrapper( MUTE_OnPush_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_MND17_SONY_FWL_VOLUME_BY_ANALOG_V1 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint VOL_LEVEL__AnalogSerialInput__ = 0;
const uint MUTE__DigitalInput__ = 0;
const uint TX__AnalogSerialOutput__ = 0;
const uint RX__AnalogSerialInput__ = 1;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort VOLUME_LEVEL = 0;
            
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
