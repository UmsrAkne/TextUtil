using Prism.Mvvm;
using System.IO;

namespace TextUtil.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private FileInfo _currentFileInfo;
        public FileInfo CurrentFileInfo {
            get { return _currentFileInfo; }
            set { SetProperty(ref _currentFileInfo, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
