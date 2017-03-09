namespace Telerik.Homeworks.OOP.Principles.SchoolClasses.Models
{
    using System.Collections.Generic;
    using Models.Interfaces;
    using Validation;

    public class Student : Person, IStudent
    {
        public const int MinClassNumber = 10000;
        public const int MaxClassNumber = 99999;

        public Student(string fname, string lname)
            : base(fname, lname)
        {
            this.SchoolClasses = new HashSet<SchoolClass>();
            this.TrackingNumber = 0;
        }

        public Comment Comment { get; set; }

        public ICollection<SchoolClass> SchoolClasses { get; }

        /// <summary>
        /// Gets the number associated with the implant, secretly added
        /// to the student when he is accepted to a school
        /// If this number is 0 the student has no implant or he's somehow
        /// removed the implant -> In any case examine the student and
        /// give him more homework
        /// </summary>
        /// <value>
        /// Number between <see cref="MinClassNumber"/> and <see cref="MaxClassNumber"/> or 0
        /// </value>
        public int TrackingNumber { get; private set; }

        public void AssignClassNumber(int number)
        {
            this.TrackingNumber = Validator.ValidateNumber(
                number, MinClassNumber, MaxClassNumber);
        }
    }
}
