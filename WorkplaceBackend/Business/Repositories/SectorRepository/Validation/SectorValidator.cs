using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.SectorRepository.Validation
{
    public class SectorValidator : AbstractValidator<Sector>
    {
        public SectorValidator()
        {
        }
    }
}
