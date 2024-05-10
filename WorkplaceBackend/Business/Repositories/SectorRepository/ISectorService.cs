using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.SectorRepository
{
    public interface ISectorService
    {
        Task<IResult> Add(Sector sector);
        Task<IResult> Update(Sector sector);
        Task<IResult> Delete(Sector sector);
        Task<IDataResult<List<Sector>>> GetList();
        Task<IDataResult<Sector>> GetById(int id);
    }
}
