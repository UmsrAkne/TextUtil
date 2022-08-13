namespace TextUtil.Models
{
    using System.Collections.Generic;
    using Prism.Mvvm;

    public class LineText : BindableBase
    {
        private string text;
        private int index;
        private int counter;

        public string Text
        {
            get => text;
            set
            {
                History.Add(text);

                if (History.Count > 3)
                {
                    History.RemoveAt(0);
                }

                SetProperty(ref text, value);
            }
        }

        public int Index { get => index; set => SetProperty(ref index, value); }

        public int Counter { get => counter; set => SetProperty(ref counter, value); }

        private List<string> History { get; set; } = new List<string>();

        public void Undo()
        {
            if (History.Count != 0)
            {
                SetProperty(ref text, History[History.Count - 1]);
                History.RemoveAt(History.Count - 1);
            }
        }
    }
}
