using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSReadyCollector.Logic
{
    public class TokensDictionary
    {
        private static Dictionary<string, TokenType> _logicalBinaryOperations = new Dictionary<string, TokenType>()
        {
            { "==", TokenType.Equal },
            { "!=", TokenType.NotEqual },
            { "<", TokenType.LessThan },
            { "<=", TokenType.LessThanOrEqual },
            { ">", TokenType.GreaterThan },
            { ">=", TokenType.GreaterThanOrEqual },
            { "&&", TokenType.LogicAnd },
            { "||", TokenType.LogicOr },

        };

        private static Dictionary<string, TokenType> _logicalUnaryOperations = new Dictionary<string, TokenType>()
        {
            { "!", TokenType.LogicNot }
        };

        private static Dictionary<string, TokenType> _bitwiseBinaryOperations = new Dictionary<string, TokenType>()
        {
            { "&", TokenType.BitwiseAnd },
            { "|", TokenType.BitwiseOr },
            { "<<", TokenType.BitwiseLeftShift },
            { ">>", TokenType.BitwiseRightShift }
        };

        private static Dictionary<string, TokenType> _bitwiseUnaryOperations = new Dictionary<string, TokenType>()
        {
            { "~", TokenType.BitwiseNot }
        };

        private static Dictionary<string, TokenType> _mathOperations = new Dictionary<string, TokenType>();

        private static Dictionary<string, TokenType> _separators = new Dictionary<string, TokenType>()
        {
            { "(", TokenType.LeftBracket },
            { ")", TokenType.RightBracket }
        };


        public static TokenType GetOperationTokenType(string currentAnalysisElement)
        {
            // check for logical binary operations
            if (_logicalBinaryOperations.ContainsKey(currentAnalysisElement))
                return _logicalBinaryOperations[currentAnalysisElement];
            // check for logical unary
            if (_logicalUnaryOperations.ContainsKey(currentAnalysisElement))
                return _logicalUnaryOperations[currentAnalysisElement];
            // check for bitwise binary
            else if (_bitwiseBinaryOperations.ContainsKey(currentAnalysisElement))
                return _bitwiseBinaryOperations[currentAnalysisElement];
            // check for bitwise unary
            else if (_bitwiseUnaryOperations.ContainsKey(currentAnalysisElement))
                return _bitwiseUnaryOperations[currentAnalysisElement];
            else if (_bitwiseUnaryOperations.ContainsKey(currentAnalysisElement))
                return _bitwiseUnaryOperations[currentAnalysisElement];
            // check for math operations

            // check for comma (separator)
            else if (_separators.ContainsKey(currentAnalysisElement))
                return _separators[currentAnalysisElement];
            //// check for number
            //else if (currentAnalysisElement.All(p => char.IsDigit(p)))
            //    return TokenType.Number;
            //// check for function
            //else if (currentAnalysisElement.All(p => char.IsLetter(p)))
            //    return TokenType.Function;
            //// check for operand
            //else if (currentAnalysisElement.StartsWith("#"))
            //    return TokenType.Operand;
            else
                return TokenType.None;
        }


        public static Dictionary<TokenType, Func<Token>> TokenTypesConformity = new Dictionary<TokenType, Func<Token>>()
        {
            // logical
            { TokenType.Equal, () => new BinaryLogicalOperationToken() },
            { TokenType.NotEqual, () => new BinaryLogicalOperationToken() },
            { TokenType.GreaterThan, () => new BinaryLogicalOperationToken() },
            { TokenType.LessThan, () => new BinaryLogicalOperationToken() },
            { TokenType.GreaterThanOrEqual, () => new BinaryLogicalOperationToken() },
            { TokenType.LessThanOrEqual, () => new BinaryLogicalOperationToken() },
            { TokenType.LogicAnd, () => new BinaryLogicalOperationToken() },
            { TokenType.LogicOr, () => new BinaryLogicalOperationToken() },

            { TokenType.LogicNot, () => new UnaryLogicalOperationToken() },

            // bitwise
            { TokenType.BitwiseAnd, () => new BinaryBitwiseOperationToken() },
            { TokenType.BitwiseOr, () => new BinaryBitwiseOperationToken() },
            { TokenType.BitwiseLeftShift, () => new BinaryBitwiseOperationToken() },
            { TokenType.BitwiseRightShift, () => new BinaryBitwiseOperationToken() },

            { TokenType.BitwiseNot, () => new UnaryBitwiseOperationToken() },

            // other
            { TokenType.LeftBracket, () => new SeparateOperationToken() },
            { TokenType.RightBracket, () => new SeparateOperationToken() },
            { TokenType.Number, () => new NumberToken() },
            { TokenType.Function, () => new FunctionToken() },
            { TokenType.Operand, () => new OperandToken() },

        };

        public static Dictionary<TokenType, int> TokenTypesPriority = new Dictionary<TokenType, int>()
        {
            { TokenType.Equal, 5 },
            { TokenType.NotEqual, 5 },
            { TokenType.GreaterThan, 4 },
            { TokenType.LessThan, 4 },
            { TokenType.GreaterThanOrEqual, 4 },
            { TokenType.LessThanOrEqual, 4 },
            { TokenType.LogicAnd, 8 },
            { TokenType.LogicOr, 9 },
            { TokenType.LogicNot, 10 },

            { TokenType.BitwiseAnd, 6 },
            { TokenType.BitwiseOr, 7 },
            { TokenType.BitwiseLeftShift, 3 },
            { TokenType.BitwiseRightShift, 3 },
            { TokenType.BitwiseNot, 1 },

            { TokenType.LeftBracket, 0 },
            { TokenType.RightBracket, 0 },
            { TokenType.Number, 10 },
            { TokenType.Function, 10 },
            { TokenType.Operand, 10 },
        };

        public enum TokenType
        {
            Equal, // ==
            NotEqual, // !=
            GreaterThan, // >
            LessThan, // <
            GreaterThanOrEqual, // >=
            LessThanOrEqual, // <=
            LogicAnd, // &&
            LogicOr, // ||
            LogicNot, // !
            BitwiseAnd, // &
            BitwiseOr, // |
            BitwiseNot, // ~
            BitwiseLeftShift, // <<
            BitwiseRightShift, // >>

            LeftBracket, // (
            RightBracket, // )

            Number, // 1, 2, 3, ..., 10, 11, ..., 100, ...
            Function, // substring - count
            Operand, // #NUMBER
            
            None // token type not found
        }

        public enum Associativity
        {
            Left,
            Right
        }
    }
}
