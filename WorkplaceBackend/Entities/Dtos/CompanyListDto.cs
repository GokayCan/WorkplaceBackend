using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CompanyListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SectorId { get; set; }
        public string SectorName { get; set; }
        public string WebPage { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsiblePhoneNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ProtocolPersonel { get; set; }
        public DateTime ProtocolDate { get; set; }
        public bool IsActive { get; set; }
    }
}
