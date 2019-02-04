namespace FOSC
{
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
