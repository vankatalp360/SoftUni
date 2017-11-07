using System;

namespace Problem_1.Oldest_Family_Member
{
    public class Person
    {
        private string name;
        private int age;

        internal Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                //if (string.IsNullOrWhiteSpace(value))
                //{
                //    throw new Exception();
                //}

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                //if (value<=0)
                //{
                //    throw new Exception();
                //}
                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
