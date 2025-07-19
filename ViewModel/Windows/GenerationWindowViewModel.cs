using System.Threading;
using System.Windows.Input;
using PWCreater.Infrastructure.Commands;
using PWCreater.Infrastructure.Srvices.ProgressBar;
using PWCreater.View.Windows;
using PWCreater.ViewModel.Base;

namespace PWCreater.ViewModel.Windows
{
    internal class GenerationWindowViewModel : ViewModelBase
    {

        private GenerationWindow _generationWindow;
        private CancellationTokenSource _cancelTokenSource;


        private int _generationValue = 0;
        public int GenerationValue
        {
            get => _generationValue;

            set
            {
                _generationValue = value;
                OnPropertyChanged();
            }
        }

        public GenerationWindowViewModel(GenerationWindow generationWindow, ref CancellationTokenSource cancelTokenSource)
        {
            _generationWindow = generationWindow;
            _cancelTokenSource = cancelTokenSource;

            ProgressBarService.Service.ProgressOccurred += OnProgressOccurred;

            GenerationCancelCommand = new LamdaCommand(OnGenerationCancelCommandExecuted, CanGenerationCancelCommandExecuted);
        }

        public ICommand GenerationCancelCommand { get; }
        private void OnGenerationCancelCommandExecuted(object p)
        {
            _cancelTokenSource.Cancel();
            _generationWindow.Close();
        }
        private bool CanGenerationCancelCommandExecuted(object p) => true;


        private void OnProgressOccurred(object sender, int e)
        {
            if (GenerationValue + e >= 100) 
                _generationWindow.Close();
            GenerationValue += e;
        }

    }
}
