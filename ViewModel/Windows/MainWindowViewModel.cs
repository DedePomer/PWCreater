using System;
using System.Windows;
using System.Windows.Input;
using PWCreater.Infrastructure.Commands;
using PWCreater.Infrastructure.Srvices;
using PWCreater.ViewModel.Base;
using PWCreater.Model.UserType;
using PWCreater.Infrastructure.Enums;

namespace PWCreater.ViewModel.Windows
{
    internal class MainWindowViewModel : ViewModelBase
    {
        //количество символов в пароле
        private string _countSymbolsInPasswords = "16"; /*свойство может быть равно "" не забудь проверить при генерации*/
        public string CountSymbolsInPasswords
        {
            get
            {
                return _countSymbolsInPasswords;
            }
            set
            {
                try
                {
                    ChekStringSymbols chekStringSymbols = new ChekStringSymbols();
                    _countSymbolsInPasswords = value;
                    if (!chekStringSymbols.IsNumberSuitable(_countSymbolsInPasswords))
                    {
                        _countSymbolsInPasswords = "";
                        throw new Exception("Символ должен быть числом от 1 до 32");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "");
                }
            }
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



        //индекс выбранного генератора
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
                _passwordString = value;
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
            ChekStringSymbols chekStringSymbols = new ChekStringSymbols();
            if (chekStringSymbols.IsNumberSuitable(_countSymbolsInPasswords) && _selectedGenerationMethod >= 0)
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
                    /*генератор*/
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
