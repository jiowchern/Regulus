﻿using System;

namespace Regulus.Remote.Client
{
    public class Provider
    {
        public static Regulus.Remote.Client.Tcp.Connecter CreateTcp(Ghost.IAgent agent)
        {
            
            return new Regulus.Remote.Client.Tcp.Connecter(agent);
        }
        public static Ghost.IAgent CreateAgent(IProtocol protocol)
        {
            return new Ghost.Agent(protocol);
        }

        public static Standalone.IService CreateService(IProtocol protocol, IEntry entry)
        {
            return new Standalone.Service(entry , protocol);
        }
    }
}