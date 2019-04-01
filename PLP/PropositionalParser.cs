using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PLP
{
    // The following is a refactored grammar for the propositional calculus.
    // The refacotring eliminates right-recursion thereby allowing the implementation of a recursive decsent parser
    // Semanically, this is not ideal, as it severs the tight connection between syntax and semantics achieved by the original grammar
    // An alternative would be to switch from a recursive descent parser to a type of bottom-up parser

    /*****  Refactored BNR Grammar of Basic Propositional Calculus *****/
    // <Wff>        ::= <proposition> | '(' <wff> <conjunction> <wff> ')'
    // <proposition>::= 'P' | 'Q' | 'R'
    // <connective> ::= '&' | 'V' | '>'

    public class PropositionalParser
    {
        /***** Propositional Parser *****/
        // The Propositional Parser class contains two methods for 

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
            bool result = false;

            while (!(_tokens.Current is null))
            {
                if (_tokens.Current is PropVarsToken)
                {
                    result = true;

                    _tokens.MoveNext();

                    if (!(_tokens.Current is PropVarsToken))
                    {
                        return result;
                    }
                    else
                    {
                        return false;
                    }
                }

                else if (_tokens.Current is LeftBracketToken)
                {
                    _tokens.MoveNext();

                    if (ParseWff())
                    {
                        if (_tokens.Current is BinaryOperatorToken)
                        {
                            _tokens.MoveNext();
                            if (ParseWff())
                            {
                                if (_tokens.Current is RightBracketToken)
                                {
                                    _tokens.MoveNext();
                                    result = true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return result;

        }
    }
}