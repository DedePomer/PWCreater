using System;

namespace PWCreater.Infrastructure.Srvices.BugService
{
    public class ErrorMessage : EventArgs
    {
        public SystemException NameOfExceptiom { get; }
        public ErrorMessage(SystemException nameOfExceptiom)
        {
            NameOfExceptiom = nameOfExceptiom;
        }
    }
}
