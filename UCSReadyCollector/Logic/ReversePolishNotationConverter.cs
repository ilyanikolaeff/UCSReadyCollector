using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UCSReadyCollector.Logic.TokensDictionary;

namespace UCSReadyCollector.Logic
{
    class ReversePolishNotationConverter
    {
        public Queue<Token> Convert(IEnumerable<Token> infixTokens)
        {
            Queue<Token> outputQueue = new Queue<Token>();
            Stack<Token> operatorsStack = new Stack<Token>();

            foreach (var token in infixTokens)
            {
                if (Token.IsOperator(token))
                {
                    if (operatorsStack.Count > 0 && token.Type != TokenType.LeftBracket)
                    {
                        if (token.Type == TokenType.RightBracket)
                        {
                            var popToken = operatorsStack.Pop();
                            while (popToken.Type != TokenType.LeftBracket)
                            {
                                outputQueue.Enqueue(popToken);
                                popToken = operatorsStack.Pop();
                            }
                        }
                        else if (token.Priority > operatorsStack.Peek().Priority)
                            operatorsStack.Push(token);
                        else
                        {
                            while (operatorsStack.Count > 0 && token.Priority <= operatorsStack.Peek().Priority)
                                outputQueue.Enqueue(operatorsStack.Pop());
                            operatorsStack.Push(token);
                        }
                    }
                    else
                        operatorsStack.Push(token);
                }
                else
                    outputQueue.Enqueue(token);
            }

            if (operatorsStack.Count > 0)
                foreach (var token in operatorsStack)
                    outputQueue.Enqueue(token);


            return outputQueue;
        }
    }
}
