namespace Tests.SchoolClasses
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.Homeworks.OOP.Principles.SchoolClasses.Models;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Student_CreateWithValidNames_Works()
        {
            var student = new Student("Batman", "Batmanov");

            var fullname = student.FirstName + " " + student.LastName;

            Assert.AreEqual("Batman Batmanov", fullname);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Student_CreateWithEmptyFirstName_Throws()
        {
            var student = new Student("", "Batmanov");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Student_CreateWithEmptyLastName_Throws()
        {
            var student = new Student("Batman", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Student_CreateWithBlankFirstName_Throws()
        {
            var student = new Student("       ", "Batmanov");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Student_CreateWithBlankLastName_Throws()
        {
            var student = new Student("Batman", "  ");
        }

        [TestMethod]
        public void Student_AssingValidNumber_Works()
        {
            var student = new Student("Batman", "Batmanov");
            var number = 10001;

            student.AssignClassNumber(number);

            Assert.AreEqual(number, student.TrackingNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Student_AssingNumberBellow10000_Throws()
        {
            var student = new Student("Batman", "Batmanov");
            var number = 10000 - 1;

            student.AssignClassNumber(number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Student_AssingNumberAbove99999_Throws()
        {
            var student = new Student("Batman", "Batmanov");
            var number = 99999 + 1;

            student.AssignClassNumber(number);
        }
    }
}
