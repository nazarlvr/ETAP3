using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace LocalDB
{
    public class Table
    {
        public string Name { get; set; }
        public List<Row> Rows { get; set; } = new List<Row>();
        public List<Column> Columns { get; set; } = new List<Column>();

        public Table()
        {

        }
    }
}
