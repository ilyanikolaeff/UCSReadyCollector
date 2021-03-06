using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSReadyCollector.Logic
{
    class LogicalExpressionParser
    {
        private Tokenizer _tokenizer;
        private LogicalExpressionValidator _validator;
        private ReversePolishNotationConverter _rpnConverter;
        public LogicalExpressionParser(LogicalExpressionValidator validator, Tokenizer tokenizer, ReversePolishNotationConverter rpnConverter)
        {
            _validator = validator;
            _tokenizer = tokenizer;
            _rpnConverter = rpnConverter;
        }

        public LogicalExpression Parse(string expressionString)
        {
            // 1. Валидация выражения
            if (!_validator.Validate(expressionString))
                return null;
            // 2. Токенетизация валидированного выражения
            var tokens = _tokenizer.Tokenize(expressionString);
            // 3. Преобразовываем в ОПЗ
            var rpnTokens = _rpnConverter.Convert(tokens);
            // 4. Собственно парсинг на дерево логических выражений
            var logicalExpression = ParseRpnTokens(rpnTokens);

            return logicalExpression;
        }

        private LogicalExpression ParseRpnTokens(Queue<Token> tokens)
        {
            Stack<object> stack = new Stack<object>();
            Queue<Token> queue = new Queue<Token>(tokens);

            Token currentToken = queue.Dequeue();
            while (queue.Count >= 0)
            {
                if (!Token.IsOperator(currentToken))
                {
                    stack.Push(currentToken);
                    currentToken = queue.Dequeue();
                }
                else
                {
                    LogicalExpression logicalExpression = null;
                    if (Token.IsBinaryOperation(currentToken))
                    {
                        logicalExpression = new BinaryLogicalExpression();
                        ((BinaryLogicalExpression)logicalExpression).OperationType = LogicalOperationType.GetBinaryOperationTypeByTokenType(currentToken.Type);
                        ((BinaryLogicalExpression)logicalExpression).RightOperand = stack.Pop();
                        ((BinaryLogicalExpression)logicalExpression).LeftOperand = stack.Pop();
                    }
                    else if (Token.IsUnaryOperation(currentToken))
                    {
                        logicalExpression = new UnaryLogicalExpression();
                        ((UnaryLogicalExpression)logicalExpression).OperationType = LogicalOperationType.GetUnaryOperationTypeByTokenType(currentToken.Type);
                        ((UnaryLogicalExpression)logicalExpression).Operand = stack.Pop();
                    }

                    //if (logicalExpression != null)
                        stack.Push(logicalExpression);

                    if (queue.Count > 0)
                        currentToken = queue.Dequeue();
                    else
                        break;
                }
            }

            return stack.Pop() as LogicalExpression;
        }
    }
}
