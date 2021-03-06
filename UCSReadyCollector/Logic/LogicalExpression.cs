using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UCSReadyCollector.Logic;

namespace UCSReadyCollector.Logic
{
    abstract class LogicalExpression : ILogicalExpression
    {
        public abstract bool? Evaluate();
    }
}
