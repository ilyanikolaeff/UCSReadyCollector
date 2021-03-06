using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSReadyCollector.Logic
{
    class StringPreprocessor
    {
        public string Preprocess(string expressionString)
        {
            RemoveSpaces(ref expressionString);
            return expressionString;
        }

        private void RemoveSpaces(ref string expressionString)
        {
            // Удаляем все пробелы, оставляю только значащие знаки
            expressionString = expressionString.Replace(" ", "");
        }
    }
}
