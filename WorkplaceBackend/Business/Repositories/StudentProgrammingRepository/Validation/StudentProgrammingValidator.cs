using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.StudentProgrammingRepository.Validation
{
    public class StudentProgrammingValidator : AbstractValidator<StudentProgramming>
    {
        public StudentProgrammingValidator()
        {
        }
    }
}
