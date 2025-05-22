using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;
using PWCreater.ViewModel.Base;
using PWCreater.Infrastructure.Srvices;

namespace PWCreater.ViewModel.Windows
{
    internal class MainWindowViewModel : ViewModelBase
    {
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
                catch(Exception e)
                {
                    MessageBox.Show(e.Message + "");
                }
            }
        }


        //варианты в CheckBOX
        public bool AddLowerLatinLetters { get; set; }
        public bool AddUpperLatinLetters { get; set; }
        public bool AddSpecialSymbols { get; set; }



        public MainWindowViewModel()
        { 
        
        }



    }
}
