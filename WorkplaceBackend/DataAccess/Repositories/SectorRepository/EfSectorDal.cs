using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.SectorRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.SectorRepository
{
    public class EfSectorDal : EfEntityRepositoryBase<Sector, SimpleContextDb>, ISectorDal
    {
    }
}
