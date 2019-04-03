namespace PLP
{   
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
    /// <summary>
    /// This file declares a number of empty base and inherrited classes which are utilised by the tokenizer and the parser
    /// The purpose of these classes is to enable the creation of objects which represent the various elements of the grammar of propositional logic
    /// This creates a layer of abstraction from the string input which enables the enoding of heirachical representation
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public abstract class Token
    {

    }

    public class BinaryOperatorToken : Token
    {

    }

    public class ConjunctionToken : BinaryOperatorToken
    {

    }

    public class DisjunctionToken : BinaryOperatorToken
    {

    }

    public class ConditionalToken : BinaryOperatorToken
    {

    }

    public class PunctuationToken : Token
    {

    }

    public class LeftBracketToken : PunctuationToken
    {

    }

    public class RightBracketToken : PunctuationToken
    {
        
    }

    public class PropVarsToken : Token
    {

    }
}
