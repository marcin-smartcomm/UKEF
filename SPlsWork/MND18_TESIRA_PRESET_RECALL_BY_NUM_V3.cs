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

namespace UserModule_MND18_TESIRA_PRESET_RECALL_BY_NUM_V3
{
    public class UserModuleClass_MND18_TESIRA_PRESET_RECALL_BY_NUM_V3 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CALL_AGAIN;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PRESET_GO;
        InOutArray<StringParameter> PRESET_NAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        ushort LAST = 0;
        object PRESET_GO_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 86;
                LAST = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 87;
                TX__DOLLAR__  .UpdateValue ( "DEVICE recallPreset " + PRESET_NAME__DOLLAR__ [ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] + "\u000A"  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object CALL_AGAIN_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 92;
            if ( Functions.TestForTrue  ( ( LAST)  ) ) 
                {
                __context__.SourceCodeLine = 92;
                TX__DOLLAR__  .UpdateValue ( "DEVICE recallPresetByName \u0022" + PRESET_NAME__DOLLAR__ [ LAST ] + "\u0022\u000A"  ) ; 
                }
            
            
            
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
    
    CALL_AGAIN = new Crestron.Logos.SplusObjects.DigitalInput( CALL_AGAIN__DigitalInput__, this );
    m_DigitalInputList.Add( CALL_AGAIN__DigitalInput__, CALL_AGAIN );
    
    PRESET_GO = new InOutArray<DigitalInput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        PRESET_GO[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PRESET_GO__DigitalInput__ + i, PRESET_GO__DigitalInput__, this );
        m_DigitalInputList.Add( PRESET_GO__DigitalInput__ + i, PRESET_GO[i+1] );
    }
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    PRESET_NAME__DOLLAR__ = new InOutArray<StringParameter>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        PRESET_NAME__DOLLAR__[i+1] = new StringParameter( PRESET_NAME__DOLLAR____Parameter__ + i, PRESET_NAME__DOLLAR____Parameter__, this );
        m_ParameterList.Add( PRESET_NAME__DOLLAR____Parameter__ + i, PRESET_NAME__DOLLAR__[i+1] );
    }
    
    
    for( uint i = 0; i < 30; i++ )
        PRESET_GO[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESET_GO_OnPush_0, false ) );
        
    CALL_AGAIN.OnDigitalPush.Add( new InputChangeHandlerWrapper( CALL_AGAIN_OnPush_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_MND18_TESIRA_PRESET_RECALL_BY_NUM_V3 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint CALL_AGAIN__DigitalInput__ = 0;
const uint PRESET_GO__DigitalInput__ = 1;
const uint PRESET_NAME__DOLLAR____Parameter__ = 10;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
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
