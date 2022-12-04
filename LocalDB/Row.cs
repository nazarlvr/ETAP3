using System;
using System.Collections.Generic;
using System.Text;

namespace LocalDB
{
    public class Row
    {
        public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();

        public string this[string i]
        {
            get => i == null || !Values.ContainsKey(i) ? null : Values[i];
            set => Values[i] = value;
        }

        public Row()
        {

        }
    }

}
