using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWCreater.Infrastructure.Srvices.ProgressBar
{
    internal class ProgressBarService
    {
        private ProgressBarService() { }

        private static ProgressBarService _service;
        public static ProgressBarService Service
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

        public event EventHandler<int> ProgressOccurred;

        public void AddValue(int value)
        {
            ProgressOccurred?.Invoke(this, value);
        }
    
    }
}
