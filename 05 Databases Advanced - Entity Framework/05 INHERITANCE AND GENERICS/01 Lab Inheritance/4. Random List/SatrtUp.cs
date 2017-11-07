namespace _4.Random_List
{
    class SatrtUp
    {
        static void Main(string[] args)
        {
            RandomList random = new RandomList();
            for(int i = 0; i < 10; i++)
            {
                random.Add(i.ToString());
            }
            System.Console.WriteLine("Removed element at:"+random.RandomString());
            foreach(var number in random)
            {
                System.Console.WriteLine("Left elements at:"+number);
            }
        }
    }
}
