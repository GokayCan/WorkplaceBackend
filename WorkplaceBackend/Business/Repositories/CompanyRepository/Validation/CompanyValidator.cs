using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.CompanyRepository.Validation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
        }
    }
}
