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

        public int? ProgressBarValue
        {
            get => ProgressBarValue;
            set
            {
                if (ProgressBarValue == null)
                    ProgressBarValue = 0;
                else
                    ProgressBarValue = value;
            }
        }


    }
}
