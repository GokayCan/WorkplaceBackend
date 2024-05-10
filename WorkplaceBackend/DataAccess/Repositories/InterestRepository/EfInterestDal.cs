using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.InterestRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.InterestRepository
{
    public class EfInterestDal : EfEntityRepositoryBase<Interest, SimpleContextDb>, IInterestDal
    {
    }
}
