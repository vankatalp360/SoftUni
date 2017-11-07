namespace Problem_2.Date_Modifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string first = System.Console.ReadLine();
            string second = System.Console.ReadLine();
            DateModifier dateModifier = new DateModifier(first, second);
            System.Console.WriteLine(dateModifier);
        }
    }
}
