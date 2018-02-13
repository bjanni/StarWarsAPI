using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsMGLT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsMGLT.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ProcessReSupplyTest()
        {
            StarShips starShips = new StarShips();
            var response = starShips.ProcessReSupply(70000);
            Assert.IsTrue(response);
        }
    }
}