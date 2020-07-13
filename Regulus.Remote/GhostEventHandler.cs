﻿using System;
using System.Collections.Generic;

namespace Regulus.Remote
{
    public class GhostEventHandler
    {
        class Invoker
        {
            public long Id;
            public Delegate Runner                ;
        }
        readonly IdLandlord _IdLandlord;
        readonly List<Invoker> _Runners;
        public GhostEventHandler()
        {
            _IdLandlord = new IdLandlord();
            _Runners = new List<Invoker>();
        }
        internal void Add(Delegate value)
        {
            var id = _IdLandlord.Rent();
            _Runners.Add(new Invoker() { Id = id, Runner = value });
        }

        internal void Remove(Delegate value)
        {
            var invoker = _Runners.Find(i => i.Runner == value);
            _Runners.Remove(invoker);
        }

        public void Invoke(long handler_id , params object[] args)
        {
            var invoker = _Runners.Find(i => i.Id == handler_id);
            if (invoker != null)
                invoker.Runner.DynamicInvoke(args);

        }
    }
}
