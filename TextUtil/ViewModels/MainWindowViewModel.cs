namespace TextUtil.ViewModels
{
    using System.IO;
    using Prism.Mvvm;
    using TextUtil.Models;

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
            get 
            { 
                return currentFileInfo;
            }

            set 
            {
                using (var reader = new StreamReader(value.FullName))
                {
                    Editor.Text = reader.ReadToEnd();
                }

                SetProperty(ref currentFileInfo, value);
            }
        }

        public Editor Editor { get; set; } = new Editor(); 
    }
}
