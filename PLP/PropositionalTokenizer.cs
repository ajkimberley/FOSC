using System;
using System.Collections.Generic;
using System.IO;

namespace PLP
{
    /***** BNR Grammar of Basic Propositional Calculus *****/
    // <formula>        ::= '(' <formula> <connective> <formula> ')'
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
                var c = (char)_reader.Read();

                // If c is a blank space, continue reading
                if (Char.IsWhiteSpace(c))
                {
                    continue;
                }

                switch (c)
                {
                    // If c is 'P', 'Q', or 'R', add a propositional variable token to tokens
                    case 'P':
                    case 'Q':
                    case 'R':
                        tokens.Add(new PropVarsToken());
                        break;
                    // If c is 'V', '&', or '>', add a binary operator token to tokens
                    case 'V':
                    case '&':
                    case '>':
                        tokens.Add(new BinaryOperatorToken());
                        break;
                    // If c is '(', add a left bracket token to tokens
                    case '(':
                        tokens.Add(new LeftBracketToken());
                        break;
                    // if c is ')', add a right bracket token to tokens
                    case ')':
                        tokens.Add(new RightBracketToken());
                        break;
                    default:
                        // Otherwise throw an exception
                        throw new Exception("Unkown character in expression: " + c);
                }
                
            }
            // return tokens
            return tokens;
        }
    }
}
