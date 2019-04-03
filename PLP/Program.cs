using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLP
{
    class Program
    {
        ///////////////////////////////////////////////////////////////////////
        /// Function: Main
        /// 
        /// <summary>
        /// Main progam entry point
        /// </summary>
        /// <param name="args">
        /// Command line parameters.
        ///    args[0] is the program name as it appeared on the command line
        ///    args[1..n] are the actual command line parameters
        ///    Find out how many they are using args.Length()
        /// </param>
        ///////////////////////////////////////////////////////////////////////
        static void Main(string[] args)
        {
            Console.WriteLine("Enter formula: ");

            string formula = Console.ReadLine();

            PropositionalTokenizer scanner = new PropositionalTokenizer();

            IEnumerable<Token> tokenisedFormula = scanner.Scan(formula);

            PropositionalParser parser = new PropositionalParser(tokenisedFormula);

            bool wff = parser.Parse();

            if (wff == true)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            Console.ReadKey();
        }
    }
}
