namespace Tests.SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.Homeworks.OOP.Principles.SchoolClasses;
    using Telerik.Homeworks.OOP.Principles.SchoolClasses.Models;
    using Telerik.Homeworks.OOP.Principles.SchoolClasses.Models.Interfaces;

    [TestClass]
    public class SchoolClassTests
    {
        [TestMethod]
        public void CreatingSchoolClass_WithTheDefaultConstructor_CreatesEmptyClass()
        {
            var schoolClass = new SchoolClass();

            Assert.AreEqual(0, schoolClass.Size);
        }

        [TestMethod]
        public void CreatingSchoolClass_WithStudentAndTeacherCollections_InitializesStudentCollectionWithValues()
        {
            var students = new IStudent[6];

            int id = 10000;

            for (int i = 0; i < students.Length; i++)
            {
                var student = this.CreateStudent(id + i);
                students[i] = student;
            }

            var schoolClass = new SchoolClass(students, new List<Teacher>());

            Assert.IsTrue(schoolClass.Students.Count == students.Length);
        }

        [TestMethod]
        public void AddStudent_ToAnEmptySchoolClass_IncreasesStudentsCount()
        {
            var schoolClass = new SchoolClass();
            var student = this.CreateStudent(10000);

            schoolClass.AddStudent(student);

            Assert.AreEqual(1, schoolClass.Size);
        }

        [TestMethod]
        public void RemoveStudent_DecreasesStudentsCount()
        {
            var schoolClass = new SchoolClass();
            var student = this.CreateStudent(10000);

            schoolClass.AddStudent(student);
            schoolClass.RemoveStudent(student.TrackingNumber);

            Assert.AreEqual(0, schoolClass.Size);
        }

        [TestMethod]
        public void AddStudent_AddsToTheStudentCollection()
        {
            var schoolClass = new SchoolClass();
            var student = this.CreateStudent(10000);

            schoolClass.AddStudent(student);

            Assert.IsTrue(schoolClass.Students.Contains(student));
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void AddStudent_ToFullClass_Throws()
        {
            var schoolClass = new SchoolClass();

            int start = 10000;
            int stop = 10000 + SchoolClass.MaxStudentsInClass + 1;

            for (int i = start; i <= stop; i++)
            {
                var student = this.CreateStudent(i);
                schoolClass.AddStudent(student);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudent_AlreadyInTheClass_Throws()
        {
            var schoolClass = new SchoolClass();

            var student = this.CreateStudent(10000);

            schoolClass.AddStudent(student);
            schoolClass.AddStudent(student);
        }

        [TestMethod]
        public void AddStudents_AddsAllStudents_ToTheCollection()
        {
            var schoolClass = new SchoolClass();
            var students = new IStudent[6];

            int id = 10000;

            for (int i = 0; i < students.Length; i++)
            {
                var student = this.CreateStudent(id + i);
                students[i] = student;
            }

            schoolClass.AddStudents(students);

            foreach (var student in students)
            {
                Assert.IsTrue(schoolClass.Students.Contains(student));
            }
        }

        [TestMethod]
        public void RemoveStudent_WithValidParameter_RemovesHimFtomTheClass()
        {
            var schoolClass = new SchoolClass();

            var student = this.CreateStudent(10000);

            schoolClass.AddStudent(student);
            schoolClass.RemoveStudent(student.TrackingNumber);

            Assert.IsFalse(schoolClass.Students.Contains(student));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveStudent_NotInTheClass_Throws()
        {
            var schoolClass = new SchoolClass();
            var student = this.CreateStudent(10000);

            schoolClass.AddStudent(student);
            schoolClass.RemoveStudent(10001);
        }

        private IStudent CreateStudent(int id)
        {
            var student = new Student("Batman" + id, "OtYambol" + id);
            student.AssignClassNumber(id);

            return student;
        }
    }
}