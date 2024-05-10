namespace Entities.Concrete
{
    public class CompanyResponsible
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ResponsibleId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}