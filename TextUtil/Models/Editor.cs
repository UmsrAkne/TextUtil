namespace TextUtil.Models
{
    using System;
    using System.Collections.Generic;
    using Prism.Mvvm;

    public class Editor : BindableBase
    {
        private string text;

        public string Text { get => text; set => SetProperty(ref text, value); }

        public List<string> History { get; private set; } = new List<string>();

        public bool Saved { get; set; } = true;

        public void InsertCounterToLineHeader(string target)
        {
            if (Text == null || Text == string.Empty)
            {
                return;
            }

            Saved = false;
            SaveHistory();

            string[] delimiter = { Environment.NewLine };
            var lines = new List<string>(Text.Split(delimiter, StringSplitOptions.None));
            Text = string.Empty;
            int count = 0;

            lines.ForEach(line =>
            {
                if (line.Contains(target))
                {
                    count++;
                }

                line = line.Contains(target) ? $"{string.Format("{0:D3}", count)},{line}" : $"000,{line}";
                Text += line + Environment.NewLine;
            });

            // 最後尾に挿入される改行コード \r\n を削除
            Text = Text.Remove(Text.Length - 2);
        }

        private void SaveHistory()
        {
            History.Add(Text);
            if (History.Count > 10)
            {
                History.RemoveAt(0);
            }
        }
    }
}
