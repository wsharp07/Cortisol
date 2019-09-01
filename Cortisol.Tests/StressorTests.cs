using System;
using System.Diagnostics;
using Telerik.JustMock;
using Xunit;

namespace Cortisol.Tests
{
    public class StressorTests
    {
        [Fact]
        public void InduceAction_10Times_ExpectInvoke10Times()
        {
            int times = 10;
            var sut = Mock.Create<Action>();
            

            var st = new Stressor()
                .RunTimes(times)
                .ActOn(sut)
                .Induce();
            
            Mock.Assert(() => sut.Invoke(), Occurs.Exactly(times));

        }
        
    }
}