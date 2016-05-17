using System;
using System.Collections.Generic;
using Data;

namespace MahjongTableGenerator
{
    public class RoundSlice
    {
        public int RoundNumber { get; set; }

        public List<Table> Tables { get; set; }

        public override string ToString()
        {
            var tablesContent = String.Empty;

            foreach (var table in Tables)
            {
                tablesContent += table.TableNumber.ToString().PadLeft(3).PadRight(5) + table + " | ";
            }

            return RoundNumber.ToString().PadLeft(5) + "]\t" + tablesContent;
        }
    }
}
