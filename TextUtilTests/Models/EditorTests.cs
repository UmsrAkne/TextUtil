namespace TextUtil.Models.Tests
{
    using System.Collections.ObjectModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EditorTests
    {
        [TestMethod]
        public void TrimSamePartAsPreviousLineTest()
        {
            var editor = new Editor();

            editor.Texts = new ObservableCollection<LineText>()
            {
                new LineText() { Text = "123456789" },
                new LineText() { Text = "abcde6789" },
                new LineText() { Text = "fghie6789" },
                new LineText() { Text = "jklmnop89" },
                new LineText() { Text = "qrsmnop89" },
            };

            editor.TrimSamePartAsPreviousLine();

            Assert.AreEqual("123456789", editor.Texts[0].Text);
            Assert.AreEqual("abcde", editor.Texts[1].Text);
            Assert.AreEqual("fghi", editor.Texts[2].Text);
            Assert.AreEqual("jklmnop", editor.Texts[3].Text);
            Assert.AreEqual("qrs", editor.Texts[4].Text);
        }
    }
}