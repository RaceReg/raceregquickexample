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

            Assert.AreEqual(myModel.ExportRace(), "TestRace;10/16/2018;This is crazy.;\nAlex;Thayn;25;Male;1/1/0001\n");
        }

        [Test]
        public void AddRacerTest()
        {
            var myModel = new ViewModel();
            myModel.currentRacer.FirstName = "Jackson";
            myModel.currentRacer.LastName = "Porter";
            myModel.currentRacer.Age = 21;
            myModel.currentRacer.Gender = "Male";
            myModel.AddRacer(null);

            Assert.AreEqual(myModel.ExportRace(), "TestRace;10/16/2018;This is crazy.;\nAlex;Thayn;25;Male;1/1/0001\nJackson;Porter;21;Male;1/1/0001\n");
        }
    }
}
