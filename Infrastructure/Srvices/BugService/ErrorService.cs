using System;

namespace PWCreater.Infrastructure.Srvices.BugService
{
    public class ErrorService
    {
        //создал приватный чтоб вызвать нельзя было из вне
        private ErrorService() { }

        private static ErrorService _service;

        public static ErrorService Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new();
                }
                return _service;
            }
        }

        public event EventHandler<ErrorMessage> ErrorOccurred;

        public void ReportError(SystemException errorString)
        {
            ErrorOccurred?.Invoke(this, new ErrorMessage(errorString));
        }
    }
}
