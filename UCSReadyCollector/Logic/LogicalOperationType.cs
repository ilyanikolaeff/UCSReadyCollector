using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UCSReadyCollector.Logic.TokensDictionary;

namespace UCSReadyCollector.Logic
{
    public static class LogicalOperationType
    {
        private static Dictionary<TokenType, BinaryOperationType> _binaryOperationsConformity = new Dictionary<TokenType, BinaryOperationType>()
        {
            { TokenType.Equal, BinaryOperationType.Equal },
            { TokenType.NotEqual, BinaryOperationType.NotEqual },
            { TokenType.GreaterThan, BinaryOperationType.GreaterThan },
            { TokenType.LessThan, BinaryOperationType.LessThan },
            { TokenType.GreaterThanOrEqual, BinaryOperationType.GreaterThanOrEqual },
            { TokenType.LessThanOrEqual, BinaryOperationType.LessThanOrEqual },
            { TokenType.LogicAnd, BinaryOperationType.LogicAnd },
            { TokenType.LogicOr, BinaryOperationType.LogicOr },

            { TokenType.BitwiseAnd, BinaryOperationType.BitwiseAnd },
            { TokenType.BitwiseOr, BinaryOperationType.BitwiseOr },
            { TokenType.BitwiseLeftShift, BinaryOperationType.BitwiseLeftShift },
            { TokenType.BitwiseRightShift, BinaryOperationType.BitwiseRightShift }
        };

        private static Dictionary<TokenType, UnaryOperationType> _unaryOperationsConformity = new Dictionary<TokenType, UnaryOperationType>()
        {
            { TokenType.LogicNot, UnaryOperationType.LogicNot },
            { TokenType.BitwiseNot, UnaryOperationType.BitwiseNot }
        };

        internal static BinaryOperationType GetBinaryOperationTypeByTokenType(TokenType tokenType)
        {
            return _binaryOperationsConformity[tokenType];
        }

        internal static UnaryOperationType GetUnaryOperationTypeByTokenType(TokenType tokenType)
        {
            return _unaryOperationsConformity[tokenType];
        }


    }

    internal enum BinaryOperationType
    {
        Equal,
        NotEqual,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        LogicAnd,
        LogicOr,

        BitwiseAnd,
        BitwiseOr,
        BitwiseLeftShift,
        BitwiseRightShift
    }
    enum UnaryOperationType
    {
        LogicNot,
        BitwiseNot
    }
}
