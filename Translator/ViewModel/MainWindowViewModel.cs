using System.Windows.Input;
using Translator.Model;

namespace Translator.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        private Word _word = new Word();
        private Dictionary _dictionary = new Dictionary();
        private ICommand _translateButton;
        private ICommand _addToListButton;
        private ICommand _generatePdfButton;

        public MainWindowViewModel()
        {
            _translateButton = new RelayCommand(Translate);
            _addToListButton = new RelayCommand(AddToList);
            _generatePdfButton = new RelayCommand(GeneratePdf);
        }

        public string Message { get; set; }

        public Word Word
        {
            get { return _word; }
            set
            {
                _word = value;
                RaisePropertyChangedEvent("Word");
            }
        }

        private void Translate(object obj)
        {
            _word.TranslateUnknown();
            RaisePropertyChangedEvent("Word");
        }

        private void GeneratePdf(object obj)
        {
            //_dictionary.CreatePdf();
        }

        private void AddToList(object obj)
        {
            _dictionary.AddToDictionary(_word);
        }

        public ICommand TranslateButton
        {
            get { return _translateButton; }
            set { _translateButton = value; }
        }

        public ICommand AddToListButton
        {
            get { return _addToListButton; }
            set { _addToListButton = value; }
        }

        public ICommand GeneratePdfButton
        {
            get { return _generatePdfButton; }
            set { _generatePdfButton = value; }
        }
    }
}
