namespace Telerik.Homeworks.OOP.Principles.SchoolClasses.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IStudent
    {
        int TrackingNumber { get; }

        string FirstName { get; }

        string LastName { get; }

        Comment Comment { get; }

        ICollection<SchoolClass> SchoolClasses { get; }

        void AssignClassNumber(int number);
    }
}
