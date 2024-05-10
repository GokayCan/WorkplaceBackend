namespace Entities.Concrete
{
    public class CompanyStaff
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int StaffId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}