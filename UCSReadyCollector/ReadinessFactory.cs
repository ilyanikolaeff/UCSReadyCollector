using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSReadyCollector
{
    public static class ReadinessFactory
    {
        static Readiness Create(int id, string name, ReadinessType readinessType)
        {
            if (readinessType == ReadinessType.Node)
                return new ReadinessNode(id, name);
            if (readinessType == ReadinessType.Leaf)
                return new ReadinessLeaf(id, name);

            return null;
        }
    }

    enum ReadinessType
    {
        Node,
        Leaf
    }
}
