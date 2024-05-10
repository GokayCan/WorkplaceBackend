using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.ProgrammingRepository.Validation
{
    public class ProgrammingValidator : AbstractValidator<Programming>
    {
        public ProgrammingValidator()
        {
        }
    }
}
