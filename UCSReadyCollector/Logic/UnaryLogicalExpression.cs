using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSReadyCollector.Logic
{
    class UnaryLogicalExpression : LogicalExpression
    {
        public object Operand { get; set; }
        public UnaryOperationType OperationType { get; set; }

        public UnaryLogicalExpression(object operand, UnaryOperationType operationType)
        {
            Operand = operand;
            OperationType = operationType;
        }

        public UnaryLogicalExpression()
        {

        }

        public override bool? Evaluate()
        {
            return true;
        }
    }
}
