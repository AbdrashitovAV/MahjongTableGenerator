using System.Collections.Generic;
using System.Linq;
using Data;

namespace MahjongTableGenerator
{
    class RoundsFromPlayerSpecGenerator
    {
        public List<Round> GenerateRoundsFromPlayerGroupSpecificationList(Scheme scheme, PlayerGroupSpecificationList playerGroupSpecificationList, int elapsedRounds)
        {
            var roundSlices = new List<RoundSlice>();
            var newRounds = new List<Round>();

            foreach (var playerGroupSpecification in playerGroupSpecificationList.Specifications)
            {
                roundSlices.AddRange(GenerateTableBlock(scheme, playerGroupSpecification, elapsedRounds));
            }

            var groupedRoundSlices = roundSlices.GroupBy(x => x.RoundNumber).ToList();

            foreach (var roundSliceGroup in groupedRoundSlices)
            {
                var roundIndex = roundSliceGroup.Key;
                var roundISlices = roundSliceGroup.ToList();

                var newRoundTables = roundISlices.Aggregate(new List<Table>(), (q, w) => { q.AddRange(w.Tables); return q; })
                    .OrderBy(x => x.TableNumber)
                    .ToList();

                var newRound = new Round
                {
                    RoundNumber = roundIndex,
                    Tables = newRoundTables
                };

                newRounds.Add(newRound);
            }

            return newRounds;
        }

        private List<RoundSlice> GenerateTableBlock(Scheme scheme, PlayerGroupSpecification blockGenerator, int elapsedRounds)
        {
            var generatedRounds = new List<RoundSlice>();

            foreach (var round in scheme.Rounds)
            {
                var roundSlice = new RoundSlice
                {
                    RoundNumber = round.RoundNumber + elapsedRounds,
                    Tables = new List<Table>()
                };


                foreach (var table in round.Tables)
                {
                    var shiftForTableNumber = blockGenerator.PlayerGroup[0] - 1;

                    var generatedTable = new Table
                    {
                        TableNumber = scheme.NumberOfTables * shiftForTableNumber + table.TableNumber, // assume that generators are correctly ordered;
                        Players = new List<int>()
                    };

                    for (int i = 0; i < 4; ++i)
                    {
                        var player = table.Players[i];
                        var playerShift = (blockGenerator.PlayerGroup[i] - 1) * scheme.NumberOfPlayers;
                        generatedTable.Players.Add(player + playerShift);
                    }

                    generatedTable.Players = generatedTable.Players.OrderBy(x => x).ToList();
                    roundSlice.Tables.Add(generatedTable);
                }

                generatedRounds.Add(roundSlice);
            };

            return generatedRounds;
        }
    }
}