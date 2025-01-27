using System;

namespace MVOP_30_10_2023
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Human
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == "")
                {
                    throw new EmptyParameter("Name cannot be blank");
                }
                this.name = value;
            }
        }

        private string surname;
        public string Surname
        {
            get { return name; }
            set
            {
                if (value == "")
                {
                    throw new EmptyParameter("Name cannot be blank");
                }
                this.name = value;
            }
        }


        public Human(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }



    public class EmptyParameter : Exception
    {
        public EmptyParameter(string message) : base(message)
        {
        }
    }

}
