using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class Scheme
    {
        public int NumberOfPlayers { get; set; }

        public int NumberOfTables { get; set; }

        public int NumberORounds { get; set; }

        public List<Round> Rounds { get; set; }



        public Dictionary<int, List<int>> GetSchemeForTable(int tableNumber)
        {
            return Rounds
                .Aggregate(new Dictionary<int, List<int>>(), (q, w) => { q.Add(w.RoundNumber, w.Tables.Single(x => x.TableNumber == tableNumber).Players); return q; }); ;
        }

        public Dictionary<int, int> GetSchemeForPlayer(int playerNumber)
        {
            return Rounds
                .Aggregate(new Dictionary<int, int>(), (q, w) => { q.Add(w.RoundNumber, w.Tables.Single(x => x.Players.Any(r => r == playerNumber)).TableNumber); return q; }); ;
        }

        public class PlayerRoundDesciption
        {//TODO: use it in previous method
            
        }


        public List<List<int>> GenerateEmptyCrossTable()
        {
            var crossTable = new List<List<int>>();

            for (int i = 0; i < NumberOfPlayers; ++i)
            {
                var crossListI = new List<int>();
                for (int j = 0; j < i; ++j)
                    crossListI.Add(0);
                crossTable.Add(crossListI);
            }

            foreach (var a in crossTable)
                foreach (var b in a)
                    if (b != 0)
                        throw new Exception();


            return crossTable;


        }

        public List<List<int>> GenerateFilledCrossTable()
        {
            var crossTable = GenerateEmptyCrossTable();

            foreach (var round in Rounds)
            {
                foreach (var table in round.Tables)
                {
                    crossTable[table.Players[1] - 1][table.Players[0] - 1] += 1;
                    crossTable[table.Players[2] - 1][table.Players[0] - 1] += 1;
                    crossTable[table.Players[2] - 1][table.Players[1] - 1] += 1;
                    crossTable[table.Players[3] - 1][table.Players[0] - 1] += 1;
                    crossTable[table.Players[3] - 1][table.Players[1] - 1] += 1;
                    crossTable[table.Players[3] - 1][table.Players[2] - 1] += 1;
                };
            };

            return crossTable;
        }

        public bool Check()
        {
            var crossTable = GenerateFilledCrossTable();

            foreach (var a in crossTable)
                foreach (var b in a)
                    if (b != 1)
                        return false;
            return true;
        }


        public override string ToString()
        {
            var content = String.Empty;

            content += "Number of Players: " + NumberOfPlayers + Environment.NewLine;
            content += "Number of Tables: " + NumberOfTables + Environment.NewLine;
            content += "Number of Rounds: " + NumberORounds + Environment.NewLine;

            content += "Table:" + '\t';

            for (int i = 1; i <= NumberOfTables; ++i)
            {
                content += i.ToString().PadLeft(7).PadRight(14);
            }
            content += Environment.NewLine;

            content += "Round" + '\t';
            content += Environment.NewLine;

            foreach (var round in Rounds)
            {
                content += round.ToString() + Environment.NewLine;
            }

            return content;
        }
    }
}
