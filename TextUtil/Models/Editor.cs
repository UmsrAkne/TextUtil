namespace TextUtil.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
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
            if (!CanEdit() || string.IsNullOrWhiteSpace(target))
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

        /// <summary>
        /// 前の行と最後尾から文字列を比較し、同じ部分があればそれをカットします。
        /// </summary>
        public void TrimSamePartAsPreviousLine()
        {
            if (!CanEdit())
            {
                return;
            }

            var previousLineText = string.Empty;

            foreach (LineText line in Texts)
            {
                if (previousLineText == string.Empty)
                {
                    previousLineText = line.Text;
                    continue;
                }

                for (var i = 0; i < line.Text.Length; i++)
                {
                    var currentPartStr = line.Text.Substring(line.Text.Length - i);
                    var previousPartStr = previousLineText.Substring(previousLineText.Length - i);

                    if (currentPartStr != previousPartStr)
                    {
                        previousLineText = line.Text;
                        line.Text = line.Text.Substring(0, line.Text.Length - i + 1);
                        break;
                    }
                }
            }
        }

        public string GetText()
        {
            var builder = new StringBuilder();

            foreach (var line in Texts)
            {
                builder.AppendLine(line.Text);
            }

            return builder.ToString();
        }

        private bool CanEdit()
        {
            return Texts != null && Texts.Count != 0;
        }
    }
}
