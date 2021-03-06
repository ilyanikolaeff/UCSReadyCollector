using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UCSReadyCollector.Logic.TokensDictionary;

namespace UCSReadyCollector.Logic
{
    public abstract class Token : IEquatable<Token>
    {
        public string Value { get; set; }
        public TokenType Type { get; set; }
        public int Priority { get; set; }
        public Associativity Associativity { get; set; }

        public bool Equals(Token other)
        {
            return (Type == other.Type) && (Value == other.Value);
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Value) ? $"[{Type}]" : $"[{Type} - {Value}]";
        }

        public static bool IsOperator(Token token)
        {
            return token is OperationToken;
        }

        public static bool IsBinaryOperation(Token token)
        {
            return token is BinaryOperationToken;
        }

        public static bool IsUnaryOperation(Token token)
        {
            return token is UnaryOperationToken;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns>1 - binary, -1 - unary, 0 - other</returns>
        public static int GetTypeOfToken(Token token)
        {
            if (token is BinaryOperationToken)
                return 1;
            else if (token is UnaryOperationToken)
                return -1;
            else
                return 0;
        }
    }

    abstract class OperationToken : Token
    { }
    internal sealed class NumberToken : Token
    { }
    internal sealed class FunctionToken : Token
    { }
    internal sealed class OperandToken : Token
    { }
    internal sealed class SeparateOperationToken : OperationToken
    { }
    class MathOperationToken : OperationToken
    { }
    internal abstract class BinaryOperationToken : OperationToken
    { }
    internal sealed class BinaryLogicalOperationToken : BinaryOperationToken
    { }
    internal sealed class BinaryBitwiseOperationToken : BinaryOperationToken
    { }
    internal abstract class UnaryOperationToken : OperationToken
    { }
    internal sealed class UnaryLogicalOperationToken : UnaryOperationToken
    { }
    internal sealed class UnaryBitwiseOperationToken : UnaryOperationToken
    { }
}
