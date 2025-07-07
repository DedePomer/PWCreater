using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWCreater.Infrastructure.Srvices.BugService.Interfaces
{
    public interface IErrorService
    {
        event EventHandler<ErrorMessage> ErrorOccurred;
        void ReportError(SystemException errorString);
    }
}
