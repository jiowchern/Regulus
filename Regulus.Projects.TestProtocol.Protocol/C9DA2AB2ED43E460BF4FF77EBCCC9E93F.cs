
            using System;  
            using System.Collections.Generic;
            
            
                public class C9DA2AB2ED43E460BF4FF77EBCCC9E93F : Regulus.Remote.IProtocol
                {
                    readonly Regulus.Remote.InterfaceProvider _InterfaceProvider;
                    readonly Regulus.Remote.EventProvider _EventProvider;
                    readonly Regulus.Remote.MemberMap _MemberMap;
                    readonly Regulus.Serialization.ISerializer _Serializer;
                    readonly System.Reflection.Assembly _Base;
                    public C9DA2AB2ED43E460BF4FF77EBCCC9E93F()
                    {
                        _Base = System.Reflection.Assembly.Load("Regulus.Projects.TestProtocol.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                        var types = new Dictionary<Type, Type>();
                        types.Add(typeof(Regulus.Projects.TestProtocol.Common.INext) , typeof(Regulus.Projects.TestProtocol.Common.Ghost.CINext) );
types.Add(typeof(Regulus.Projects.TestProtocol.Common.INumber) , typeof(Regulus.Projects.TestProtocol.Common.Ghost.CINumber) );
types.Add(typeof(Regulus.Projects.TestProtocol.Common.ISample) , typeof(Regulus.Projects.TestProtocol.Common.Ghost.CISample) );
                        _InterfaceProvider = new Regulus.Remote.InterfaceProvider(types);
                        var eventClosures = new List<Regulus.Remote.IEventProxyCreator>();
                        eventClosures.Add(new Regulus.Projects.TestProtocol.Common.Invoker.ISample.IntsEvent() );
                        _EventProvider = new Regulus.Remote.EventProvider(eventClosures);
                        _Serializer = new Regulus.Serialization.Serializer(new Regulus.Serialization.DescriberBuilder(typeof(Regulus.Projects.TestProtocol.Common.Number),typeof(Regulus.Projects.TestProtocol.Common.Sample),typeof(Regulus.Remote.ClientToServerOpCode),typeof(Regulus.Remote.PackageAddEvent),typeof(Regulus.Remote.PackageCallMethod),typeof(Regulus.Remote.PackageErrorMethod),typeof(Regulus.Remote.PackageInvokeEvent),typeof(Regulus.Remote.PackageLoadSoul),typeof(Regulus.Remote.PackageLoadSoulCompile),typeof(Regulus.Remote.PackagePropertySoul),typeof(Regulus.Remote.PackageProtocolSubmit),typeof(Regulus.Remote.PackageRelease),typeof(Regulus.Remote.PackageRemoveEvent),typeof(Regulus.Remote.PackageReturnValue),typeof(Regulus.Remote.PackageSetProperty),typeof(Regulus.Remote.PackageSetPropertyDone),typeof(Regulus.Remote.PackageUnloadSoul),typeof(Regulus.Remote.RequestPackage),typeof(Regulus.Remote.ResponsePackage),typeof(Regulus.Remote.ServerToClientOpCode),typeof(System.Boolean),typeof(System.Byte[]),typeof(System.Byte[][]),typeof(System.Char),typeof(System.Char[]),typeof(System.Int32),typeof(System.Int64),typeof(System.String)).Describers);
                        _MemberMap = new Regulus.Remote.MemberMap(new System.Reflection.MethodInfo[] {new Regulus.Utility.Reflection.TypeMethodCatcher((System.Linq.Expressions.Expression<System.Action<Regulus.Projects.TestProtocol.Common.INext>>)((ins) => ins.Next())).Method,new Regulus.Utility.Reflection.TypeMethodCatcher((System.Linq.Expressions.Expression<System.Action<Regulus.Projects.TestProtocol.Common.ISample,System.Int32,System.Int32>>)((ins,_1,_2) => ins.Add(_1,_2))).Method,new Regulus.Utility.Reflection.TypeMethodCatcher((System.Linq.Expressions.Expression<System.Action<Regulus.Projects.TestProtocol.Common.ISample,System.Int32>>)((ins,_1) => ins.RemoveNumber(_1))).Method} ,new System.Reflection.EventInfo[]{ typeof(Regulus.Projects.TestProtocol.Common.ISample).GetEvent("IntsEvent") }, new System.Reflection.PropertyInfo[] {typeof(Regulus.Projects.TestProtocol.Common.INumber).GetProperty("Value"),typeof(Regulus.Projects.TestProtocol.Common.ISample).GetProperty("LastValue"),typeof(Regulus.Projects.TestProtocol.Common.ISample).GetProperty("Numbers") }, new System.Tuple<System.Type, System.Func<Regulus.Remote.IProvider>>[] {new System.Tuple<System.Type, System.Func<Regulus.Remote.IProvider>>(typeof(Regulus.Projects.TestProtocol.Common.INext),()=>new Regulus.Remote.TProvider<Regulus.Projects.TestProtocol.Common.INext>()),new System.Tuple<System.Type, System.Func<Regulus.Remote.IProvider>>(typeof(Regulus.Projects.TestProtocol.Common.INumber),()=>new Regulus.Remote.TProvider<Regulus.Projects.TestProtocol.Common.INumber>()),new System.Tuple<System.Type, System.Func<Regulus.Remote.IProvider>>(typeof(Regulus.Projects.TestProtocol.Common.ISample),()=>new Regulus.Remote.TProvider<Regulus.Projects.TestProtocol.Common.ISample>())});
                    }
                    System.Reflection.Assembly Regulus.Remote.IProtocol.Base => _Base;
                    byte[] Regulus.Remote.IProtocol.VerificationCode { get { return new byte[]{157,162,171,46,212,62,70,11,244,255,119,235,204,201,233,63};} }
                    Regulus.Remote.InterfaceProvider Regulus.Remote.IProtocol.GetInterfaceProvider()
                    {
                        return _InterfaceProvider;
                    }

                    Regulus.Remote.EventProvider Regulus.Remote.IProtocol.GetEventProvider()
                    {
                        return _EventProvider;
                    }

                    Regulus.Serialization.ISerializer Regulus.Remote.IProtocol.GetSerialize()
                    {
                        return _Serializer;
                    }

                    Regulus.Remote.MemberMap Regulus.Remote.IProtocol.GetMemberMap()
                    {
                        return _MemberMap;
                    }
                    
                }
            
            