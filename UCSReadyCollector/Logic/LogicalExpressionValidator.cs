using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSReadyCollector.Logic
{
    class LogicalExpressionValidator
    {
        public bool Validate(string expressionString)
        {
            if (expressionString.Where(c => c == '(').Count() != expressionString.Where(c => c == ')').Count())
            {
                throw new FormatException("Количество открывающих и закрывающих скобок не совпадает");
            }

            return true;
        }
    }
}
