using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.ExcelReader
{
    public interface IExcelService
    {
        Task<IDataResult<List<Company>>> WorkPlaceAddWithExcelFile(string filePath);
    }
}
