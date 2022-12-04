using LocalDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestLocalDB
{
    [TestClass]
    public class UnitTestColumn
    {
        [TestMethod]
        [DataRow("1", true)]
        [DataRow("2", true)]
        [DataRow("43524325", true)]
        [DataRow("-0", true)]
        [DataRow("+5", true)]
        [DataRow("abc", false)]
        [DataRow("1.2", false)]
        [DataRow("1,2", false)]
        [DataRow("a", false)]
        [DataRow("0;", false)]
        [DataRow("(1:2:3,1)", false)]
        [DataRow("(1:2,3:1)", false)]
        public void ValidateInt(string arg1, bool exp)
        {
            Column column = new Column
            {
                Type = "INT"
            };

            Assert.AreEqual(exp, column.Validate(arg1));
        }

        [TestMethod]
        [DataRow("1", true)]
        [DataRow("2", true)]
        [DataRow("43524325", true)]
        [DataRow("-0", true)]
        [DataRow("+5", true)]
        [DataRow("abc", false)]
        [DataRow("1.2", false)]
        [DataRow("1,2", true)]
        [DataRow("a", false)]
        [DataRow("0;", false)]
        [DataRow("1:2:3", false)]
        [DataRow("1:2", false)]
        [DataRow("(1:2:3,1)", false)]
        [DataRow("(1:2,3:1)", false)]
        public void ValidateReal(string arg1, bool exp)
        {
            Column column = new Column
            {
                Type = "REAL"
            };

            Assert.AreEqual(exp, column.Validate(arg1));
        }

        [TestMethod]
        [DataRow("1", true)]
        [DataRow("2", true)]
        [DataRow("43524325", false)]
        [DataRow("-0", false)]
        [DataRow("+5", false)]
        [DataRow("abc", false)]
        [DataRow("1.2", false)]
        [DataRow("1,2", false)]
        [DataRow("a", true)]
        [DataRow("0;", false)]
        [DataRow("1:2:3", false)]
        [DataRow("1:2", false)]
        [DataRow("(1:2:3,1)", false)]
        [DataRow("(1:2,3:1)", false)]
        public void ValidateChar(string arg1, bool exp)
        {
            Column column = new Column
            {
                Type = "CHAR"
            };

            Assert.AreEqual(exp, column.Validate(arg1));
        }

        [TestMethod]
        [DataRow("1", true)]
        [DataRow("2", true)]
        [DataRow("43524325", false)]
        [DataRow("-0", true)]
        [DataRow("+5", false)]
        [DataRow("abc", false)]
        [DataRow("1.2", false)]
        [DataRow("1,2", false)]
        [DataRow("a", false)]
        [DataRow("0;", false)]
        [DataRow("1:2:3", true)]
        [DataRow("1:2", true)]
        [DataRow("(1:2:3,1)", false)]
        [DataRow("(1:2,3:1)", false)]
        public void ValidateTime(string arg1, bool exp)
        {
            Column column = new Column
            {
                Type = "TIME"
            };

            Assert.AreEqual(exp, column.Validate(arg1));
        }

        [TestMethod]
        [DataRow("1", false)]
        [DataRow("2", false)]
        [DataRow("43524325", false)]
        [DataRow("-0", false)]
        [DataRow("+5", false)]
        [DataRow("abc", false)]
        [DataRow("1.2", false)]
        [DataRow("1,2", false)]
        [DataRow("a", false)]
        [DataRow("0;", false)]
        [DataRow("1:2:3", false)]
        [DataRow("1:2", false)]
        [DataRow("(1:2:3,1)", true)]
        [DataRow("(1:2,3:1)", true)]
        public void ValidateTimeInvl(string arg1, bool exp)
        {
            Column column = new Column
            {
                Type = "TIMEINVL"
            };

            Assert.AreEqual(exp, column.Validate(arg1));
        }
    }
}
