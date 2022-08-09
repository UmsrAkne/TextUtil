namespace TextUtil.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Prism.Mvvm;

    public class Editor : BindableBase
    {
        private bool saved = true;
        private ObservableCollection<LineText> texts;

        public List<string> History { get; private set; } = new List<string>();

        public ObservableCollection<LineText> Texts { get => texts; set => SetProperty(ref texts, value); }

        public bool Saved { get => saved; set => SetProperty(ref saved, value); }

        public void InsertCounterToLineHeader(string target)
        {
            if (Texts.Count == 0)
            {
                return;
            }

            Saved = false;

            int count = 0;

            Texts.ToList().ForEach(line =>
            {
                if (line.Text.Contains(target))
                {
                    count++;
                }

                line.Text = line.Text.Contains(target) ? $"{string.Format("{0:D3}", count)},{line.Text}" : $"000,{line.Text}";
            });
        }
    }
}
