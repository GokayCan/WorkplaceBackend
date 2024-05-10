namespace Entities.Concrete
{
    public class CompanyStudent
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int StudentId { get; set; }
        public int CreatedBy { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}