using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.StudentRepository.Validation
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
        }
    }
}
