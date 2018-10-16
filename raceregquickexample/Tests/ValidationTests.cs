using NUnit.Framework;
using RaceRegQuickExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void ValidateHasSpacesFirstName()
        {
            var myRacer = new Racer();
            myRacer.FirstName = " Alex";

            Assert.AreEqual(myRacer[nameof(myRacer.FirstName)], "First name must contain no spaces, and cannot be empty.");
        }

        [Test]
        public void ValidateHasNoSpacesFirstName()
        {
            var myRacer = new Racer();
            myRacer.FirstName = "Alex";

            Assert.AreEqual(myRacer[nameof(myRacer.FirstName)], null);
        }

        [Test]
        public void ValidateHasSpacesLastName()
        {
            var myRacer = new Racer();
            myRacer.LastName = " Alex";

            Assert.AreEqual(myRacer[nameof(myRacer.LastName)], "Last name must contain no spaces, and cannot be empty.");
        }

        [Test]
        public void ValidateHasNoSpacesLastName()
        {
            var myRacer = new Racer();
            myRacer.LastName = "Alex";

            Assert.AreEqual(myRacer[nameof(myRacer.LastName)], null);
        }

        [Test]
        public void ValidateInvalidAgeLow()
        {
            var myRacer = new Racer();
            myRacer.Age = -1;

            Assert.AreEqual(myRacer[nameof(myRacer.Age)], "Age must be between 1 and 150.");
        }

        [Test]
        public void ValidateInvalidAgeHigh()
        {
            var myRacer = new Racer();
            myRacer.Age = 151;

            Assert.AreEqual(myRacer[nameof(myRacer.Age)], "Age must be between 1 and 150.");
        }

        [Test]
        public void ValidateValidAge()
        {
            var myRacer = new Racer();
            myRacer.Age = 50;

            Assert.AreEqual(myRacer[nameof(myRacer.Age)], null);
        }

        [Test]
        public void ValidateInvalidGender()
        {
            var myRacer = new Racer();
            myRacer.Gender = (Racer.GenderType)150;

            Assert.AreEqual(myRacer[nameof(myRacer.Gender)], "Gender must be Male, Female or Other.");
        }

        [Test]
        public void ValidateValidGender()
        {
            var myRacer = new Racer();
            myRacer.Gender = Racer.GenderType.Other;

            Assert.AreEqual(myRacer[nameof(myRacer.Gender)], null);
        }

        [Test]
        public void ValidateAll()
        {
            var myRacer = new Racer();

            Assert.AreEqual(myRacer.IsValid, true);
        }
    }
}
