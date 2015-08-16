using System.Windows.Input;
using Translator.Model;

namespace Translator.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        private Dictionary _dictionary = new Dictionary();
        private ICommand _translateButton;
        private bool _canExecute;

        public MainWindowViewModel()
        {
            _translateButton = new RelayCommand(Translate);
        }

        private void Translate(object obj)
        {
            _dictionary.TranslateUnknown();
            RaisePropertyChangedEvent("Dictionary");
        }

        public Dictionary Dictionary
        {
            get { return _dictionary; }
            set
            {
                _dictionary = value;
                RaisePropertyChangedEvent("Dictionary");
            }
        }

        public ICommand TranslateButton
        {
            get { return _translateButton; }
            set { _translateButton = value; }
        }

        public bool CanExecute
        {
            get { return _canExecute; }
            set { _canExecute = value; }
        }
    }
}
