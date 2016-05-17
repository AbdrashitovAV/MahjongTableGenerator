using System.Collections.Generic;
using System.IO;
using Data;

namespace MahjongTableGenerator
{
    class Program
    {

        static void Main(string[] args)
        {
            var schemeSaver = new SchemeSaver();
            var schemeGenerator = new SchemeGenerator(new PlayerGroupSpecificationProvider(), new SpecialRoundGenerator(), new RoundsFromPlayerSpecGenerator());

            var table = new Table { Players = new List<int> { 1, 2, 3, 4 }, TableNumber = 1 };
            var round = new Round { RoundNumber = 1, Tables = new List<Table> { table } };
            
            var scheme0 = new Scheme { NumberOfPlayers = 4, NumberOfTables = 1, NumberORounds = 1, Rounds = new List<Round> { round } };
            var isScheme0Correct = scheme0.Check();
            var scheme1 = schemeGenerator.GenerateNewScheme(scheme0);
            var isScheme1Correct = scheme1.Check();
            var scheme2 = schemeGenerator.GenerateNewScheme(scheme1);
            var isScheme2Correct = scheme2.Check();
            var scheme3 = schemeGenerator.GenerateNewScheme(scheme2);
            var isScheme3Correct = scheme3.Check();

            schemeSaver.SaveScheme(scheme0, Directory.GetCurrentDirectory());
            schemeSaver.SaveSchemeForEachPlayer(scheme0, Directory.GetCurrentDirectory());

            schemeSaver.SaveScheme(scheme1, Directory.GetCurrentDirectory());
            schemeSaver.SaveSchemeForEachPlayer(scheme1, Directory.GetCurrentDirectory());
            schemeSaver.SaveScheme(scheme2, Directory.GetCurrentDirectory());
            schemeSaver.SaveSchemeForEachPlayer(scheme2, Directory.GetCurrentDirectory());
            schemeSaver.SaveScheme(scheme3, Directory.GetCurrentDirectory());
            schemeSaver.SaveSchemeForEachPlayer(scheme3, Directory.GetCurrentDirectory());

        }
    }

}
