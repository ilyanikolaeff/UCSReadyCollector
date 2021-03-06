using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSReadyCollector.Logic
{
    interface ILogicalExpression
    {
        bool? Evaluate();
    }
}
