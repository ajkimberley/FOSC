using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOSC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter formula: ");

            string formula = Console.ReadLine();

            PropositionalTokenizer scanner = new PropositionalTokenizer();

            PropositionalParser parser = new PropositionalParser(scanner.Scan(formula));

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
