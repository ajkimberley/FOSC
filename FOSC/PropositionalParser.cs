using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FOSC
{
    /***** BNR Grammar of Basic Propositional Calculus *****/
    // <Wff>        ::= <Proposition> <Wff'>
    // <Wff'>       ::= <Connective> <Wff> | null
    // <proposition>::= 'P' | 'Q' | 'R'
    // <connective> ::= '&' | 'V' | '>'

    public class PropositionalParser
    {
        // Declare an enumerated container of Tokens
        private readonly IEnumerator<Token> _tokens;

        // Declare a constructor for the parser which takes an enumerable colection of Tokens and enumerates it
        public PropositionalParser(IEnumerable<Token> tokens)
        {
            _tokens = tokens.GetEnumerator();
            _tokens.MoveNext();
        }

        public bool ParseWff()
        {
            while (!(_tokens.Current is null))
            {
                if (_tokens.Current is PropVarsToken)
                {
                    _tokens.MoveNext();
                    return ParseWff2();
                }

                else
                {
                    return false;
                }
            }
            return false;
        }

        private bool ParseWff2()
        {
            if (_tokens.Current is BinaryOperatorToken)
            {
                _tokens.MoveNext();
                return ParseWff();
            }

            else if (_tokens.Current is null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}