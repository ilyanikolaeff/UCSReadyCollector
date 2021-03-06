using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSReadyCollector
{
    /// <summary>
    /// "Узел" готовности
    /// </summary>
    class ReadinessNode : Readiness
    {
        private List<Readiness> _childReadinesses = new List<Readiness>();


        public ReadinessNode(int id, string name) : base(id, name)
        {

        }

        public override void Add(Readiness currentReadiness)
        {
            _childReadinesses.Add(currentReadiness);
        }

        public override void Remove(Readiness currentReadiness)
        {
            _childReadinesses.Remove(currentReadiness);
        }

        public override void Show()
        {
            Console.WriteLine($"Node: {Name}");
            Console.WriteLine($"Elements: ");
            foreach (var ready in _childReadinesses)
                ready.Show();
        }
    }
}
