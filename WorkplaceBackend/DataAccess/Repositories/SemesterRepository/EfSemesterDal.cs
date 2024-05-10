using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.SemesterRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.SemesterRepository
{
    public class EfSemesterDal : EfEntityRepositoryBase<Semester, SimpleContextDb>, ISemesterDal
    {
    }
}
