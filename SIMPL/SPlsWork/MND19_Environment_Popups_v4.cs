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

namespace UserModule_MND19_ENVIRONMENT_POPUPS_V4
{
    public class UserModuleClass_MND19_ENVIRONMENT_POPUPS_V4 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CLEAR_POPS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> ENVIRON_POP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> ALL_POP_BUTTONS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> CANCEL_TIMEOUT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SHOW_POP;
        UShortParameter POPTIME;
        ushort POP_NOW = 0;
        ushort X = 0;
        object CLEAR_POPS_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 88;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)15; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 90;
                    if ( Functions.TestForTrue  ( ( IsSignalDefined( SHOW_POP[ X ] ))  ) ) 
                        {
                        __context__.SourceCodeLine = 90;
                        SHOW_POP [ X]  .Value = (ushort) ( 0 ) ; 
                        }
                    
                    __context__.SourceCodeLine = 88;
                    } 
                
                __context__.SourceCodeLine = 92;
                POP_NOW = (ushort) ( 0 ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object ALL_POP_BUTTONS_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 98;
            CreateWait ( "POPWAIT" , POPTIME  .Value , POPWAIT_Callback ) ;
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public void POPWAIT_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 100;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)15; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 102;
                SHOW_POP [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 100;
                } 
            
            __context__.SourceCodeLine = 104;
            POP_NOW = (ushort) ( 0 ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object CANCEL_TIMEOUT_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 109;
        CancelWait ( "POPWAIT" ) ; 
        __context__.SourceCodeLine = 110;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_2__" , 100 , __SPLS_TMPVAR__WAITLABEL_2___Callback ) ;
        __context__.SourceCodeLine = 110;
        CancelWait ( "POPWAIT" ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void __SPLS_TMPVAR__WAITLABEL_2___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 110;
            ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object ALL_POP_BUTTONS_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 115;
        CancelWait ( "POPWAIT" ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENVIRON_POP_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 120;
        CancelWait ( "POPWAIT" ) ; 
        __context__.SourceCodeLine = 121;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)15; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 123;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( SHOW_POP[ X ] ))  ) ) 
                {
                __context__.SourceCodeLine = 123;
                SHOW_POP [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 121;
            } 
        
        __context__.SourceCodeLine = 125;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (POP_NOW != Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )))  ) ) 
            { 
            __context__.SourceCodeLine = 127;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)15; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( X  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (X  >= __FN_FORSTART_VAL__2) && (X  <= __FN_FOREND_VAL__2) ) : ( (X  <= __FN_FORSTART_VAL__2) && (X  >= __FN_FOREND_VAL__2) ) ; X  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 129;
                if ( Functions.TestForTrue  ( ( IsSignalDefined( SHOW_POP[ X ] ))  ) ) 
                    {
                    __context__.SourceCodeLine = 129;
                    SHOW_POP [ X]  .Value = (ushort) ( 0 ) ; 
                    }
                
                __context__.SourceCodeLine = 130;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (X == 15))  ) ) 
                    { 
                    __context__.SourceCodeLine = 132;
                    SHOW_POP [ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )]  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 133;
                    POP_NOW = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 127;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 137;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (POP_NOW == Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )))  ) ) 
                { 
                __context__.SourceCodeLine = 139;
                POP_NOW = (ushort) ( 0 ) ; 
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
    
    CLEAR_POPS = new InOutArray<DigitalInput>( 20, this );
    for( uint i = 0; i < 20; i++ )
    {
        CLEAR_POPS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CLEAR_POPS__DigitalInput__ + i, CLEAR_POPS__DigitalInput__, this );
        m_DigitalInputList.Add( CLEAR_POPS__DigitalInput__ + i, CLEAR_POPS[i+1] );
    }
    
    ENVIRON_POP = new InOutArray<DigitalInput>( 15, this );
    for( uint i = 0; i < 15; i++ )
    {
        ENVIRON_POP[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( ENVIRON_POP__DigitalInput__ + i, ENVIRON_POP__DigitalInput__, this );
        m_DigitalInputList.Add( ENVIRON_POP__DigitalInput__ + i, ENVIRON_POP[i+1] );
    }
    
    ALL_POP_BUTTONS = new InOutArray<DigitalInput>( 198, this );
    for( uint i = 0; i < 198; i++ )
    {
        ALL_POP_BUTTONS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( ALL_POP_BUTTONS__DigitalInput__ + i, ALL_POP_BUTTONS__DigitalInput__, this );
        m_DigitalInputList.Add( ALL_POP_BUTTONS__DigitalInput__ + i, ALL_POP_BUTTONS[i+1] );
    }
    
    CANCEL_TIMEOUT = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        CANCEL_TIMEOUT[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( CANCEL_TIMEOUT__DigitalInput__ + i, CANCEL_TIMEOUT__DigitalInput__, this );
        m_DigitalInputList.Add( CANCEL_TIMEOUT__DigitalInput__ + i, CANCEL_TIMEOUT[i+1] );
    }
    
    SHOW_POP = new InOutArray<DigitalOutput>( 15, this );
    for( uint i = 0; i < 15; i++ )
    {
        SHOW_POP[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SHOW_POP__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SHOW_POP__DigitalOutput__ + i, SHOW_POP[i+1] );
    }
    
    POPTIME = new UShortParameter( POPTIME__Parameter__, this );
    m_ParameterList.Add( POPTIME__Parameter__, POPTIME );
    
    POPWAIT_Callback = new WaitFunction( POPWAIT_CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_2___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_2___CallbackFn );
    
    for( uint i = 0; i < 20; i++ )
        CLEAR_POPS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( CLEAR_POPS_OnPush_0, false ) );
        
    for( uint i = 0; i < 198; i++ )
        ALL_POP_BUTTONS[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( ALL_POP_BUTTONS_OnRelease_1, false ) );
        
    for( uint i = 0; i < 15; i++ )
        ENVIRON_POP[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( ALL_POP_BUTTONS_OnRelease_1, false ) );
        
    for( uint i = 0; i < 2; i++ )
        CANCEL_TIMEOUT[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( CANCEL_TIMEOUT_OnPush_2, false ) );
        
    for( uint i = 0; i < 198; i++ )
        ALL_POP_BUTTONS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( ALL_POP_BUTTONS_OnPush_3, false ) );
        
    for( uint i = 0; i < 15; i++ )
        ENVIRON_POP[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( ENVIRON_POP_OnPush_4, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_MND19_ENVIRONMENT_POPUPS_V4 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction POPWAIT_Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_2___Callback;


const uint CLEAR_POPS__DigitalInput__ = 0;
const uint ENVIRON_POP__DigitalInput__ = 20;
const uint ALL_POP_BUTTONS__DigitalInput__ = 35;
const uint CANCEL_TIMEOUT__DigitalInput__ = 233;
const uint SHOW_POP__DigitalOutput__ = 0;
const uint POPTIME__Parameter__ = 10;

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
