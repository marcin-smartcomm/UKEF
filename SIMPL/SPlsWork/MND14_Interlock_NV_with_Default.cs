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

namespace UserModule_MND14_INTERLOCK_NV_WITH_DEFAULT
{
    public class UserModuleClass_MND14_INTERLOCK_NV_WITH_DEFAULT : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CLEAR;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> IN;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> OUT;
        UShortParameter DEFAULTHIGH;
        ushort N = 0;
        ushort Q = 0;
        ushort MAXNUM = 0;
        ushort NOTZEROCOUNT = 0;
        private void RECONCILE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 71;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)MAXNUM; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( N  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (N  >= __FN_FORSTART_VAL__1) && (N  <= __FN_FOREND_VAL__1) ) : ( (N  <= __FN_FORSTART_VAL__1) && (N  >= __FN_FOREND_VAL__1) ) ; N  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 73;
                OUT [ N]  .Value = (ushort) ( _SplusNVRAM.OUTMEM[ N ] ) ; 
                __context__.SourceCodeLine = 71;
                } 
            
            
            }
            
        object IN_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 79;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)MAXNUM; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( N  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (N  >= __FN_FORSTART_VAL__1) && (N  <= __FN_FOREND_VAL__1) ) : ( (N  <= __FN_FORSTART_VAL__1) && (N  >= __FN_FOREND_VAL__1) ) ; N  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 81;
                    _SplusNVRAM.OUTMEM [ N] = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 79;
                    } 
                
                __context__.SourceCodeLine = 83;
                _SplusNVRAM.OUTMEM [ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )] = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 84;
                RECONCILE (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object CLEAR_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 88;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)MAXNUM; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( N  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (N  >= __FN_FORSTART_VAL__1) && (N  <= __FN_FOREND_VAL__1) ) : ( (N  <= __FN_FORSTART_VAL__1) && (N  >= __FN_FOREND_VAL__1) ) ; N  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 90;
                _SplusNVRAM.OUTMEM [ N] = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 88;
                } 
            
            __context__.SourceCodeLine = 92;
            RECONCILE (  __context__  ) ; 
            
            
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
        
        __context__.SourceCodeLine = 107;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 109;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)255; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( N  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (N  >= __FN_FORSTART_VAL__1) && (N  <= __FN_FOREND_VAL__1) ) : ( (N  <= __FN_FORSTART_VAL__1) && (N  >= __FN_FOREND_VAL__1) ) ; N  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 111;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( IN[ N ] ))  ) ) 
                { 
                __context__.SourceCodeLine = 113;
                MAXNUM = (ushort) ( N ) ; 
                __context__.SourceCodeLine = 114;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.OUTMEM[ N ] != 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 114;
                    NOTZEROCOUNT = (ushort) ( (NOTZEROCOUNT + 1) ) ; 
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 116;
                if ( Functions.TestForTrue  ( ( Functions.Not( IsSignalDefined( IN[ N ] ) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 118;
                    break ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 109;
            } 
        
        __context__.SourceCodeLine = 122;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NOTZEROCOUNT == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 124;
            if ( Functions.TestForTrue  ( ( DEFAULTHIGH  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 124;
                _SplusNVRAM.OUTMEM [ DEFAULTHIGH  .Value] = (ushort) ( 1 ) ; 
                }
            
            } 
        
        __context__.SourceCodeLine = 126;
        RECONCILE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.OUTMEM  = new ushort[ 256 ];
    _SplusNVRAM.CHECK  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    
    CLEAR = new Crestron.Logos.SplusObjects.DigitalInput( CLEAR__DigitalInput__, this );
    m_DigitalInputList.Add( CLEAR__DigitalInput__, CLEAR );
    
    IN = new InOutArray<DigitalInput>( 255, this );
    for( uint i = 0; i < 255; i++ )
    {
        IN[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( IN__DigitalInput__ + i, IN__DigitalInput__, this );
        m_DigitalInputList.Add( IN__DigitalInput__ + i, IN[i+1] );
    }
    
    OUT = new InOutArray<DigitalOutput>( 255, this );
    for( uint i = 0; i < 255; i++ )
    {
        OUT[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( OUT__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( OUT__DigitalOutput__ + i, OUT[i+1] );
    }
    
    DEFAULTHIGH = new UShortParameter( DEFAULTHIGH__Parameter__, this );
    m_ParameterList.Add( DEFAULTHIGH__Parameter__, DEFAULTHIGH );
    
    
    for( uint i = 0; i < 255; i++ )
        IN[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( IN_OnPush_0, false ) );
        
    CLEAR.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLEAR_OnPush_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_MND14_INTERLOCK_NV_WITH_DEFAULT ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint CLEAR__DigitalInput__ = 0;
const uint IN__DigitalInput__ = 1;
const uint OUT__DigitalOutput__ = 0;
const uint DEFAULTHIGH__Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public CrestronString CHECK;
            [SplusStructAttribute(1, false, true)]
            public ushort [] OUTMEM;
            
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
