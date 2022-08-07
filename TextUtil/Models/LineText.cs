namespace TextUtil.Models
{
    using Prism.Mvvm;

    public class LineText : BindableBase
    {
        private string text;
        private int index;
        private int counter;

        public string Text { get => text; set => SetProperty(ref text, value); }

        public int Index { get => index; set => SetProperty(ref index, value); }

        public int Counter { get => counter; set => SetProperty(ref counter, value); }
    }
}
