using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PLP
{
    /////////////////////////////////////////////////////////////////
    // BNR Grammar of Basic Propositional Calculus
    //
    // <wff>            ::= <atomic formula> | <complex formula>
    // <atomic formula> ::= <proposition>
    // <coplex formula> ::= '(' <wff> <onnective> <wff> ')'
    // <proposition>    ::= 'P' | 'Q' | 'R'
    // <connective>     ::= '&' | 'V' | '>'
    /////////////////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Implements a recursive descent parser which tries to validate a given list of tokens as a well-formed formula of the propositional calculus
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PropositionalParser
    {
        // Decalres a readonly enumeration of tokens
        private readonly IEnumerator<Token> _tokens;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Declares a constructor for the parser which takes an enumerable colection of tokens and enumerates it
        /// </summary>
        /// <param name="tokens">An enumerable collection of tokens</param>
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        public PropositionalParser(IEnumerable<Token> tokens)
        {
            _tokens = tokens.GetEnumerator();
            _tokens.MoveNext();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The main method of the parser which returns true if and only the user enters a valid well-formed formula without trailing tokens.
        /// </summary>
        /// <remarks>
        /// This method is necessary in order to ensure that well-formed formulas with trailing tokens are rejected.
        /// E.g., whilst the string "(P&P)" is a well-formed formula, the string "(P&P)P" is not.
        /// </remarks>
        /// <returns>
        /// True if and only if the string passed by the user is a well-formed formula without trailing tokens.
        /// False otherwise.
        /// </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool Parse()
        {
            if (ParseWff() & _tokens.Current is null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Attempts to parse the users input as a well-formed formula.
        /// </summary>
        /// <remarks>
        /// This function will return true if the user inputs a well-formed formula with trailing tokens.
        /// Hence why the <code>Parse()</code> fucntion is required.
        /// See: <see cref="PLP.PropositionalParser.Parse()"/>
        /// </remarks>
        /// <returns>
        /// True if the input is a well-formed formula
        /// False otherwise
        /// </returns>
        /////////////////////////////////////////////////////////////////////////////////////////////////
        private bool ParseWff()
        {
            if (ParseAtomicFormula())
            {
                return true;
            }
            else if (ParseComplexFormula())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Attempts to parse an atomic formula.
        /// </summary>
        /// <returns>
        /// True if and only if the the relevant sub-expression is an atomic proposition.
        /// False otherwise.
        /// </returns>
        //////////////////////////////////////////////////////////////////////////////////
        private bool ParseAtomicFormula()
        {
            if (ParseProposition())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Attempts to parse a complex formula.
        /// </summary>
        /// <returns>
        /// True if and only if the relevant sub-expression is a complex proposition.
        /// False otherwise.
        /// </returns>
        //////////////////////////////////////////////////////////////////////////////
        private bool ParseComplexFormula()
        {
            if (_tokens.Current is LeftBracketToken)
            {
                _tokens.MoveNext();
                if (ParseWff() & ParseConnective() & ParseWff())
                {
                    if (_tokens.Current is RightBracketToken)
                    {
                        _tokens.MoveNext();
                        return true;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Attempts to parse a proposiional variable.
        /// </summary>
        /// <returns>
        /// True if the current token is a propositional variable.
        /// False otherwise.
        /// </returns>
        ////////////////////////////////////////////////////////////
        private bool ParseProposition()
        {
            if (_tokens.Current is PropVarsToken)
            {
                _tokens.MoveNext();
                return true;
            }
            else
            {
                return false;
            }
        }

        ////////////////////////////////////////////////////
        /// <summary>
        /// Attempts to parse a binary operator.
        /// </summary>
        /// <returns>
        /// True if the current token is a binary operator.
        /// False otherwise.
        /// </returns>
        ///////////////////////////////////////////////////
        private bool ParseConnective()
        {
            if (_tokens.Current is BinaryOperatorToken)
            {
                _tokens.MoveNext();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}