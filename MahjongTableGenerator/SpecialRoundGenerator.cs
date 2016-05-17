using System.Collections.Generic;
using Data;

namespace MahjongTableGenerator
{
    class SpecialRoundGenerator
    {
        public Round Generate(Scheme scheme, int elapsedRounds)
        {

            var newNumberOfTables = scheme.NumberOfTables * 4;
            var newRound = new Round

            {
                RoundNumber = elapsedRounds + 1,
                Tables = new List<Table>()
            };

            for (int i = 1; i <= newNumberOfTables; i++)
            {
                var players = new List<int> { 
                    i, 
                    i + newNumberOfTables, 
                    i + 2 * newNumberOfTables, 
                    i + 3 * newNumberOfTables 
                };

                newRound.Tables.Add(new Table { TableNumber = i, Players = players });
            }

            return newRound;
        }
    }
}