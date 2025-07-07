using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWCreater.Infrastructure.Srvices.BugService
{
    public class ErrorMessage: EventArgs
    {
        public SystemException NameOfExceptiom { get; }
        public ErrorMessage(SystemException nameOfExceptiom) 
        {
            NameOfExceptiom = nameOfExceptiom;
        }
    }
}
