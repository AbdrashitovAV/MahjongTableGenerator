using System.Collections.Generic;

namespace Data
{
    public class Table
    {
        public int TableNumber { get; set; }

        public List<int> Players { get; set; }

        public override string ToString()
        {
            return Players[0].ToString().PadLeft(2) + " " + Players[1].ToString().PadLeft(2) + " " + Players[2].ToString().PadLeft(2) + " " + Players[3].ToString().PadLeft(2);
        }
    }
}
