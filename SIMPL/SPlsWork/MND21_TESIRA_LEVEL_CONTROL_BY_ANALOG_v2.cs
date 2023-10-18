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

namespace UserModule_MND21_TESIRA_LEVEL_CONTROL_BY_ANALOG_V2
{
    public class UserModuleClass_MND21_TESIRA_LEVEL_CONTROL_BY_ANALOG_V2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ACTIVE;
        Crestron.Logos.SplusObjects.DigitalInput REFRESH;
        Crestron.Logos.SplusObjects.DigitalInput MUTE;
        Crestron.Logos.SplusObjects.AnalogInput LEVEL_IN;
        Crestron.Logos.SplusObjects.StringInput TESIRA_LEVEL_NAME_OVERRIDE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput TESIRA_LEVEL_NUM_OVERRIDE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput TESIRA_MUTE_NAME_OVERRIDE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput TESIRA_MUTE_NUM_OVERRIDE__DOLLAR__;
        StringParameter TESIRA_LEVEL_NAME_SET__DOLLAR__;
        StringParameter TESIRA_LEVEL_NUM_SET__DOLLAR__;
        StringParameter TESIRA_MUTE_NAME_SET__DOLLAR__;
        StringParameter TESIRA_MUTE_NUM_SET__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        CrestronString ASCII_VOL_LEVEL;
        CrestronString TESIRA_LEVEL_NAME__DOLLAR__;
        CrestronString TESIRA_LEVEL_NUM__DOLLAR__;
        CrestronString TESIRA_MUTE_NAME__DOLLAR__;
        CrestronString TESIRA_MUTE_NUM__DOLLAR__;
        private void SET_VOL (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 92;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.VOL_LEVEL < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 94;
                ASCII_VOL_LEVEL  .UpdateValue ( "-" + Functions.ItoA (  (int) ( (65535 - (_SplusNVRAM.VOL_LEVEL - 1)) ) )  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 96;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.VOL_LEVEL >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 98;
                    ASCII_VOL_LEVEL  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.VOL_LEVEL ) )  ) ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 100;
            TX__DOLLAR__  .UpdateValue ( "" + Functions.Chr (  (int) ( 34 ) ) + TESIRA_LEVEL_NAME__DOLLAR__ + Functions.Chr (  (int) ( 34 ) ) + " set level " + TESIRA_LEVEL_NUM__DOLLAR__ + " " + ASCII_VOL_LEVEL + "\u000A"  ) ; 
            
            }
            
        object TESIRA_LEVEL_NAME_OVERRIDE__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 111;
                TESIRA_LEVEL_NAME__DOLLAR__  .UpdateValue ( TESIRA_LEVEL_NAME_OVERRIDE__DOLLAR__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object TESIRA_LEVEL_NUM_OVERRIDE__DOLLAR___OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 115;
            TESIRA_LEVEL_NUM__DOLLAR__  .UpdateValue ( TESIRA_LEVEL_NUM_OVERRIDE__DOLLAR__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object TESIRA_MUTE_NAME_OVERRIDE__DOLLAR___OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 119;
        TESIRA_MUTE_NAME__DOLLAR__  .UpdateValue ( TESIRA_MUTE_NAME_OVERRIDE__DOLLAR__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TESIRA_MUTE_NUM_OVERRIDE__DOLLAR___OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 123;
        TESIRA_MUTE_NUM__DOLLAR__  .UpdateValue ( TESIRA_MUTE_NUM_OVERRIDE__DOLLAR__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ACTIVE_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 129;
        Functions.Delay (  (int) ( 200 ) ) ; 
        __context__.SourceCodeLine = 130;
        SET_VOL (  __context__  ) ; 
        __context__.SourceCodeLine = 131;
        if ( Functions.TestForTrue  ( ( MUTE  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 133;
            TX__DOLLAR__  .UpdateValue ( "" + Functions.Chr (  (int) ( 34 ) ) + TESIRA_MUTE_NAME__DOLLAR__ + Functions.Chr (  (int) ( 34 ) ) + " set mute " + TESIRA_MUTE_NUM__DOLLAR__ + " true\u000A"  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 135;
            if ( Functions.TestForTrue  ( ( Functions.Not( MUTE  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 137;
                TX__DOLLAR__  .UpdateValue ( "" + Functions.Chr (  (int) ( 34 ) ) + TESIRA_MUTE_NAME__DOLLAR__ + Functions.Chr (  (int) ( 34 ) ) + " set mute " + TESIRA_MUTE_NUM__DOLLAR__ + " false\u000A"  ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REFRESH_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 142;
        if ( Functions.TestForTrue  ( ( ACTIVE  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 144;
            SET_VOL (  __context__  ) ; 
            __context__.SourceCodeLine = 145;
            Functions.Delay (  (int) ( 5 ) ) ; 
            __context__.SourceCodeLine = 146;
            if ( Functions.TestForTrue  ( ( MUTE  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 148;
                TX__DOLLAR__  .UpdateValue ( "" + Functions.Chr (  (int) ( 34 ) ) + TESIRA_MUTE_NAME__DOLLAR__ + Functions.Chr (  (int) ( 34 ) ) + " set mute " + TESIRA_MUTE_NUM__DOLLAR__ + " true\u000A"  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 150;
                if ( Functions.TestForTrue  ( ( Functions.Not( MUTE  .Value ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 152;
                    TX__DOLLAR__  .UpdateValue ( "" + Functions.Chr (  (int) ( 34 ) ) + TESIRA_MUTE_NAME__DOLLAR__ + Functions.Chr (  (int) ( 34 ) ) + " set mute " + TESIRA_MUTE_NUM__DOLLAR__ + " false\u000A"  ) ; 
                    } 
                
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LEVEL_IN_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 161;
        if ( Functions.TestForTrue  ( ( ACTIVE  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 163;
            _SplusNVRAM.VOL_LEVEL = (short) ( LEVEL_IN  .ShortValue ) ; 
            __context__.SourceCodeLine = 164;
            SET_VOL (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MUTE_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 170;
        if ( Functions.TestForTrue  ( ( ACTIVE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 170;
            TX__DOLLAR__  .UpdateValue ( "" + Functions.Chr (  (int) ( 34 ) ) + TESIRA_MUTE_NAME__DOLLAR__ + Functions.Chr (  (int) ( 34 ) ) + " set mute " + TESIRA_MUTE_NUM__DOLLAR__ + " true\u000A"  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MUTE_OnRelease_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 174;
        if ( Functions.TestForTrue  ( ( ACTIVE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 174;
            TX__DOLLAR__  .UpdateValue ( "" + Functions.Chr (  (int) ( 34 ) ) + TESIRA_MUTE_NAME__DOLLAR__ + Functions.Chr (  (int) ( 34 ) ) + " set mute " + TESIRA_MUTE_NUM__DOLLAR__ + " false\u000A"  ) ; 
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
        
        __context__.SourceCodeLine = 185;
        TESIRA_LEVEL_NAME__DOLLAR__  .UpdateValue ( TESIRA_LEVEL_NAME_SET__DOLLAR__  ) ; 
        __context__.SourceCodeLine = 186;
        TESIRA_LEVEL_NUM__DOLLAR__  .UpdateValue ( TESIRA_LEVEL_NUM_SET__DOLLAR__  ) ; 
        __context__.SourceCodeLine = 187;
        TESIRA_MUTE_NAME__DOLLAR__  .UpdateValue ( TESIRA_MUTE_NAME_SET__DOLLAR__  ) ; 
        __context__.SourceCodeLine = 188;
        TESIRA_MUTE_NUM__DOLLAR__  .UpdateValue ( TESIRA_MUTE_NUM_SET__DOLLAR__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    ASCII_VOL_LEVEL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
    TESIRA_LEVEL_NAME__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    TESIRA_LEVEL_NUM__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    TESIRA_MUTE_NAME__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    TESIRA_MUTE_NUM__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    
    ACTIVE = new Crestron.Logos.SplusObjects.DigitalInput( ACTIVE__DigitalInput__, this );
    m_DigitalInputList.Add( ACTIVE__DigitalInput__, ACTIVE );
    
    REFRESH = new Crestron.Logos.SplusObjects.DigitalInput( REFRESH__DigitalInput__, this );
    m_DigitalInputList.Add( REFRESH__DigitalInput__, REFRESH );
    
    MUTE = new Crestron.Logos.SplusObjects.DigitalInput( MUTE__DigitalInput__, this );
    m_DigitalInputList.Add( MUTE__DigitalInput__, MUTE );
    
    LEVEL_IN = new Crestron.Logos.SplusObjects.AnalogInput( LEVEL_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( LEVEL_IN__AnalogSerialInput__, LEVEL_IN );
    
    TESIRA_LEVEL_NAME_OVERRIDE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( TESIRA_LEVEL_NAME_OVERRIDE__DOLLAR____AnalogSerialInput__, 50, this );
    m_StringInputList.Add( TESIRA_LEVEL_NAME_OVERRIDE__DOLLAR____AnalogSerialInput__, TESIRA_LEVEL_NAME_OVERRIDE__DOLLAR__ );
    
    TESIRA_LEVEL_NUM_OVERRIDE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( TESIRA_LEVEL_NUM_OVERRIDE__DOLLAR____AnalogSerialInput__, 50, this );
    m_StringInputList.Add( TESIRA_LEVEL_NUM_OVERRIDE__DOLLAR____AnalogSerialInput__, TESIRA_LEVEL_NUM_OVERRIDE__DOLLAR__ );
    
    TESIRA_MUTE_NAME_OVERRIDE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( TESIRA_MUTE_NAME_OVERRIDE__DOLLAR____AnalogSerialInput__, 50, this );
    m_StringInputList.Add( TESIRA_MUTE_NAME_OVERRIDE__DOLLAR____AnalogSerialInput__, TESIRA_MUTE_NAME_OVERRIDE__DOLLAR__ );
    
    TESIRA_MUTE_NUM_OVERRIDE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( TESIRA_MUTE_NUM_OVERRIDE__DOLLAR____AnalogSerialInput__, 50, this );
    m_StringInputList.Add( TESIRA_MUTE_NUM_OVERRIDE__DOLLAR____AnalogSerialInput__, TESIRA_MUTE_NUM_OVERRIDE__DOLLAR__ );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    TESIRA_LEVEL_NAME_SET__DOLLAR__ = new StringParameter( TESIRA_LEVEL_NAME_SET__DOLLAR____Parameter__, this );
    m_ParameterList.Add( TESIRA_LEVEL_NAME_SET__DOLLAR____Parameter__, TESIRA_LEVEL_NAME_SET__DOLLAR__ );
    
    TESIRA_LEVEL_NUM_SET__DOLLAR__ = new StringParameter( TESIRA_LEVEL_NUM_SET__DOLLAR____Parameter__, this );
    m_ParameterList.Add( TESIRA_LEVEL_NUM_SET__DOLLAR____Parameter__, TESIRA_LEVEL_NUM_SET__DOLLAR__ );
    
    TESIRA_MUTE_NAME_SET__DOLLAR__ = new StringParameter( TESIRA_MUTE_NAME_SET__DOLLAR____Parameter__, this );
    m_ParameterList.Add( TESIRA_MUTE_NAME_SET__DOLLAR____Parameter__, TESIRA_MUTE_NAME_SET__DOLLAR__ );
    
    TESIRA_MUTE_NUM_SET__DOLLAR__ = new StringParameter( TESIRA_MUTE_NUM_SET__DOLLAR____Parameter__, this );
    m_ParameterList.Add( TESIRA_MUTE_NUM_SET__DOLLAR____Parameter__, TESIRA_MUTE_NUM_SET__DOLLAR__ );
    
    
    TESIRA_LEVEL_NAME_OVERRIDE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( TESIRA_LEVEL_NAME_OVERRIDE__DOLLAR___OnChange_0, false ) );
    TESIRA_LEVEL_NUM_OVERRIDE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( TESIRA_LEVEL_NUM_OVERRIDE__DOLLAR___OnChange_1, false ) );
    TESIRA_MUTE_NAME_OVERRIDE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( TESIRA_MUTE_NAME_OVERRIDE__DOLLAR___OnChange_2, false ) );
    TESIRA_MUTE_NUM_OVERRIDE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( TESIRA_MUTE_NUM_OVERRIDE__DOLLAR___OnChange_3, false ) );
    ACTIVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( ACTIVE_OnPush_4, false ) );
    REFRESH.OnDigitalPush.Add( new InputChangeHandlerWrapper( REFRESH_OnPush_5, false ) );
    LEVEL_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( LEVEL_IN_OnChange_6, false ) );
    MUTE.OnDigitalPush.Add( new InputChangeHandlerWrapper( MUTE_OnPush_7, false ) );
    MUTE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( MUTE_OnRelease_8, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_MND21_TESIRA_LEVEL_CONTROL_BY_ANALOG_V2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint ACTIVE__DigitalInput__ = 0;
const uint REFRESH__DigitalInput__ = 1;
const uint MUTE__DigitalInput__ = 2;
const uint LEVEL_IN__AnalogSerialInput__ = 0;
const uint TESIRA_LEVEL_NAME_OVERRIDE__DOLLAR____AnalogSerialInput__ = 1;
const uint TESIRA_LEVEL_NUM_OVERRIDE__DOLLAR____AnalogSerialInput__ = 2;
const uint TESIRA_MUTE_NAME_OVERRIDE__DOLLAR____AnalogSerialInput__ = 3;
const uint TESIRA_MUTE_NUM_OVERRIDE__DOLLAR____AnalogSerialInput__ = 4;
const uint TESIRA_LEVEL_NAME_SET__DOLLAR____Parameter__ = 10;
const uint TESIRA_LEVEL_NUM_SET__DOLLAR____Parameter__ = 11;
const uint TESIRA_MUTE_NAME_SET__DOLLAR____Parameter__ = 12;
const uint TESIRA_MUTE_NUM_SET__DOLLAR____Parameter__ = 13;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public short VOL_LEVEL = 0;
            
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
