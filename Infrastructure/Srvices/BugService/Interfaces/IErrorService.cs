using System;

namespace PWCreater.Infrastructure.Srvices.BugService.Interfaces
{
    public interface IErrorService
    {
        event EventHandler<ErrorMessage> ErrorOccurred;
        void ReportError(SystemException errorString);
    }
}
