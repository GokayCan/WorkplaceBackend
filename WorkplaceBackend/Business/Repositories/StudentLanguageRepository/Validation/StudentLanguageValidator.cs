using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.StudentLanguageRepository.Validation
{
    public class StudentLanguageValidator : AbstractValidator<StudentLanguage>
    {
        public StudentLanguageValidator()
        {
        }
    }
}
