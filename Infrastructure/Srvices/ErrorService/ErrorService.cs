using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWCreater.Infrastructure.Srvices.ErrorService.Interfaces;

namespace PWCreater.Infrastructure.Srvices.ErrorService
{
    public class ErrorService : IErrorService
    {
        //создал приватный чтоб вызвать нельзя было из вне
        private ErrorService() { }  

        public static ErrorService Service = new ErrorService();

        public event EventHandler<ErrorMessage> ErrorOccurred;

        public void ReportError(string errorString)
        {
            ErrorOccurred?.Invoke(this, new ErrorMessage(errorString));
        }
    }
}
