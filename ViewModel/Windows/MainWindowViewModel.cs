using PWCreater.Infrastructure.Commands;
using PWCreater.Infrastructure.Enums;
using PWCreater.Infrastructure.Srvices.BugService;
using PWCreater.Infrastructure.Srvices.Generators;
using PWCreater.Model.UserType;
using PWCreater.ViewModel.Base;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PWCreater.ViewModel.Windows
{
    internal class MainWindowViewModel : ViewModelBase
    {

        public string ErrorMassage { get; set; }

        //токен для кнопки отмены генерации
        private CancellationTokenSource cancelTokenSource;

        //максимальная и минимальная длина пароля
        public int MaximumSymbols
        {
            get { return 32; }
        }
        public int MinimumSymbols
        {
            get { return 8; }
        }

        //количество символов в пароле
        private int _countSymbols = 16;
        public int CountSymbols
        {
            get { return _countSymbols; }
            set { Set(ref _countSymbols, value); }
        }



        //варианты в CheckBOX
        private SymbolAlphabet _alphabet = new SymbolAlphabet();
        public SymbolAlphabet Alphabet
        {
            get
            {
                return _alphabet;
            }
            set
            {
                _alphabet = value;
            }
        }



        //индекс выбранного способа генерации
        private int _selectedGenerationMethod = 0;
        public int SelectedGenerationMethod
        {
            get
            {
                return _selectedGenerationMethod;
            }
            set
            {
                _selectedGenerationMethod = value;
            }
        }

        //сгенерированный пароль
        private string _passwordString = "457";
        public string PasswordString
        {
            get
            {
                return _passwordString;
            }
            set
            {
                Set(ref _passwordString, value);
            }
        }

        public MainWindowViewModel()
        {
            ErrorService.Service.ErrorOccurred += OnErrorOccurred;

            GeneratePasswordCommand = new LamdaCommand(OnGeneratePasswordExecuted, CanGeneratePasswordExecuted);
            CopyPasswordCommand = new LamdaCommand(OnCopyPasswordExecuted, CanCopyPasswordExecuted);
            CancelGeneratePasswordCommand = new LamdaCommand(OnCancelGeneratePasswordExecuted, CanCancelGeneratePasswordExecuted);
        }

        //команды
        public ICommand CopyPasswordCommand { get; }
        private void OnCopyPasswordExecuted(object p)
        {
            Clipboard.SetData(DataFormats.Text, (Object)_passwordString);
        }
        private bool CanCopyPasswordExecuted(object p) => true;

        #region GeneratePasswordCommand
        public ICommand GeneratePasswordCommand { get; }
        private void OnGeneratePasswordExecuted(object p)
        {
            ChoiceGenerationMethodAsync(_selectedGenerationMethod, _alphabet);
        }
        private bool CanGeneratePasswordExecuted(object p) => true;

        private async Task ChoiceGenerationMethodAsync(int index, SymbolAlphabet symbol)
        {
            cancelTokenSource = new CancellationTokenSource();
            GenerationMethodEnum generationMethodEnum = (GenerationMethodEnum)_selectedGenerationMethod;

            switch (generationMethodEnum)
            {
                case GenerationMethodEnum.AudioGenerator:
                    /*генератор*/
                    break;
                case GenerationMethodEnum.CursorGenerator:
                    PasswordGenerator passwordGenerator = new PasswordGenerator();
                    PasswordString = await passwordGenerator.GeneratePassword(_countSymbols, _alphabet, generationMethodEnum, cancelTokenSource);
                    MessageBox.Show("всё");
                    break;
            }
        }
        #endregion

        public ICommand CancelGeneratePasswordCommand { get; }
        private void OnCancelGeneratePasswordExecuted(object p)
        {

            cancelTokenSource.Cancel();
        }

        private bool CanCancelGeneratePasswordExecuted(object p) => true;


        private void OnErrorOccurred(object sender, ErrorMessage e)
        {
            ErrorMassage = e.NameOfError;
        }


    }
}
