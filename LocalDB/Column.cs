using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LocalDB
{
    public class Column
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Column()
        {

        }

        public Column(string name)
        {
            Name = name;
        }

        public static List<string> getTypes()
        {
            return new List<string> { "INT", "REAL", "CHAR", "STRING", "TIME", "TIMEINVL"};
        }

        public object ValueOf(string value)
        {
            if (Type == "INT")
                return int.Parse(value);

            if (Type == "REAL")
                return double.Parse(value);

            if (Type == "CHAR")
                return char.Parse(value);

            if (Type == "STRING")
                return value;

            if (Type == "TIME")
                return TimeSpan.Parse(value);

            if (Type == "TIMEINVL")
            {
                if (String.IsNullOrWhiteSpace(value))
                    return null;

                TimeSpan ts1, ts2;
                string[] s = value.Trim().Split(",");

                if (s.Length != 2 || !s[0].StartsWith('(') || !s[1].EndsWith(')') || !TimeSpan.TryParse(s[0].Substring(1), out ts1) || !TimeSpan.TryParse(s[1].Substring(0, s[1].Length - 1), out ts2))
                    return null;

                return new Tuple<TimeSpan, TimeSpan>(ts1, ts2);
            }

            return null;
        }

        public bool Validate(string value)
        {
            if (Type == "INT")
                return int.TryParse(value, out _);

            if (Type == "REAL")
                return double.TryParse(value, out _);

            if (Type == "CHAR")
                return char.TryParse(value, out _);

            if (Type == "STRING")
                return true;

            if (Type == "TIME")
                return TimeSpan.TryParse(value, out _);

            if (Type == "TIMEINVL")
            {
                if (String.IsNullOrWhiteSpace(value))
                    return false;

                string[] s = value.Trim().Split(",");

                return s.Length == 2 && s[0].StartsWith('(') && s[1].EndsWith(')') && TimeSpan.TryParse(s[0].Substring(1), out _) && TimeSpan.TryParse(s[1].Substring(0, s[1].Length - 1), out _);
            }

            return false;
        }
    }
}
