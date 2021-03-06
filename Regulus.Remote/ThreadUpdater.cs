﻿using Regulus.Utility;
using System.Threading;
using System.Threading.Tasks;

namespace Regulus.Remote
{
    public class ThreadUpdater
    {
        private readonly System.Action _Updater;
        
        private CancellationTokenSource _Cancel;
        private Task _Task;        

        public ThreadUpdater(System.Action updater)
        {
            _Updater = updater;            
        }

        void _Update(CancellationToken token)
        {
            AutoPowerRegulator regulator = new AutoPowerRegulator(new PowerRegulator());
            
            while (!token.IsCancellationRequested)
            {
                _Updater();
                regulator.Operate();
            }

        }
        public void Start()
        {

            _Cancel = new CancellationTokenSource();
            
            _Task = System.Threading.Tasks.Task.Factory.StartNew(()=>_Update(_Cancel.Token),TaskCreationOptions.LongRunning);

        }

        public void Stop()
        {
            _Cancel.Cancel();            
            _Task.Wait();
            _Cancel.Dispose();
        }
    }
}
