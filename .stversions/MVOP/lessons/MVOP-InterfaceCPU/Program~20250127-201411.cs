using System;
using System.Net.Http;

namespace _13_11_2023
{
    enum CPUenum
    {
        AMD,
        Intel,

    };
    enum OSenum
    {
        Windows,
        IOS,
        Linux
    };
    class Program
    {
        static void Main(string[] args)
        {
            Computer[] computers = new Computer[] {new Computer(CPUenum.Intel, OSenum.Linux, "32GB"),
                                                 new Notebook(CPUenum.Intel, OSenum.Linux, "32GB", 50),
                                                 new Tablet(CPUenum.Intel, OSenum.Linux, "32GB", 73, true)};

            foreach (var item in computers)
            {
                Console.WriteLine($"{item.ToString()}");

            }

        }
    }

    class Computer
    {

        public string RAM;
        public CPUenum CPU;
        public OSenum OS;


        public Computer(CPUenum CPU, OSenum OS, string RAM)
        {
            this.CPU = CPU;
            this.OS = OS;
            this.RAM = RAM;
        }
        public override string ToString()
        {
            return $"Objekt je Počítač třídy s typem CPU {CPU}, OS {OS}, RAM {RAM}";
        }
    }

    abstract class MovableComputer : Computer
    {
        private int batteryCapacity;
        public int BatteryCapacity
        {
            get { return this.batteryCapacity; }
            set
            {
                if (0 < value && value < 100)
                {
                    this.batteryCapacity = value;
                }
            }
        }

        public MovableComputer(CPUenum CPU, OSenum OS, string RAM, int BatteryCapacity) : base(CPU, OS, RAM)
        {
            this.BatteryCapacity = BatteryCapacity;
        }
    }

    class Notebook : MovableComputer
    {
        public Notebook(CPUenum CPU, OSenum OS, string RAM, int BatteryCapacity) : base(CPU, OS, RAM, BatteryCapacity) { }
        public override string ToString()
        {
            return $"Objekt je Počítač třídy s typem CPU {CPU}, OS {OS}, RAM {RAM} a Kapacitou Baterie {BatteryCapacity}";
        }

    }
    class Tablet : MovableComputer
    {
        public bool Stylus;
        public Tablet(CPUenum CPU, OSenum OS, string RAM, int BatteryCapacity, bool Stylus) : base(CPU, OS, RAM, BatteryCapacity)
        {
            this.Stylus = Stylus;
        }
        public override string ToString()
        {
            string stylusStatus = Stylus ? "Má" : "Nemá";
            return $"Objekt je Počítač třídy Tablet s typem CPU {CPU}, OS {OS}, RAM {RAM}, Kapacitou Baterie {BatteryCapacity} a {stylusStatus} stylus";
        }

    }




}
