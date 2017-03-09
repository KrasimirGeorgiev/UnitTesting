namespace Tests.SchoolClasses
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.Homeworks.OOP.Principles.SchoolClasses.Models;
    using Telerik.Homeworks.OOP.Principles.SchoolClasses.Models.Interfaces;
    using Telerik.Homeworks.OOP.Principles.SchoolClasses.Tech;

    [TestClass]
    public class SchoolTests
    {
        public School School { get; private set; }

        [TestInitialize]
        public void BeforeEach()
        {
            var marker = new BrandingIron(Student.MinClassNumber);
            this.School = new School("Batmanovo", marker);
        }

        [TestMethod]
        public void RegisterStudent_WithValidArguments_ReturnsInstance()
        {
            var student = this.School.RegisterStudent("Batman", "OtYambol");

            Assert.IsInstanceOfType(student, typeof(IStudent));
        }

        [TestMethod]
        public void RegisterStudent_RegistersTheStudents_WithUniqueNumbers()
        {
            int count = 101;

            for (int i = 0; i < count; i++)
            {
                this.School.RegisterStudent("Batman" + i, "OtYambol");
            }

            var distinct = this.School.Students
                .Select(s => s.TrackingNumber)
                .Distinct();

            Assert.AreEqual(count, distinct.Count());
        }
    }
}