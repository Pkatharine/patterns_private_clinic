using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class TherapyProcedure : Procedure
    {
        public TherapyProcedure(string name, int uniqueId)
            : base(name, uniqueId)
        {
            Console.WriteLine("Procedure id #" + ProcedureNumber + " | Purchased for " + name + " | uniqueId " + uniqueId);
        }
    }

    class CosmeticProcedure : Procedure
    {
        public CosmeticProcedure(string name, int uniqueId)
            : base(name, uniqueId)
        {
            Console.WriteLine("Procedure id #" + ProcedureNumber + " | Purchased for " + name + " | uniqueId " + uniqueId);
        }
    }

    abstract class Procedure
    {
        public string Name { get; set; }
        public int UniqueId { get; set; }
        public object ProcedureNumber { get; set; }

        protected Procedure(string name, int uniqueId)
        {
            Name = name;
            UniqueId = uniqueId;
            ProcedureNumber = GetHashCode();
        }
    }

    class TherapyProcedureService : ReceptionService
    {
        public TherapyProcedureService(string name, int uniqueId) 
            : base(name, uniqueId)
        {
        }

        public override Procedure Buy()
        {
            return new TherapyProcedure(Name, UniqueId);
        }
    }
    /*
     Фабричний Метод вирішує, яку реалізацію інстанціювати. Вирішують
або нащадки фабричного методу, або він сам, приймаючи якийсь
параметер.
*/
    class CosmeticProcedureService : ReceptionService
    {
        public CosmeticProcedureService(string name, int uniqueId) 
            : base(name, uniqueId)
        {
        }

        public override Procedure Buy()
        {
            return new CosmeticProcedure(Name, UniqueId);
        }
    }

    abstract class ReceptionService
    {
        public string Name { get; set; }
        public int UniqueId { get; set; }

        protected ReceptionService(string name, int uniqueId)
        {
            Name = name;
            UniqueId = uniqueId;
        }

        abstract public Procedure Buy();
    }

    class Program
    {
        static void Main(string[] args)
        {
            ReceptionService proc = new CosmeticProcedureService("Katya", 1);
            proc.Buy();

            proc = new TherapyProcedureService("Lena", 2);
            proc.Buy();

            Console.ReadKey();
        }
    }
}
