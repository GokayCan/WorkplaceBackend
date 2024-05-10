using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.CompanyStudentRepository.Validation
{
    public class CompanyStudentValidator : AbstractValidator<CompanyStudent>
    {
        public CompanyStudentValidator()
        {
        }
    }
}
