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

namespace UserModule_MND17_SONY_FWL_DISPLAY_IP_CONTROL_V1
{
    public class UserModuleClass_MND17_SONY_FWL_DISPLAY_IP_CONTROL_V1 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.BufferInput FROM_DISPLAY__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TO_DISPLAY__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput POLLX;
        Crestron.Logos.SplusObjects.DigitalInput DEBUG;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> REQ_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> REQ_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> REQ_HDMI1;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> REQ_HDMI2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> REQ_HDMI3;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> REQ_HDMI4;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> REQ_VGA1;
        Crestron.Logos.SplusObjects.DigitalOutput PWR_IS_ON;
        private void SET_DISPLAY (  SplusExecutionContext __context__, ushort FUNC ) 
            { 
            
            __context__.SourceCodeLine = 81;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FUNC == 1))  ) ) 
                {
                __context__.SourceCodeLine = 81;
                TO_DISPLAY__DOLLAR__  .UpdateValue ( "*SCPOWR0000000000000001\u000A"  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 82;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FUNC == 2))  ) ) 
                    {
                    __context__.SourceCodeLine = 82;
                    TO_DISPLAY__DOLLAR__  .UpdateValue ( "*SCPOWR0000000000000000\u000A"  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 84;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FUNC == 3))  ) ) 
                        {
                        __context__.SourceCodeLine = 84;
                        TO_DISPLAY__DOLLAR__  .UpdateValue ( "*SCINPT0000000100000001\u000A"  ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 85;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FUNC == 4))  ) ) 
                            {
                            __context__.SourceCodeLine = 85;
                            TO_DISPLAY__DOLLAR__  .UpdateValue ( "*SCINPT0000000100000002\u000A"  ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 86;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FUNC == 5))  ) ) 
                                {
                                __context__.SourceCodeLine = 86;
                                TO_DISPLAY__DOLLAR__  .UpdateValue ( "*SCINPT0000000100000003\u000A"  ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 87;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FUNC == 6))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 87;
                                    TO_DISPLAY__DOLLAR__  .UpdateValue ( "*SCINPT0000000100000004\u000A"  ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 88;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FUNC == 7))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 88;
                                        TO_DISPLAY__DOLLAR__  .UpdateValue ( "*SCINPT0000000600000001\u000A"  ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 89;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FUNC == 30))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 89;
                                            TO_DISPLAY__DOLLAR__  .UpdateValue ( "\u000A"  ) ; 
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            
            }
            
        private void POLL (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 94;
            _SplusNVRAM.CHECKING_PWR = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 95;
            _SplusNVRAM.CHECKING_INPUT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 96;
            TO_DISPLAY__DOLLAR__  .UpdateValue ( "*SEPOWR################\u000A"  ) ; 
            __context__.SourceCodeLine = 98;
            Functions.Delay (  (int) ( 50 ) ) ; 
            __context__.SourceCodeLine = 99;
            _SplusNVRAM.CHECKING_PWR = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 100;
            _SplusNVRAM.CHECKING_INPUT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 101;
            TO_DISPLAY__DOLLAR__  .UpdateValue ( "*SEINPT################\u000A"  ) ; 
            __context__.SourceCodeLine = 103;
            Functions.Delay (  (int) ( 50 ) ) ; 
            __context__.SourceCodeLine = 104;
            _SplusNVRAM.CHECKING_PWR = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 105;
            _SplusNVRAM.CHECKING_INPUT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 106;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.PWR_WANTED != _SplusNVRAM.PWR_NOW))  ) ) 
                {
                __context__.SourceCodeLine = 106;
                SET_DISPLAY (  __context__ , (ushort)( _SplusNVRAM.PWR_WANTED )) ; 
                }
            
            __context__.SourceCodeLine = 108;
            Functions.Delay (  (int) ( 50 ) ) ; 
            __context__.SourceCodeLine = 109;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.PWR_NOW == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 111;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.IP_WANTED != _SplusNVRAM.IP_NOW))  ) ) 
                    {
                    __context__.SourceCodeLine = 111;
                    SET_DISPLAY (  __context__ , (ushort)( _SplusNVRAM.IP_WANTED )) ; 
                    }
                
                } 
            
            
            }
            
        object POLLX_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 124;
                POLL (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object REQ_ON_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 129;
            _SplusNVRAM.PWR_WANTED = (ushort) ( 1 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object REQ_OFF_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 133;
        SET_DISPLAY (  __context__ , (ushort)( 6 )) ; 
        __context__.SourceCodeLine = 134;
        _SplusNVRAM.PWR_WANTED = (ushort) ( 2 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REQ_HDMI1_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 140;
        SET_DISPLAY (  __context__ , (ushort)( 3 )) ; 
        __context__.SourceCodeLine = 141;
        _SplusNVRAM.IP_WANTED = (ushort) ( 3 ) ; 
        __context__.SourceCodeLine = 142;
        _SplusNVRAM.INTERRUPT_INP = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REQ_HDMI2_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 146;
        SET_DISPLAY (  __context__ , (ushort)( 4 )) ; 
        __context__.SourceCodeLine = 147;
        _SplusNVRAM.IP_WANTED = (ushort) ( 4 ) ; 
        __context__.SourceCodeLine = 148;
        _SplusNVRAM.INTERRUPT_INP = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REQ_HDMI3_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 152;
        SET_DISPLAY (  __context__ , (ushort)( 5 )) ; 
        __context__.SourceCodeLine = 153;
        _SplusNVRAM.IP_WANTED = (ushort) ( 5 ) ; 
        __context__.SourceCodeLine = 154;
        _SplusNVRAM.INTERRUPT_INP = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REQ_HDMI4_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 158;
        SET_DISPLAY (  __context__ , (ushort)( 6 )) ; 
        __context__.SourceCodeLine = 159;
        _SplusNVRAM.IP_WANTED = (ushort) ( 6 ) ; 
        __context__.SourceCodeLine = 160;
        _SplusNVRAM.INTERRUPT_INP = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REQ_VGA1_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 164;
        SET_DISPLAY (  __context__ , (ushort)( 7 )) ; 
        __context__.SourceCodeLine = 165;
        _SplusNVRAM.IP_WANTED = (ushort) ( 7 ) ; 
        __context__.SourceCodeLine = 166;
        _SplusNVRAM.INTERRUPT_INP = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 167;
        CreateWait ( "AUTOIMAGEWAIT" , 150 , AUTOIMAGEWAIT_Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void AUTOIMAGEWAIT_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 169;
            SET_DISPLAY (  __context__ , (ushort)( 30 )) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object REQ_VGA1_OnRelease_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 174;
        CancelWait ( "AUTOIMAGEWAIT" ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FROM_DISPLAY__DOLLAR___OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 179;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.CHECKING_INPUT)  ) ) 
            { 
            __context__.SourceCodeLine = 181;
            if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 181;
                Print( "CHECKING INP...\r") ; 
                }
            
            __context__.SourceCodeLine = 182;
            if ( Functions.TestForTrue  ( ( Functions.Find( "*SAINPT0000000100000001" , FROM_DISPLAY__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 184;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 184;
                    Print( "got INP=HDMI1...\r") ; 
                    }
                
                __context__.SourceCodeLine = 185;
                _SplusNVRAM.IP_NOW = (ushort) ( 3 ) ; 
                __context__.SourceCodeLine = 186;
                FROM_DISPLAY__DOLLAR__  .UpdateValue ( ""  ) ; 
                } 
            
            __context__.SourceCodeLine = 188;
            if ( Functions.TestForTrue  ( ( Functions.Find( "*SAINPT0000000100000002" , FROM_DISPLAY__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 191;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 191;
                    Print( "got INP=HDMI2...\r") ; 
                    }
                
                __context__.SourceCodeLine = 192;
                _SplusNVRAM.IP_NOW = (ushort) ( 4 ) ; 
                __context__.SourceCodeLine = 193;
                FROM_DISPLAY__DOLLAR__  .UpdateValue ( ""  ) ; 
                } 
            
            __context__.SourceCodeLine = 195;
            if ( Functions.TestForTrue  ( ( Functions.Find( "*SAINPT0000000100000003" , FROM_DISPLAY__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 197;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 197;
                    Print( "got INP=HDMI3...\r") ; 
                    }
                
                __context__.SourceCodeLine = 198;
                _SplusNVRAM.IP_NOW = (ushort) ( 5 ) ; 
                __context__.SourceCodeLine = 199;
                FROM_DISPLAY__DOLLAR__  .UpdateValue ( ""  ) ; 
                } 
            
            __context__.SourceCodeLine = 201;
            if ( Functions.TestForTrue  ( ( Functions.Find( "*SAINPT0000000100000004" , FROM_DISPLAY__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 203;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 203;
                    Print( "got INP=HDMI4...\r") ; 
                    }
                
                __context__.SourceCodeLine = 204;
                _SplusNVRAM.IP_NOW = (ushort) ( 6 ) ; 
                __context__.SourceCodeLine = 205;
                FROM_DISPLAY__DOLLAR__  .UpdateValue ( ""  ) ; 
                } 
            
            __context__.SourceCodeLine = 207;
            if ( Functions.TestForTrue  ( ( Functions.Find( "*SAINPT0000000200000001" , FROM_DISPLAY__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 209;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 209;
                    Print( "got INP=VGA1...\r") ; 
                    }
                
                __context__.SourceCodeLine = 210;
                _SplusNVRAM.IP_NOW = (ushort) ( 7 ) ; 
                __context__.SourceCodeLine = 211;
                FROM_DISPLAY__DOLLAR__  .UpdateValue ( ""  ) ; 
                } 
            
            __context__.SourceCodeLine = 213;
            if ( Functions.TestForTrue  ( ( Functions.Find( "*SAINPT0000000000000000" , FROM_DISPLAY__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 216;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 216;
                    Print( "got INP=no signal...\r") ; 
                    }
                
                __context__.SourceCodeLine = 217;
                FROM_DISPLAY__DOLLAR__  .UpdateValue ( ""  ) ; 
                } 
            
            __context__.SourceCodeLine = 219;
            if ( Functions.TestForTrue  ( ( Functions.Find( "*SAINPTFFFFFFFFFFFFFFFF" , FROM_DISPLAY__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 221;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 221;
                    Print( "got INP=SMART MODE?...\r") ; 
                    }
                
                __context__.SourceCodeLine = 222;
                FROM_DISPLAY__DOLLAR__  .UpdateValue ( ""  ) ; 
                } 
            
            } 
        
        __context__.SourceCodeLine = 225;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.CHECKING_PWR)  ) ) 
            { 
            __context__.SourceCodeLine = 228;
            if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 228;
                Print( "CHECKING PWR...\r") ; 
                }
            
            __context__.SourceCodeLine = 229;
            if ( Functions.TestForTrue  ( ( Functions.Find( "*SAPOWR0000000000000001" , FROM_DISPLAY__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 231;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 231;
                    Print( "got PWR=on...\r") ; 
                    }
                
                __context__.SourceCodeLine = 232;
                _SplusNVRAM.PWR_NOW = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 233;
                PWR_IS_ON  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 234;
                FROM_DISPLAY__DOLLAR__  .UpdateValue ( ""  ) ; 
                } 
            
            __context__.SourceCodeLine = 236;
            if ( Functions.TestForTrue  ( ( Functions.Find( "*SAPOWR0000000000000000" , FROM_DISPLAY__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 238;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 238;
                    Print( "got PWR=off...\r") ; 
                    }
                
                __context__.SourceCodeLine = 239;
                _SplusNVRAM.PWR_NOW = (ushort) ( 2 ) ; 
                __context__.SourceCodeLine = 240;
                PWR_IS_ON  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 241;
                FROM_DISPLAY__DOLLAR__  .UpdateValue ( ""  ) ; 
                } 
            
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
    
    POLLX = new Crestron.Logos.SplusObjects.DigitalInput( POLLX__DigitalInput__, this );
    m_DigitalInputList.Add( POLLX__DigitalInput__, POLLX );
    
    DEBUG = new Crestron.Logos.SplusObjects.DigitalInput( DEBUG__DigitalInput__, this );
    m_DigitalInputList.Add( DEBUG__DigitalInput__, DEBUG );
    
    REQ_ON = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        REQ_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( REQ_ON__DigitalInput__ + i, REQ_ON__DigitalInput__, this );
        m_DigitalInputList.Add( REQ_ON__DigitalInput__ + i, REQ_ON[i+1] );
    }
    
    REQ_OFF = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        REQ_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( REQ_OFF__DigitalInput__ + i, REQ_OFF__DigitalInput__, this );
        m_DigitalInputList.Add( REQ_OFF__DigitalInput__ + i, REQ_OFF[i+1] );
    }
    
    REQ_HDMI1 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        REQ_HDMI1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( REQ_HDMI1__DigitalInput__ + i, REQ_HDMI1__DigitalInput__, this );
        m_DigitalInputList.Add( REQ_HDMI1__DigitalInput__ + i, REQ_HDMI1[i+1] );
    }
    
    REQ_HDMI2 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        REQ_HDMI2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( REQ_HDMI2__DigitalInput__ + i, REQ_HDMI2__DigitalInput__, this );
        m_DigitalInputList.Add( REQ_HDMI2__DigitalInput__ + i, REQ_HDMI2[i+1] );
    }
    
    REQ_HDMI3 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        REQ_HDMI3[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( REQ_HDMI3__DigitalInput__ + i, REQ_HDMI3__DigitalInput__, this );
        m_DigitalInputList.Add( REQ_HDMI3__DigitalInput__ + i, REQ_HDMI3[i+1] );
    }
    
    REQ_HDMI4 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        REQ_HDMI4[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( REQ_HDMI4__DigitalInput__ + i, REQ_HDMI4__DigitalInput__, this );
        m_DigitalInputList.Add( REQ_HDMI4__DigitalInput__ + i, REQ_HDMI4[i+1] );
    }
    
    REQ_VGA1 = new InOutArray<DigitalInput>( 5, this );
    for( uint i = 0; i < 5; i++ )
    {
        REQ_VGA1[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( REQ_VGA1__DigitalInput__ + i, REQ_VGA1__DigitalInput__, this );
        m_DigitalInputList.Add( REQ_VGA1__DigitalInput__ + i, REQ_VGA1[i+1] );
    }
    
    PWR_IS_ON = new Crestron.Logos.SplusObjects.DigitalOutput( PWR_IS_ON__DigitalOutput__, this );
    m_DigitalOutputList.Add( PWR_IS_ON__DigitalOutput__, PWR_IS_ON );
    
    TO_DISPLAY__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TO_DISPLAY__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_DISPLAY__DOLLAR____AnalogSerialOutput__, TO_DISPLAY__DOLLAR__ );
    
    FROM_DISPLAY__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( FROM_DISPLAY__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( FROM_DISPLAY__DOLLAR____AnalogSerialInput__, FROM_DISPLAY__DOLLAR__ );
    
    AUTOIMAGEWAIT_Callback = new WaitFunction( AUTOIMAGEWAIT_CallbackFn );
    
    POLLX.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLLX_OnPush_0, false ) );
    for( uint i = 0; i < 5; i++ )
        REQ_ON[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( REQ_ON_OnPush_1, false ) );
        
    for( uint i = 0; i < 5; i++ )
        REQ_OFF[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( REQ_OFF_OnPush_2, false ) );
        
    for( uint i = 0; i < 5; i++ )
        REQ_HDMI1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( REQ_HDMI1_OnPush_3, false ) );
        
    for( uint i = 0; i < 5; i++ )
        REQ_HDMI2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( REQ_HDMI2_OnPush_4, false ) );
        
    for( uint i = 0; i < 5; i++ )
        REQ_HDMI3[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( REQ_HDMI3_OnPush_5, false ) );
        
    for( uint i = 0; i < 5; i++ )
        REQ_HDMI4[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( REQ_HDMI4_OnPush_6, false ) );
        
    for( uint i = 0; i < 5; i++ )
        REQ_VGA1[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( REQ_VGA1_OnPush_7, false ) );
        
    for( uint i = 0; i < 5; i++ )
        REQ_VGA1[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( REQ_VGA1_OnRelease_8, false ) );
        
    FROM_DISPLAY__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_DISPLAY__DOLLAR___OnChange_9, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_MND17_SONY_FWL_DISPLAY_IP_CONTROL_V1 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction AUTOIMAGEWAIT_Callback;


const uint FROM_DISPLAY__DOLLAR____AnalogSerialInput__ = 0;
const uint TO_DISPLAY__DOLLAR____AnalogSerialOutput__ = 0;
const uint POLLX__DigitalInput__ = 0;
const uint DEBUG__DigitalInput__ = 1;
const uint REQ_ON__DigitalInput__ = 2;
const uint REQ_OFF__DigitalInput__ = 7;
const uint REQ_HDMI1__DigitalInput__ = 12;
const uint REQ_HDMI2__DigitalInput__ = 17;
const uint REQ_HDMI3__DigitalInput__ = 22;
const uint REQ_HDMI4__DigitalInput__ = 27;
const uint REQ_VGA1__DigitalInput__ = 32;
const uint PWR_IS_ON__DigitalOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort IP_WANTED = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort IP_NOW = 0;
            [SplusStructAttribute(2, false, true)]
            public ushort PWR_WANTED = 0;
            [SplusStructAttribute(3, false, true)]
            public ushort PWR_NOW = 0;
            [SplusStructAttribute(4, false, true)]
            public ushort CHECKING_INPUT = 0;
            [SplusStructAttribute(5, false, true)]
            public ushort CHECKING_PWR = 0;
            [SplusStructAttribute(6, false, true)]
            public ushort SCREEN_NOW = 0;
            [SplusStructAttribute(7, false, true)]
            public ushort INTERRUPT_INP = 0;
            [SplusStructAttribute(8, false, true)]
            public ushort BLANK_WANTED = 0;
            [SplusStructAttribute(9, false, true)]
            public ushort BLANK_NOW = 0;
            [SplusStructAttribute(10, false, true)]
            public ushort LAMP_HOURS_MEM = 0;
            [SplusStructAttribute(11, false, true)]
            public ushort CHECKING_LAMP = 0;
            
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
