using PWCreater.Infrastructure.Srvices.ProgressBar;
using PWCreater.ViewModel.Base;

namespace PWCreater.ViewModel.Windows
{
    internal class GenerationWindowViewModel : ViewModelBase
    {
        private int _generationValue = 0;
        public int GenerationValue
        {
            get => _generationValue;

            set
            {
                _generationValue = value;
                OnPropertyChanged(_generationValue);
            }
        }

        public GenerationWindowViewModel() { }
    }
}
