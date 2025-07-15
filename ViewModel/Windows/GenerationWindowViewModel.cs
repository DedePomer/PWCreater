using PWCreater.Infrastructure.Srvices.ProgressBar;
using PWCreater.ViewModel.Base;

namespace PWCreater.ViewModel.Windows
{
    internal class GenerationWindowViewModel : ViewModelBase
    {
        private int _generationValue;
        public int GenerationProgress
        {
            get => _generationValue;

            set { Set(ref _generationValue, value); }
        }

        public GenerationWindowViewModel()
        {
            _generationValue = ProgressBarService.Service.ProgressBarValue;
        }
    }
}
