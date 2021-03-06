﻿using Xunit;

using Regulus.Remote.Reactive;
using System.Reactive.Linq;

namespace Regulus.Remote.Standalone.Test
{
    public class StandaloneTest
    {

        
        [Fact(Timeout =5000)]
        
        public void Test()
        {
            
            var env = new TestEnv<SampleEntry>(new SampleEntry());

            var obs = from sample in env.Queryable.QueryNotifier<Projects.TestProtocol.Common.ISample>().SupplyEvent()
                        select sample;
            var s = obs.FirstAsync().Wait();

            env.Dispose();


            Xunit.Assert.True(true);
            

        }
        
        

        
    }
}
