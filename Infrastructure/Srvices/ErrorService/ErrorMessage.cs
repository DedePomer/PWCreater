using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWCreater.Infrastructure.Srvices.ErrorService
{
    public class ErrorMessage: EventArgs
    {
        public string NameOfError { get; }
        public ErrorMessage(string nameOfError) 
        {
            NameOfError = nameOfError;
        }
    }
}
