using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.CompanyRepository.Constants
{
    public class CompanyMessages
    {
        public static string AlreadyExists = "Kayıt zaten mevcut";
        public static string Listed = "Listeleme işlemi başarılı";
        public static string Added = "Kayıt işlemi başarılı";
        public static string Updated = "Güncelleme işlemi başarılı";
        public static string Deleted = "Silme işlemi başarılı";
    }
}