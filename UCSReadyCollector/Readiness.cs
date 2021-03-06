using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSReadyCollector
{
    /// <summary>
    /// Абстрактный класс готовности
    /// </summary>
    public abstract class Readiness
    {
        /// <summary>
        /// Неуникальный номер готовности
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Имя готовности
        /// </summary>
        protected string Name { get; set; }

        public Readiness(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public virtual void Add(Readiness currentReadiness) { }
        public virtual void Remove(Readiness currentReadiness) { }
        public virtual void Show() 
        {
            Console.WriteLine($"ID: {ID}; Name: {Name}");
        }
    }
}
