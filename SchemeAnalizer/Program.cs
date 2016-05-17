using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemeAnalizer
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        public bool isArgsCorrect (string[] args)
        {
            if (args.Length != 2)
            {
                return false;
            }

            return true;
        }
    }
}
