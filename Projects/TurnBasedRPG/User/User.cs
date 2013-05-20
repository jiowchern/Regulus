﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Regulus.Project.TurnBasedRPG
{
    public class User : Samebest.Game.IFramework
    {
        public Samebest.Remoting.Ghost.Agent Complex { get; private set; }

        public event Action LinkSuccess;
        public event Action LinkFail;
        public User(Samebest.Remoting.Ghost.Config config )
        {
            Complex = new Samebest.Remoting.Ghost.Agent(config); 
        }

        void Samebest.Game.IFramework.Launch()
        {
            var linkStatu = new Samebest.Remoting.Ghost.LinkState();
            linkStatu.LinkSuccess += () =>
            {                
                LinkSuccess();
            };
            linkStatu.LinkFail += () =>
            {
                LinkFail();
            };

            Complex.Launch(linkStatu);
        }

        bool Samebest.Game.IFramework.Update()
        {
            return Complex.Update();
        }

        void Samebest.Game.IFramework.Shutdown()
        {
            Complex.Shutdown();
        }


    }
}