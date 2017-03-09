namespace Telerik.Homeworks.OOP.Principles.SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class SchoolClass
    {
        public const int MaxStudentsInClass = 30;

        private readonly Dictionary<int, IStudent> studentsByNumber;

        public SchoolClass()
        {
            this.Teachers = new HashSet<Teacher>();
            this.studentsByNumber = new Dictionary<int, IStudent>();
        }

        public int Size => this.studentsByNumber.Count;

        public SchoolClass(IEnumerable<IStudent> students, IEnumerable<Teacher> teachers)
        {
            this.studentsByNumber = new Dictionary<int, IStudent>();
            this.AddStudents(students.ToArray());

            this.Teachers = new HashSet<Teacher>(teachers);
        }

        public ICollection<IStudent> Students => this.studentsByNumber.Values;

        public ICollection<Teacher> Teachers { get; }

        public Comment Comment { get; set; }

        public void AddStudent(IStudent student)
        {
            if (this.studentsByNumber.ContainsKey(student.TrackingNumber))
            {
                throw new ArgumentException("Student with the given number is already in the class");
            }
            else if (this.studentsByNumber.Count == MaxStudentsInClass)
            {
                throw new ApplicationException("The class is already full");
            }

            this.studentsByNumber.Add(student.TrackingNumber, student);
            student.SchoolClasses.Add(this);
        }

        public void AddStudents(params IStudent[] newStudents)
        {
            foreach (var student in newStudents)
            {
                this.AddStudent(student);
            }
        }

        public IStudent RemoveStudent(int classNumber)
        {
            if (!this.studentsByNumber.ContainsKey(classNumber))
            {
                throw new ArgumentException("No student found with the given class number");
            }

            var student = this.studentsByNumber[classNumber];

            this.studentsByNumber.Remove(classNumber);
            student.SchoolClasses.Remove(this);

            return student;
        }
    }
}
