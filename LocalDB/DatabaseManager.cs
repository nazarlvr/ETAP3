using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace LocalDB
{
    public class DatabaseEventHandler
    {
        private bool f;
        private static int mclcs = 0;
        private Table table;
        private DataGridView dataGridViewData;
        private DataGridView dataGridViewTemplate;
        private Database database;
        private string filepath;

        public DatabaseEventHandler(Table table, DataGridView dgvd, DataGridView dgvt, Database db, string fp)
        {
            this.f = true;
            this.table = table;
            this.dataGridViewData = dgvd;
            this.dataGridViewTemplate = dgvt;
            this.database = db;
            this.filepath = fp;
        }

        public void SaveDatabase()
        {
            System.Diagnostics.Debug.WriteLine("TableUpdate " + ++mclcs);

            if (database != null)
                DatabaseManager.WriteToFile(filepath, database);
        }

        public void DisplayValidation()
        {
            foreach (DataGridViewColumn column in this.dataGridViewData.Columns)
            {
                Column c = this.table.Columns[column.Index];

                foreach (DataGridViewRow row in this.dataGridViewData.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataGridViewCell cell = row.Cells[column.Index];

                        if (c.Validate((string)cell.Value))
                            cell.Style = new DataGridViewCellStyle()
                            {
                                BackColor = Color.White
                            };
                        else
                            cell.Style = new DataGridViewCellStyle()
                            {
                                BackColor = Color.Red
                            };
                    }
                }
            }
        }

        public void PopulateDataFromTable()
        {
            this.dataGridViewData.Columns.Clear();
            this.dataGridViewData.Rows.Clear();

            foreach (Column column in this.table.Columns)
            {
                this.dataGridViewData.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = column.Name,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                });
            }

            foreach (Row row in this.table.Rows)
            {
                List<object> values = new List<object>();

                foreach (Column column in this.table.Columns)
                {
                    values.Add(row[column.Name]);
                }

                this.dataGridViewData.Rows.Add(values.ToArray());
            }

            this.DisplayValidation();
        }

        public void PopulateTemplateFromTable()
        {
            this.dataGridViewTemplate.Rows.Clear();

            foreach (Column column in this.table.Columns)
            {
                this.dataGridViewTemplate.Rows.Add(new string[] { column.Name, column.Type });
            }

            this.PopulateDataFromTable();
        }

        public void UpdateTableFromTemplate()
        {
            if (!f)
                return;

            this.f = false;
            
            this.table.Columns.Clear();

            foreach (DataGridViewRow row in dataGridViewTemplate.Rows)
            {
                if (!String.IsNullOrWhiteSpace((string)row.Cells[0].Value) && !String.IsNullOrWhiteSpace((string)row.Cells[1].Value))
                    this.table.Columns.Add(new Column((string)row.Cells[0].Value)
                    {
                        Type = (string)row.Cells[1].Value
                    });
            }

            this.PopulateDataFromTable();
            this.f = true;
        }

        public void UpdateTableFromData()
        {
            if (!f)
                return;

            this.f = false;
            this.table.Rows.Clear();

            foreach (DataGridViewRow row in this.dataGridViewData.Rows)
            {
                if (!row.IsNewRow)
                {
                    Row r = new Row();

                    foreach (DataGridViewColumn column in this.dataGridViewData.Columns)
                    {
                        Column col = this.table.Columns[column.Index];
                        string text = (string)row.Cells[column.Index].Value;

                        if (col.Validate(text))
                            r.Values[column.HeaderText] = col.ValueOf(text) == null ? "" : col.ValueOf(text).ToString();
                    }

                    this.table.Rows.Add(r);
                }
            }

            this.DisplayValidation();
            this.f = true;
        }

        public void updateTemplate(object sender, DataGridViewCellEventArgs e)
        {
            this.UpdateTableFromTemplate();
        }

        public void updateTemplate(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.UpdateTableFromTemplate();
        }

        public void updateTemplate(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.UpdateTableFromTemplate();
        }

        public void updateData(object sender, DataGridViewCellEventArgs e)
        {
            this.UpdateTableFromData();
        }

        public void updateData(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.UpdateTableFromData();
        }

        public void updateData(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.UpdateTableFromData();
        }
    }

    public class DatabaseManager
    {
        private static DatabaseManager _instance;

        public Database Database { get; set; }
        public string Filepath { get; set; }

        public static DatabaseManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseManager();
                }

                return _instance;
            }
        }

        private DatabaseManager() { }

        public static Database ReadFromFile(string filepath)
        {
            return JsonSerializer.Deserialize<Database>(File.ReadAllText(filepath));
        }

        public static void WriteToFile(string filepath, Database database)
        {
            File.WriteAllText(filepath, JsonSerializer.Serialize(database));
        }

        public static Table Find(Table table, string pattern)
        {
            Table t = new Table();
            Dictionary<string, string> dictionary;

            try
            {
                dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(pattern);
            }
            catch (Exception)
            {
                return null;
            }

            foreach (Column column in table.Columns)
                t.Columns.Add(new Column()
                {
                    Name = column.Name,
                    Type = column.Type
                });

            foreach (Row row in table.Rows)
            {
                bool f = false;

                foreach (var v in dictionary)
                    if (!String.Equals(row[v.Key], v.Value))
                    {
                        f = true;
                        break;
                    }

                if (f)
                    continue;

                Row r = new Row();

                foreach (var v in row.Values)
                    r.Values[v.Key] = v.Value;

                t.Rows.Add(r);
            }

            return t;
        }

        public bool Read(string filepath)
        {
            try
            {
                this.Database = JsonSerializer.Deserialize<Database>(File.ReadAllText(filepath));
                this.Filepath = filepath;
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                return false;
            } 
        }

        public bool Save()
        {
            try
            {
                File.WriteAllText(this.Filepath, JsonSerializer.Serialize(this.Database));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Save(string filepath)
        {
            try
            {
                File.WriteAllText(filepath, JsonSerializer.Serialize(this.Database));
                this.Filepath = filepath;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Create()
        {
            this.Database = new Database("New database")
            {
                Tables = new List<Table>
                    {
                        new Table()
                        {
                            Name = "New Table 1",
                            Columns = new List<Column>
                            {
                                new Column("ID") { Type = "INT" }
                            },
                            Rows = new List<Row>
                            {
                                new Row
                                {
                                    Values = new Dictionary<string, string>
                                    {
                                        { "ID", "1" }
                                    }
                                }
                            }
                        }
                    }
            };
            this.Filepath = null;
        }
    }

}
