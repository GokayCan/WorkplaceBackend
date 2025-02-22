using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.ProgrammingRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.ProgrammingRepository
{
    public class EfProgrammingDal : EfEntityRepositoryBase<Programming, SimpleContextDb>, IProgrammingDal
    {
    }
}
