using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Прототип дозволяє нам створювати копії об’єктів, що уже визначені на стадії дизайну
//Ми можемо використовувати цей дизайн-патерн для копіювання
//екземплярів об’єктів в час виконання програми, що дозволяє нам уникати
//великої кількості похідних класів
namespace Prototype
{
    class Doctor : User, ICloneable
    {
        // посада
        public string Position { get; set; }

        public Doctor(string name, int age, string position)
            : base(name, age)
        {
            Position = position;
        }

        public override string GetInfo()
        {
            return "Doctor\nName: " + Name + "\nAge: " + Age + "\nPosition: " + Position;
        }
        
        public object Clone()
        {
            return new Doctor(Name, Age, Position);
        }
        

        public override User CloneObject()
        {
            throw new InvalidOperationException();
        }
    }

    class Client : User
    {
        public int MedicalCardNumber { get; set; }

        public Client(string name, int age, int medicalCardNumber)
            : base(name, age)
        {
            MedicalCardNumber = medicalCardNumber;
        }

        public override User CloneObject()
        {
            return new Client(Name, Age, MedicalCardNumber);
        }

        public override string GetInfo()
        {
            return "Client\nName: " + Name + "\nAge: " + Age + "\nMedical card number: #" + MedicalCardNumber;
        }
    }

    abstract class User
    {
        public string Name { get; set; }
        public int Age { get; set; }

        protected User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract User CloneObject();
        public abstract string GetInfo();
    }

    class Program
    {
        static void Main(string[] args)
        {
            User client1 = new Client("Katya", 19, 390834406);
            Console.WriteLine(client1.GetHashCode());
            Console.WriteLine(client1.GetInfo());

            Console.WriteLine();

            User client2 = client1.CloneObject();
            Console.WriteLine(client2.GetHashCode());
            Console.WriteLine(client2.GetInfo());

            Console.WriteLine();

            Console.WriteLine(new string('-', 80));

            Console.WriteLine();

            Doctor doctor1 = new Doctor("Doctor", 35, "The");
            Console.WriteLine(doctor1.GetHashCode());
            Console.WriteLine(doctor1.GetInfo());

            Console.WriteLine();

            Doctor doctor2 = doctor1.Clone() as Doctor;
            Console.WriteLine(doctor2.GetHashCode());
            Console.WriteLine(doctor2.GetInfo());

            Console.ReadKey();
        }
    }
}
