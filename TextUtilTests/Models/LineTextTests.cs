namespace TextUtil.Models.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LineTextTests
    {
        [TestMethod]
        public void UndoTest()
        {
            var line = new LineText();

            line.Text = "a";
            line.Text = "b";
            line.Text = "c";
            line.Text = "d";

            line.Undo();
            Assert.AreEqual("c", line.Text);

            line.Undo();
            Assert.AreEqual("b", line.Text);

            line.Undo();
            Assert.AreEqual("a", line.Text);

            line.Undo();
            Assert.AreEqual("a", line.Text);
        }
    }
}