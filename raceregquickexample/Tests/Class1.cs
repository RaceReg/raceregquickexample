using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RaceRegQuickExample.ViewModel;

namespace Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void ExportRaceTest()
        {
            var myModel = new ViewModel();

            Assert.AreEqual(myModel.ExportRace(), "Test");
        }
    }
}
