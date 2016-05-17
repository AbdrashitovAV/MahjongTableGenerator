using System;
using System.IO;

namespace Data
{
    public class SchemeSaver
    {
        public void SaveScheme(Scheme scheme, string dir, string filename = null)
        {
            if (String.IsNullOrEmpty(filename))
                filename = "scheme" + scheme.NumberOfPlayers.ToString().PadLeft(3, '0') + ".txt";

            try
            {
                File.WriteAllText(Path.Combine(dir, filename), scheme.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Can't write data to file {0} in directory {1}", filename, dir));
                Console.WriteLine(e.Message);
            }
        }

        public void SaveSchemeForEachPlayer(Scheme scheme, string dir, string filename = null)
        {
            if (String.IsNullOrEmpty(filename))
                filename = "scheme" + scheme.NumberOfPlayers.ToString().PadLeft(3, '0') + ".players.txt";

            var outputFile = new StreamWriter(Path.Combine(dir, filename));

            outputFile.Write("Round:".PadRight(8));

            for (int i = 1; i <= scheme.NumberORounds; i++)
            {
                outputFile.Write(i.ToString().PadLeft(2).PadRight(4));
            }
            outputFile.Write(Environment.NewLine);

            outputFile.WriteLine("Player");

            for (int i = 1; i <= scheme.NumberOfPlayers; i++)
            {
                outputFile.Write(i.ToString().PadLeft(3).PadRight(8));

                foreach (var pair in scheme.GetSchemeForPlayer(i))
                {
                  outputFile.Write(pair.Value.ToString().PadLeft(2).PadRight(4));   
                }
                outputFile.Write(Environment.NewLine);
            }
            outputFile.Close();
        }
    }
}
