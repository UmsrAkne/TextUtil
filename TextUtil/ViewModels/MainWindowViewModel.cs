namespace TextUtil.ViewModels
{
    using System.IO;
    using Prism.Mvvm;

    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";
        private FileInfo currentFileInfo;

        public MainWindowViewModel()
        {
        }

        public string Title 
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public FileInfo CurrentFileInfo
        {
            get { return currentFileInfo; }
            set { SetProperty(ref currentFileInfo, value); }
        }
    }
}
