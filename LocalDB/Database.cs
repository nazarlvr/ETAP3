using System;
using System.Collections.Generic;
using System.Text;

namespace LocalDB
{
    public class Database
    {
        public string Name { get; set; }
        public List<Table> Tables { get; set; } = new List<Table>();

        public Database()
        {

        }

        public Database(string name)
        {
            Name = name;
        }
    }

}
