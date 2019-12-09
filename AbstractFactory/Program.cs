using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Абстрактна фабрика надає простий інтерфейс для створення об’єктів,
//які належать до того чи іншого сімейства
namespace AbstractFactory
{
    class Client
    {
        private AbstractCity city;
        private AbstractDoctor doctor;

        public Client(CityFactory city)
        {
            this.city = city.CreateCity();
            this.doctor = city.CreateDoctor();
        }

        public void Set()
        {
            city.setDoctorForCity(doctor);
        }
    }

    // abstract factory
    abstract class CityFactory
    {
        public abstract AbstractCity CreateCity();
        public abstract AbstractDoctor CreateDoctor();
    }

    // concrete factory
    class ChernivtsiCityFactory : CityFactory
    {
        public override AbstractCity CreateCity()
        {
            return new ChernivtsiCity();
        }

        public override AbstractDoctor CreateDoctor()
        {
            return new ChernivtsiCityDoctor();
        }
    }

    // concrete factory
    class TernopilCityFactory : CityFactory
    {
        public override AbstractCity CreateCity()
        {
            return new TernopilCity();
        }

        public override AbstractDoctor CreateDoctor()
        {
            return new TernopilCityDoctor();
        }
    }

    // abstract city
    abstract class AbstractCity
    {
        public abstract void setDoctorForCity(AbstractDoctor doctor);
    }

    // abstract ...
    abstract class AbstractDoctor
    {

    }

    class ChernivtsiCity : AbstractCity
    {
        public override void setDoctorForCity(AbstractDoctor doctor)
        {
            Console.WriteLine("For " + this + " set doctor " + doctor);
        }
    }

    class TernopilCity : AbstractCity
    {
        public override void setDoctorForCity(AbstractDoctor doctor)
        {
            Console.WriteLine("For " + this + " set doctor " + doctor);
        }
    }

    class ChernivtsiCityDoctor : AbstractDoctor
    {

    }

    class TernopilCityDoctor : AbstractDoctor
    {

    }

    class Program
    {

        // Абстрактна фабрика надає інтерфейс для створення сімейств 
        // взаємопов'язаних об'єктів з певними інтерфейсами без вказівки конкретних типів даних об'єктів.
        static void Main(string[] args)
        {
            Client client = null;

            client = new Client(new ChernivtsiCityFactory());
            client.Set();

            client = new Client(new TernopilCityFactory());
            client.Set();

            Console.ReadKey();
        }
    }
}
