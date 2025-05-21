using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;
using PWCreater.ViewModel.Base;

namespace PWCreater.ViewModel.Windows
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string _countSymbolsInPasswords = "16";
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
                    //_countSymbolsInPasswords = value;
                    //if (_countSymbolsInPasswords <= 0 && _countSymbolsInPasswords < 33)
                    //{
                    //    _countSymbolsInPasswords = 1;
                    //    throw new Exception("Количество символо должно быть больше нуля и меньше 32");
                    //}
                }
                catch(Exception e)
                {
                    //MessageBox.Show("Ошибка должна логироваться =)","Ошибка", MessageBoxButton.OK);
                }
            }
        }

        public MainWindowViewModel()
        { 
        
        }



    }
}
