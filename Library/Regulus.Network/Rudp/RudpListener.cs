﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Regulus.Network.RUDP;

namespace Regulus.Network
{
    public class RudpListener : ISocketLintenable
    {
        private Host _Host;
        private bool _Enable;
        private event Action<ISocket> _AcctpeEvent;
        event Action<ISocket> ISocketLintenable.AcceptEvent
        {
            add { _AcctpeEvent += value; }
            remove { _AcctpeEvent -= value; }
        }

        void ISocketLintenable.Bind(int port)
        {
            _Host = Host.CreateStandard(port);
            _Host.AcceptEvent += _Accept;
            _Enable = true;
            ThreadPool.QueueUserWorkItem(_Run, null);
        }

        private void _Run(object state)
        {
            var updater = new Regulus.Utility.Updater<Timestamp>();
            updater.Add(_Host);


            var now = System.DateTime.Now.Ticks;
            var last = now ;
            while (_Enable)
            {
                now = System.DateTime.Now.Ticks;
                updater.Working(new Timestamp(now , now-last));
                last = now;
            }

            updater.Shutdown();

        }

        private void _Accept(IPeer peer)
        {
            _AcctpeEvent(new RudpSocket(peer));
        }

        void ISocketLintenable.Close()
        {
            _Host.AcceptEvent -= _Accept;
            _Enable = false;
        }
    }
}
