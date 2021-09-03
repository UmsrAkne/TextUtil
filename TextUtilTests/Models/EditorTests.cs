namespace TextUtil.Models.Tests
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextUtil.Models;

    [TestClass]
    public class EditorTests
    {
        [TestMethod]
        public void InsertCounterToLineHeaderTest()
        {
            var editor = new Editor();
            string text = "aTest\r\naTest\r\nbtest\r\ncTest";

            editor.Text = text;
            editor.InsertCounterToLineHeader("T");
            Assert.AreEqual(editor.Text, "1aTest\r\n2aTest\r\n0btest\r\n3cTest\r\n");
        }
    }
}