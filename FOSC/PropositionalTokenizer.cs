using System;
using System.Collections.Generic;
using System.IO;

namespace FOSC
{
    /***** BNR Grammar of Basic Propositional Calculus *****/
    // <formula>        ::= <proposition> | (<formula> <connective> <formula>)
    // <proposition>    ::= 'P' | 'Q' | 'R'
    // <connective>     ::= '&' | 'V' | '>'
    public class PropositionalTokenizer
    {
        private StringReader _reader;

        public IEnumerable<Token> Scan(string expression)
        {
            _reader = new StringReader(expression);

            var tokens = new List<Token>();

            while (_reader.Peek() != -1)
            {
                // Add the currently read character to variable 'c'
                var c = (char)_reader.Peek();

                // If c is a blank space, continue reading
                if (Char.IsWhiteSpace(c))
                {
                    _reader.Read();
                    continue;
                }

                // If c is a Propositional Variable, add a PropVarsToken to tokens
                if (c == 'P' | c == 'Q' | c == 'R')
                {
                    tokens.Add(new PropVarsToken());
                    _reader.Read();
                }

                // If c is a Conjunction connective, add a ConjunctionToken to tokens

                else if (c == '&')
                {
                    tokens.Add(new ConjunctionToken());
                    _reader.Read();
                }

                // If c is a Disjunction connective, add a disjunction to tokens
                else if (c == 'V')
                {
                    tokens.Add(new DisjunctionToken());
                    _reader.Read();
                }

                // If c is a Conditional connective, add a conditional to tokens
                else if (c == '>')
                {
                    tokens.Add(new ConditionalToken());
                    _reader.Read();
                }

                // Otherwise throw an exception
                else
                    throw new Exception("Unkown character in expression: " + c);
            }
            // return tokens
            return tokens;
        }
    }
}
