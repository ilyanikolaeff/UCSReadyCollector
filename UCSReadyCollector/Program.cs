using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSReadyCollector.Logic;

namespace UCSReadyCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new ReadinessNode(1, "Готовность к тесту на режим 123");
            var inNode1 = new ReadinessNode(1, "Задвижки готовы");
            var inNode2 = new ReadinessNode(2, "Задвижки не готовы");
            var leaf1 = new ReadinessLeaf(1, "Задвижка №1");
            var leaf2 = new ReadinessLeaf(2, "Задвижка №2");
            var leaf3 = new ReadinessLeaf(3, "Задвижка №3");
            var leaf4 = new ReadinessLeaf(4, "Задвижка №4");
            var leaf5 = new ReadinessLeaf(5, "Задвижка №1");
            var leaf6 = new ReadinessLeaf(6, "Задвижка №2");
            var leaf7 = new ReadinessLeaf(7, "Задвижка №3");
            var leaf8 = new ReadinessLeaf(8, "Задвижка №4");

            node.Add(inNode1);
            node.Add(inNode2);

            inNode1.Add(leaf1);
            inNode1.Add(leaf2);
            inNode1.Add(leaf7);

            inNode2.Add(leaf4);
            inNode2.Add(leaf5);


            node.Show();

            var expressionString = "((#1 || #2) || #3) && !(#4) || (count == 6) || (#7 == 8)";
            //var expressionString = "(#2 == 3) || (#1 != 1)";
            //var expressionString = "(()())";
            var logicalExpressionParser = new LogicalExpressionParser(new LogicalExpressionValidator(), new Tokenizer(), new ReversePolishNotationConverter());

            var tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize(expressionString);

            var rpnConverter = new ReversePolishNotationConverter();
            var convertedTokens = rpnConverter.Convert(tokens);


            var expression = logicalExpressionParser.Parse(expressionString);




            Console.ReadKey();
        }
    }
}
