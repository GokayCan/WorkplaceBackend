using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.FacultyRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.FacultyRepository
{
    public class EfFacultyDal : EfEntityRepositoryBase<Faculty, SimpleContextDb>, IFacultyDal
    {
    }
}
