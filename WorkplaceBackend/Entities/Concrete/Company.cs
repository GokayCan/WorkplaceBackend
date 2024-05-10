namespace Entities.Concrete
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SectorId { get; set; }
        public string WebPage { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsiblePhoneNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ProtocolPersonel { get; set; }
        public DateTime ProtocolDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}