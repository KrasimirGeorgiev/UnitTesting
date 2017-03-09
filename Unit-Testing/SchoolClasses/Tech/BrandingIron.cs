namespace Telerik.Homeworks.OOP.Principles.SchoolClasses.Tech
{
    using Models.Interfaces;

    public class BrandingIron : IImplantator
    {
        private int nextId;

        public BrandingIron(int initialId)
        {
            this.nextId = initialId;
        }

        public void Mark(IStudent student)
        {
            student.AssignClassNumber(this.nextId);
            this.nextId++;
        }
    }
}
