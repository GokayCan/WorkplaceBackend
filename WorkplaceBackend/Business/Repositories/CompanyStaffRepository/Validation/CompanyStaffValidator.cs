using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.CompanyStaffRepository.Validation
{
    public class CompanyStaffValidator : AbstractValidator<CompanyStaff>
    {
        public CompanyStaffValidator()
        {
        }
    }
}
