using System;
using System.Windows;
using System.Windows.Input;
using PWCreater.Infrastructure.Commands;
using PWCreater.Infrastructure.Srvices;
using PWCreater.ViewModel.Base;
using PWCreater.Model.UserType;
using PWCreater.Infrastructure.Enums;
using PWCreater.Infrastructure.Srvices.Generators.CursorStringGenerator;
using PWCreater.Infrastructure.Srvices.Generators;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Media;
using System.Windows.Navigation;

namespace PWCreater.ViewModel.Windows
{
    internal class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {
            TestBackground = new(Color.FromRgb(255, 255, 255));
            GeneratePasswordCommand = new LamdaCommand(OnGeneratePasswordExecuted, CanGeneratePasswordExecuted);
            CopyPasswordCommand = new LamdaCommand(OnCopyPasswordExecuted, CanCopyPasswordExecuted);
            CancelGeneratePasswordCommand = new LamdaCommand(OnCancelGeneratePasswordExecuted, CanCancelGeneratePasswordExecuted);
        }

        private SolidColorBrush _testBackground;
        public SolidColorBrush TestBackground 
        {
            get => _testBackground;
            set => Set(ref _testBackground, value);
        }

        //токен для кнопки отмены генерации
        private CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

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

            if (_selectedGenerationMethod >= 0)
            {
                ChoiceGenerationMethod(_selectedGenerationMethod, _alphabet);
            }
        }
        private bool CanGeneratePasswordExecuted(object p) => true;

        private void ChoiceGenerationMethod(int index, SymbolAlphabet symbol)
        {
            CancellationToken token = cancelTokenSource.Token;

            try
            {
                Task.Run(async () =>
                {
                    TestBackground = new(Color.FromRgb(255, 0, 255));
                    GenerationMethodEnum generationMethodEnum = (GenerationMethodEnum)_selectedGenerationMethod;
                    switch (generationMethodEnum)
                    {
                        case GenerationMethodEnum.AudioGenerator:
                            /*генератор*/
                            break;
                        case GenerationMethodEnum.CursorGenerator:
                            PasswordGenerator passwordGenerator = new PasswordGenerator();
                            PasswordString = await passwordGenerator.GeneratePassword(_countSymbols, _alphabet, generationMethodEnum);
                            MessageBox.Show("всё");
                            break;
                    }
                }, token);


                TestBackground = new(Color.FromRgb(255, 255, 255));
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("отмена задачи");
            }
            //finally
            //{
            //    cancelTokenSource.Dispose();
            //}
        }
        #endregion

        public ICommand CancelGeneratePasswordCommand { get; }
        private void OnCancelGeneratePasswordExecuted(object p)
        {
            cancelTokenSource.Cancel();
        }

        private bool CanCancelGeneratePasswordExecuted(object p) => true;



       

    }
}
