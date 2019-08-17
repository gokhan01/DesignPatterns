using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Fax fax = new Fax { FaxErrorCode = 10, ErrorDescription = "Hata." };

            IErrorModel[] errors =
            {
                new DbError{ErrorNumber=1000,Description="Bağlantı sağlanamadı."},
                new DbError{ErrorNumber=1001,Description="Sorgulama hatası."},
                new ServiceError{ErrorNumber=1000,Description="Servis bulunamadı."},
                new FaxAdapter(fax)
            };

            foreach (var error in errors)
            {
                error.SendMail();
            }

            Console.ReadKey();
        }
    }
}
