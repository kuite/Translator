using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        private string _input;

        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                RaisePropertyChangedEvent("Input");
            }
        }

        public string TransOne { get; set; }
        public string TransTwo { get; set; }
        public string TransThree { get; set; }
    }
}
