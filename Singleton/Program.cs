using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Client
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }

        public Client(string firstName, string secondName, int age)
        {
            FirstName = firstName;
            SecondName = secondName;
            Age = age;
        }
    }

    class Doctor
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Position { get; set; }

        public Doctor(string firstName, string secondName, string position)
        {
            FirstName = firstName;
            SecondName = secondName;
            Position = position;
        }
    }

    class DataBase
    {
        private static DataBase dataBase;

        private List<Client> clients = new List<Client>();
        private List<Doctor> doctors = new List<Doctor>();
        public List<Client> Clients { get => clients; set => clients = value; }
        public List<Doctor> Doctors { get => doctors; set => doctors = value; }

        private DataBase()
        { }

        public static DataBase DataBases
        {
            get
            {
                if (dataBase == null)
                {
                    dataBase = new DataBase();
                }
                return dataBase;
            }
        }

        public static DataBase GetDataBase()
        {
            if (dataBase == null)
            {
                dataBase = new DataBase();
            }
            return dataBase;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase1 = DataBase.DataBases;
            Console.WriteLine(dataBase1.GetHashCode());
            dataBase1.Clients.Add(new Client("Клієнт", "Перший", 18));

            DataBase dataBase2 = DataBase.GetDataBase();
            Console.WriteLine(dataBase2.GetHashCode());
            dataBase2.Clients.Add(new Client("Клієнт", "Другий", 58));
            dataBase2.Doctors.Add(new Doctor("Доктор", "Ілащук", "терапевт"));
            Console.WriteLine(dataBase2.GetHashCode());


            Console.WriteLine(new string('-', 18));

            DataBase dataBase3 = DataBase.DataBases;

            foreach (Client client in dataBase3.Clients)
            {
                Console.WriteLine(client.FirstName + " " + client.SecondName + ", " + client.Age);
            }
            foreach (Doctor doctor in dataBase3.Doctors)
            {
                Console.WriteLine(doctor.FirstName + " " + doctor.SecondName + ", " + doctor.Position);
            }

            Console.ReadKey();
        }
    }
}
