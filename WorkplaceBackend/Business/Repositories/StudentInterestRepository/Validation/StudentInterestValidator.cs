using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.StudentInterestRepository.Validation
{
    public class StudentInterestValidator : AbstractValidator<StudentInterest>
    {
        public StudentInterestValidator()
        {
        }
    }
}
