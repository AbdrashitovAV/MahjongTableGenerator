using System.Collections.Generic;
using Data;

namespace MahjongTableGenerator
{
    class SchemeGenerator
    {
        private readonly PlayerGroupSpecificationProvider _playerGroupSpecificationProvider;
        private readonly SpecialRoundGenerator _specialRoundGenerator;
        private readonly RoundsFromPlayerSpecGenerator _roundsFromPlayerSpecGenerator;

        public SchemeGenerator(PlayerGroupSpecificationProvider playerGroupSpecificationProvider, 
                               SpecialRoundGenerator specialRoundGenerator,
                               RoundsFromPlayerSpecGenerator roundsFromPlayerSpecGenerator)
        {
            _playerGroupSpecificationProvider = playerGroupSpecificationProvider;
            _specialRoundGenerator = specialRoundGenerator;
            _roundsFromPlayerSpecGenerator = roundsFromPlayerSpecGenerator;
        }


        public Scheme GenerateNewScheme(Scheme scheme)
        {
            var newSchemeRounds = new List<Round>();
            var playerGroupSpecificationLists = _playerGroupSpecificationProvider.Get();

            for (var i = 0; i < playerGroupSpecificationLists.Count; i++)
            {
                var newRounds = _roundsFromPlayerSpecGenerator.GenerateRoundsFromPlayerGroupSpecificationList(scheme, playerGroupSpecificationLists[i], scheme.NumberORounds * i);
                newSchemeRounds.AddRange(newRounds);
            }

            var specRound = _specialRoundGenerator.Generate(scheme, scheme.NumberORounds * 4);
            newSchemeRounds.Add(specRound);

            var newScheme = new Scheme
            {
                NumberOfPlayers = scheme.NumberOfPlayers * 4,
                NumberOfTables = scheme.NumberOfTables * 4,
                NumberORounds = scheme.NumberORounds * 5,
                Rounds = newSchemeRounds
            };

            return newScheme;
        }
    }
}