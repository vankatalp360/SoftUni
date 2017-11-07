﻿namespace _01_DB_FirstDemoSqlClient.Data.Models
{
    using System.Collections.Generic;

    public partial class Town
    {
        public Town()
        {
        }

        public int TownId { get; set; }
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
