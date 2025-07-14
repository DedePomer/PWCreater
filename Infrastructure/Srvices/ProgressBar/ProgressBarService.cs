using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWCreater.Infrastructure.Srvices.ProgressBar
{
    public class ProgressBarService
    {
        private ProgressBarService() { }

        private ProgressBarService _service;
        public ProgressBarService Service
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


    }
}
