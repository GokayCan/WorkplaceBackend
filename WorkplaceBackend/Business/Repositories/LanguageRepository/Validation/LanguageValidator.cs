using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.LanguageRepository.Validation
{
    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
        }
    }
}
