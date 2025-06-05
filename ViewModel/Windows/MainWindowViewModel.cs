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

namespace PWCreater.ViewModel.Windows
{
    internal class MainWindowViewModel : ViewModelBase
    {
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

            GenerationMethodEnum generationMethodEnum = (GenerationMethodEnum)_selectedGenerationMethod;


            switch (generationMethodEnum)
            {
                case GenerationMethodEnum.AudioGenerator:
                    /*генератор*/
                    break;
                case GenerationMethodEnum.CursorGenerator:
                    PasswordGenerator passwordGenerator = new PasswordGenerator();
                    PasswordString = passwordGenerator.GeneratePassword(_countSymbols, _alphabet, generationMethodEnum);
                    MessageBox.Show("всё");
                    break;
            }
         
        }
        #endregion

        public MainWindowViewModel()
        {
            GeneratePasswordCommand = new LamdaCommand(OnGeneratePasswordExecuted, CanGeneratePasswordExecuted);
            CopyPasswordCommand = new LamdaCommand(OnCopyPasswordExecuted, CanCopyPasswordExecuted);
        }

       

    }
}
