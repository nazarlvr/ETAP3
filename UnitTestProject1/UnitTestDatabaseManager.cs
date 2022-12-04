using LocalDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestLocalDB
{
    [TestClass]
    public class UnitTestDatabaseManager
    {
        [TestMethod]
        public void TestFind()
        {
            Table table = new Table
            {
                Columns = new List<Column>
                {
                    new Column
                    {
                        Name = "ID",
                        Type = "INT"
                    },
                    new Column
                    {
                        Name = "Name",
                        Type = "STRING"
                    },
                    new Column
                    {
                        Name = "Group",
                        Type = "CHAR"
                    }
                },
                Rows = new List<Row>
                {
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "1" },
                            { "Name", "abc" },
                            { "Group", "A" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "2" },
                            { "Name", "acb" },
                            { "Group", "A" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "3" },
                            { "Name", "bac" },
                            { "Group", "A" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "4" },
                            { "Name", "bca" },
                            { "Group", "A" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "5" },
                            { "Name", "cab" },
                            { "Group", "A" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "6" },
                            { "Name", "cba" },
                            { "Group", "A" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "7" },
                            { "Name", "abc" },
                            { "Group", "B" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "8" },
                            { "Name", "acb" },
                            { "Group", "B" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "9" },
                            { "Name", "bac" },
                            { "Group", "B" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "10" },
                            { "Name", "bca" },
                            { "Group", "B" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "11" },
                            { "Name", "cab" },
                            { "Group", "B" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "12" },
                            { "Name", "cba" },
                            { "Group", "B" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "13" },
                            { "Name", "abc" },
                            { "Group", "C" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "14" },
                            { "Name", "acb" },
                            { "Group", "C" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "15" },
                            { "Name", "bac" },
                            { "Group", "C" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "16" },
                            { "Name", "bca" },
                            { "Group", "C" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "17" },
                            { "Name", "cab" },
                            { "Group", "C" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "18" },
                            { "Name", "cba" },
                            { "Group", "C" }
                        }
                    }
                }
            };

            string pattern1 = "{\"Name\":\"abc\"}";
            Table table1 = new Table
            {
                Columns = new List<Column>
                {
                    new Column
                    {
                        Name = "ID",
                        Type = "INT"
                    },
                    new Column
                    {
                        Name = "Name",
                        Type = "STRING"
                    },
                    new Column
                    {
                        Name = "Group",
                        Type = "CHAR"
                    }
                },
                Rows = new List<Row>
                {
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "1" },
                            { "Name", "abc" },
                            { "Group", "A" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "7" },
                            { "Name", "abc" },
                            { "Group", "B" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "13" },
                            { "Name", "abc" },
                            { "Group", "C" }
                        }
                    }
                }
            };
            Table result1 = DatabaseManager.Find(table, pattern1);

            string pattern2 = "{\"Group\":\"A\"}";
            Table table2 = new Table
            {
                Columns = new List<Column>
                {
                    new Column
                    {
                        Name = "ID",
                        Type = "INT"
                    },
                    new Column
                    {
                        Name = "Name",
                        Type = "STRING"
                    },
                    new Column
                    {
                        Name = "Group",
                        Type = "CHAR"
                    }
                },
                Rows = new List<Row>
                {
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "1" },
                            { "Name", "abc" },
                            { "Group", "A" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "2" },
                            { "Name", "acb" },
                            { "Group", "A" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "3" },
                            { "Name", "bac" },
                            { "Group", "A" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "4" },
                            { "Name", "bca" },
                            { "Group", "A" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "5" },
                            { "Name", "cab" },
                            { "Group", "A" }
                        }
                    },
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "6" },
                            { "Name", "cba" },
                            { "Group", "A" }
                        }
                    }
                }
            };
            Table result2 = DatabaseManager.Find(table, pattern2);

            string pattern3 = "{\"Name\":\"abc\",\"Group\":\"A\"}";
            Table table3 = new Table
            {
                Columns = new List<Column>
                {
                    new Column
                    {
                        Name = "ID",
                        Type = "INT"
                    },
                    new Column
                    {
                        Name = "Name",
                        Type = "STRING"
                    },
                    new Column
                    {
                        Name = "Group",
                        Type = "CHAR"
                    }
                },
                Rows = new List<Row>
                {
                    new Row
                    {
                        Values = new Dictionary<string, string>
                        {
                            { "ID", "1" },
                            { "Name", "abc" },
                            { "Group", "A" }
                        }
                    }
                }
            };
            Table result3 = DatabaseManager.Find(table, pattern3);

            Assert.AreEqual(true, this.CompareTables(result1, table1));
            Assert.AreEqual(true, this.CompareTables(result2, table2));
            Assert.AreEqual(true, this.CompareTables(result3, table3));
        }

        private bool CompareTables(Table table1, Table table2)
        {
            if ((table1 == null) != (table2 == null))
                return false;

            if (table1 == null)
                return true;

            if (table1.Rows.Count != table2.Rows.Count || table1.Columns.Count != table2.Columns.Count)
                return false;

            for (int i = 0; i < table1.Columns.Count; ++i)
                if (!string.Equals(table1.Columns[i].Name, table2.Columns[i].Name) || !string.Equals(table1.Columns[i].Type, table2.Columns[i].Type))
                    return false;

            for (int i = 0; i < table1.Rows.Count; ++i)
            {
                foreach (var v in table1.Rows[i].Values)
                    if (!string.Equals(v.Value, table2.Rows[i].Values[v.Key]))
                        return false;

                foreach (var v in table2.Rows[i].Values)
                    if (!string.Equals(v.Value, table1.Rows[i].Values[v.Key]))
                        return false;
            }

            return true;
        }
    }
}
