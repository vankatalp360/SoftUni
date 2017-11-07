namespace _5._Change_Town_Names_Casing
{
    using System;

    class Town
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"{this.Name.ToUpper()}";
        }
    }
}
