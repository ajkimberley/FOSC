using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOSC
{
    /***** BNR Grammar of Basic Propositional Calculus *****/
    // <formula>        ::= <proposition> | (<formula> <connective> <formula>)
    // <proposition>    ::= 'P' | 'Q' | 'R'
    // <connective>     ::= '&' | 'V' | '>'
    public class PropositionalParser
    {
        private readonly IEnumerator<Token> _tokens;

        public PropositionalParser(IEnumerable<Token> tokens)
        {
            _tokens = tokens.GetEnumerator();
        }

        private bool ParseExpression()
        {
            var prop = ParseProp();
            if (!_tokens.MoveNext())
            {
                return prop;
            }

            if (_tokens.Current is BinaryOperatorToken)
            {
                _tokens.MoveNext();
                var prop2 = ParseProp();
                return prop2;
            }
            else
            {
                return false;
            }
        }

        private bool ParseProp()
        {
            if (_tokens.Current is PropVarsToken)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Parse()
        {
            var result = false;
            while (_tokens.MoveNext())
            {
                result = ParseExpression();

                if (_tokens.MoveNext())
                {
                    result = Parse();
                }
            }
            return result;
        }
    }
}
