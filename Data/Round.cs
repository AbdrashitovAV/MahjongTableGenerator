using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class Round
    {
        public int RoundNumber { get; set; }
        public List<Table> Tables { get; set; }

        public override string ToString()
        {
            var tablesContent = String.Empty;

            foreach (var table in Tables.OrderBy(x => x.TableNumber))
            {
                tablesContent += table.ToString() + " | ";
                //TODO: rewrite to show tables in correct order
            }

            return RoundNumber.ToString().PadLeft(5) + '\t' + tablesContent;
        }
    }
}
