using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSReadyCollector.Logic
{
    class BinaryLogicalExpression : LogicalExpression
    {
        public object LeftOperand { get; set; }
        public object RightOperand { get; set; }
        public BinaryOperationType OperationType { get; set; }

        public BinaryLogicalExpression(object leftOperand, object rightOperand, BinaryOperationType operationType)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            OperationType = operationType;
        }

        public BinaryLogicalExpression()
        {
        }

        public override bool? Evaluate()
        {
            // Проверка операндов на логическое условие
            return true;
        }
    }
}
