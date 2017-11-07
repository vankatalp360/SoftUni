namespace _4.Random_List
{

    using System;
    using System.Collections.Generic;

    public class RandomList:List<string>
    {
        private Random rmd;

        public RandomList()
            :base()
        {
            this.rmd = new Random();
        }

        public string RandomString()
        {
            int index = rmd.Next(0, this.Count);
            string currentString = this[index];
            this.RemoveAt(index);
            return currentString;
        }
    }
}
