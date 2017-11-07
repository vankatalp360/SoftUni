namespace _4.First_and_Reserve_Team
{
    using System;
    using System.Collections.Generic;

    class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                this.name = value;
            }
        }

        public void AddPerson(IList<T> person)
        {

        }
    }
}
