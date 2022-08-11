namespace TextUtil.ViewModels
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using Prism.Commands;
    using Prism.Mvvm;
    using TextUtil.Models;

    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";
        private FileInfo currentFileInfo;

        private DelegateCommand saveCommand;

        private string parameter;

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
                var lines = File.ReadAllLines(value.FullName);
                Editor.Texts = new ObservableCollection<LineText>(lines.Select(t => new LineText() { Text = t }).ToList());

                SetProperty(ref currentFileInfo, value);
            }
        }

        public Editor Editor { get; set; } = new Editor();

        public string Parameter { get => parameter; set => SetProperty(ref parameter, value); }

        public DelegateCommand InsertNumberToHeadCommand => new DelegateCommand(() =>
        {
            Editor.InsertCounterToLineHeader(Parameter);
        });

        public DelegateCommand SaveCommand => saveCommand ?? (saveCommand = new DelegateCommand(() =>
        {
            // if (CurrentFileInfo != null)
            // {
            //     File.WriteAllText(CurrentFileInfo.FullName, Editor.Text);
            //     Editor.Saved = true;
            // }
        }));

        public DelegateCommand LoadFromClipboardCommand => new DelegateCommand(() =>
        {
            if (Clipboard.GetText() != string.Empty)
            {
                // Editor.Text = Clipboard.GetText();
            }
        });

        public DelegateCommand SendToClipboardCommand => new DelegateCommand(() =>
        {
            Clipboard.SetText(Editor.GetText());
        });
    }
}
