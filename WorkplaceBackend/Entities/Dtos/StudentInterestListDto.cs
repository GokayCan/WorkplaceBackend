using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class StudentInterestListDto : StudentInterest
    {
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set;}
        public string InterestName { get; set;}

    }
}
