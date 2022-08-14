namespace TextUtil.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using Prism.Commands;
    using Prism.Mvvm;
    using TextUtil.Models;

    public class MainWindowViewModel : BindableBase
    {
        private string title = "Text Util";
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
                var lineCounter = 0;
                Editor.Texts = new ObservableCollection<LineText>(lines.Select(t => new LineText()
                {
                    Text = t,
                    Index = lineCounter++,
                }).ToList());

                SetProperty(ref currentFileInfo, value);
            }
        }

        public Editor Editor { get; set; } = new Editor();

        public string Parameter { get => parameter; set => SetProperty(ref parameter, value); }

        public DelegateCommand InsertNumberToHeadCommand => new DelegateCommand(() =>
        {
            Editor.InsertCounterToLineHeader(Parameter);
        });

        public DelegateCommand TrimSamePartAsPreviousLineCommand => new DelegateCommand(() =>
        {
            Editor.TrimSamePartAsPreviousLine();
        });

        public DelegateCommand SaveCommand => saveCommand ?? (saveCommand = new DelegateCommand(() =>
        {
            // if (CurrentFileInfo != null)
            // {
            //     File.WriteAllText(CurrentFileInfo.FullName, Editor.Text);
            //     Editor.Saved = true;
            // }
        }));

        public DelegateCommand UndoCommand => new DelegateCommand(() =>
        {
            Editor.Texts.ToList().ForEach(t => t.Undo());
        });

        public DelegateCommand LoadFromClipboardCommand => new DelegateCommand(() =>
        {
            if (Clipboard.GetText() != string.Empty)
            {
                var lines = Clipboard.GetText().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                Editor.Texts = new ObservableCollection<LineText>(lines.ToList().Select(t => new LineText() { Text = t }));
            }
        });

        public DelegateCommand SendToClipboardCommand => new DelegateCommand(() =>
        {
            Clipboard.SetText(Editor.GetText());
        });
    }
}
