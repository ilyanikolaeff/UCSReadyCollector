using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UCSReadyCollector.Logic.TokensDictionary;

namespace UCSReadyCollector.Logic
{
    class Tokenizer
    {
        public List<Token> Tokenize(string expressionString)
        {
            var tokens = new List<Token>();

            for (int i = 0; i < expressionString.Length; i++)
            {
                var currentChar = expressionString[i];
                var nextChar = (i + 1 < expressionString.Length) ? expressionString[i + 1] : '\0';

                // Is it operation
                var currentCharTokenType = GetOperationTokenType(currentChar.ToString());
                var withNextCharTokenType = GetOperationTokenType(currentChar.ToString() + nextChar.ToString());
                // Finded token for current char. Need check tokenType for string = (currentChar + nextChar)
                if (currentCharTokenType != TokenType.None)
                {
                    if (withNextCharTokenType != TokenType.None)
                    {
                        tokens.Add(TokensFactory.CreateToken(withNextCharTokenType, null));
                        i++;
                    }
                    else
                    {
                        tokens.Add(TokensFactory.CreateToken(currentCharTokenType, null));
                    }
                }
                // Not finded token for currentChar, but finded token for current + next char 
                else if (currentCharTokenType == TokenType.None && withNextCharTokenType != TokenType.None)
                {
                    tokens.Add(TokensFactory.CreateToken(withNextCharTokenType, null));
                    i++;
                }
                // Number
                else if (char.IsDigit(currentChar))
                {
                    tokens.Add(TokensFactory.CreateToken(TokenType.Number, 
                        CollectComplexToken(expressionString.Substring(i, expressionString.Length - i), ref i, c => char.IsDigit(c))));
                }
                // Function (string)
                else if (char.IsLetter(currentChar))
                {
                    tokens.Add(TokensFactory.CreateToken(TokenType.Function,
                        CollectComplexToken(expressionString.Substring(i, expressionString.Length - i), ref i, c => char.IsLetter(c))));
                }
                // Operand
                else if (currentChar == '#')
                {
                    tokens.Add(TokensFactory.CreateToken(TokenType.Operand, 
                        CollectComplexToken(expressionString.Substring(i, expressionString.Length - i), ref i, c => char.IsDigit(c) || c == '#')));
                }
            }
            return tokens;
        }

        private string CollectComplexToken(string expressionSubString, ref int currentIndex, Func<char, bool> predicate)
        {
            string buffer = string.Empty;
            for (int i = 0; i < expressionSubString.Length; i++)
            {
                if (predicate(expressionSubString[i]))
                {
                    buffer += expressionSubString[i];
                }
                else
                {
                    currentIndex += --i;
                    break;
                }
            }
            return buffer;
        }
    }
}
