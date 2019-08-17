using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public interface IErrorModel
    {
        int ErrorNumber { get; set; }
        string Description { get; set; }
        void SendMail();
    }

    public class DbError
        : IErrorModel
    {
        private int _errorNumber;
        private string _description;

        public int ErrorNumber { get => _errorNumber; set => _errorNumber = value; }

        public string Description { get => _description; set => _description = value; }

        public void SendMail()
        {
            Console.WriteLine("{0} {1} Db hatası gönderildi", ErrorNumber, Description);
        }
    }

    public class ServiceError : IErrorModel
    {
        private int _errorNumber;
        private string _description;

        public int ErrorNumber { get => _errorNumber; set => _errorNumber = value; }

        public string Description { get => _description; set => _description = value; }

        public void SendMail()
        {
            Console.WriteLine("{0} {1} Servis hatası gönderildi", ErrorNumber, Description);
        }
    }

    //Adapter class
    public class FaxAdapter : IErrorModel
    {
        private Fax _fax;
        public FaxAdapter(Fax fax)
        {
            _fax = fax;
        }
        public int ErrorNumber { get => _fax.FaxErrorCode; set => _fax.FaxErrorCode = value; }
        public string Description { get => _fax.ErrorDescription; set => _fax.ErrorDescription = value; }

        public void SendMail()
        {
            Console.WriteLine("{0} {1} Fax hatası alındı.", ErrorNumber, Description);
        }
    }

    //Adapter
    public class Fax
    {
        public int FaxErrorCode { get; set; }
        public string ErrorDescription { get; set; }

        void Send()
        {
        }

        void Get()
        {
        }
    }
}
