using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.LanguageRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.LanguageRepository
{
    public class EfLanguageDal : EfEntityRepositoryBase<Language, SimpleContextDb>, ILanguageDal
    {
    }
}
