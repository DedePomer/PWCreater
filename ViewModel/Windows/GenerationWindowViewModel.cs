using PWCreater.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWCreater.ViewModel.Windows
{
    internal class GenerationWindowViewModel: ViewModelBase
    {
        private int _generationProgress;
        public int GenerationProgress
        {
            get => _generationProgress;

            set { Set(ref _generationProgress, value); }
        }

        public GenerationWindowViewModel()
        {        
        }
    }
}
