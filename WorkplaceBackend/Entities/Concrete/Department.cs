namespace Entities.Concrete
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public bool IsActive { get; set; }
    }
}
