namespace Telerik.Homeworks.OOP.Principles.SchoolClasses.Models
{
    using System.Collections.Generic;
    using Interfaces;
    using Tech;
    using Validation;

    public class School
    {
        private readonly IImplantator implantator;
        private readonly Dictionary<int, IStudent> studentsByNumber;

        private string name;

        public School(string name, IImplantator imlantator)
        {
            this.Name = name;
            this.Classes = new List<SchoolClass>();
            this.studentsByNumber = new Dictionary<int, IStudent>();
            this.implantator = imlantator;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = Validator.ValidateName(value);
            }
        }

        public IList<SchoolClass> Classes { get; private set; }

        public ICollection<IStudent> Students => this.studentsByNumber.Values;

        public void AddStudent(IStudent student, SchoolClass schoolClass)
        {
            schoolClass.AddStudent(student);
        }

        public IStudent RegisterStudent(string firstName, string lastName)
        {
            var student = new Student(firstName, lastName);
            this.implantator.Mark(student);
            this.studentsByNumber.Add(student.TrackingNumber, student);

            return student;
        }
    }
}
