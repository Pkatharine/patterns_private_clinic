using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    //Будівельник вимальовує стандартний процес створення складного
//об’єкта, розділяючи логіку будування об’єкта від його представлення.
    enum Count
    {
        oneCount,
        moreCount
    }

    enum Type
    {
        therapy,
        relax,
        cosmetic
    }

    enum City
    {
        Chernivtsi,
        Ternopil
    }


    class Procedure
    {
        public Count count { get; set; }
        public Type type { get; set; }
        public City city { get; set; }

        public string ShowInfo()
        {
            return count + " - " + type + " - " + city;
        }
    }

        abstract class SetterProcedure
        {
            public abstract void setCount();
            public abstract void setType();
            public abstract void setCity();
            public abstract Procedure Procedure { get; set; }
        }

        class ChernivtsiProcedureOneRelax : SetterProcedure
        {
            Procedure procedure = new Procedure();

            public override Procedure Procedure
            {
                get
                {
                    return procedure;
                }
                set
                {
                    procedure = value;
                }
            }

            public override void setCity()
            {
                procedure.city = City.Chernivtsi;
            }

            public override void setType()
            {
                procedure.type = Type.relax;
            }

            public override void setCount()
            {
                procedure.count = Count.oneCount;
            }

        }


        class ProcedureService
        {
            SetterProcedure startproc;

            public ProcedureService(SetterProcedure startproc)
            {
                this.startproc = startproc;
            }

            public void settProc()
            {
                startproc.setCount();
                startproc.setType();
                startproc.setCity();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                SetterProcedure starter = new ChernivtsiProcedureOneRelax();
                //Starter starter = new OldSiteJavaPlusAngularPlusMongo();
                ProcedureService siteService = new ProcedureService(starter);
                siteService.settProc();

                Procedure proc = starter.Procedure;
                Console.WriteLine(proc.ShowInfo());

                Console.ReadKey();
            }
        }
    
}
