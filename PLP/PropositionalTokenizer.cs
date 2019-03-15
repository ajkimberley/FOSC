using System;
using System.Collections.Generic;
using System.IO;

namespace PLP
{
    /***** BNR Grammar of Basic Propositional Calculus *****/
    // <formula>        ::= <proposition> | (<formula> <connective> <formula>)
    // <proposition>    ::= 'P' | 'Q' | 'R'
    // <connective>     ::= '&' | 'V' | '>'
   
    public class PropositionalTokenizer
    
        /***** Propositional Tokenizer *****/
        // The Propositional Tokenizer class scans a string from left-to-right and classifies each of the characters within that string as an instance of its associated class
        // Upon classifying a character as an instance of a class it adds an object of that class-type to a list
        // This list is then utilised by the Propositonal Parser, which determines whether the list of objects constitutes a well-formed formula
    
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

                // If c is a Left Bracket, add left bracket to tokens
                else if (c == '(')
                {
                    tokens.Add(new LeftBracketToken());
                    _reader.Read();
                }

                // If c is a Right Bracket, add right bracket to tokens
                else if (c == ')')
                {
                    tokens.Add(new RightBracketToken());
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
