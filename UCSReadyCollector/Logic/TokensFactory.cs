using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UCSReadyCollector.Logic.TokensDictionary;

namespace UCSReadyCollector.Logic
{
    internal static class TokensFactory
    {
        internal static Token CreateToken(TokenType tokenType, string tokenValue)
        {
            Token token = null;
            var tryGetValueResult = TokenTypesConformity.TryGetValue(tokenType, out Func<Token> tokenCreatorFunc);
            if (tryGetValueResult)
            {
                token = tokenCreatorFunc();
                token.Type = tokenType;
                token.Value = tokenValue;
                token.Priority = TokenTypesPriority[tokenType];
            }
            return token;
        }
    }
}
