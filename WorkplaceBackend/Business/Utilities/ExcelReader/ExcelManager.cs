using Business.Repositories.CompanyRepository;
using Business.Repositories.UserRepository;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.ExcelReader
{
    public class ExcelManager:IExcelService
    {
        public async Task<IDataResult<List<Company>>> WorkPlaceAddWithExcelFile(string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            List<Company> companyList = new List<Company>();

            using (var stream = System.IO.File.Open(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        var companyName = reader.GetValue(1) == null ? "" : reader.GetValue(1).ToString().ToLower();
                        var cluster = reader.GetValue(2) == null ? "" : reader.GetValue(2).ToString().ToLower();
                        //var studentHiredFrom = reader.GetValue(3).ToString().ToLower();
                        var contactInfo = reader.GetValue(4) ==null ? "": reader.GetValue(4).ToString().ToLower();
                        //var responsible = reader.GetValue(5).ToString().ToLower();
                        var webPage = reader.GetValue(6) == null ? "" : reader.GetValue(6).ToString().ToLower();
                        // var exception = reader.GetValue(7).ToString().ToLower();

                        //kızlık soyadı ve iki ismi olanları aynı zamanda türkçe karakter içerenleri düzelttiğim yer
                        //var normalizedFirstName = RemoveSpacesAndNormalize(responsible);

                        var company = new Company
                        {
                            Name = companyName,
                            //Sector = cluster,
                            WebPage = webPage,
                            Address = contactInfo,
                        };

                        companyList.Add(company);

                    }
                }
            }

            return new SuccessDataResult<List<Company>>(companyList);
        }

        private string RemoveSpacesAndNormalize(string text)
        {
            var normalizedText = text
                .Replace("ı", "i")
                .Replace("i̇", "i")
                .Replace("ö", "o")
                .Replace("ü", "u")
                .Replace("ğ", "g")
                .Replace("ş", "s")
                .Replace("ç", "c");

            return normalizedText.Replace(" ", string.Empty);
        }

    }
}
