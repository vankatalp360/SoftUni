namespace _5.Storage_Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> nums = new Box<int>();
            for(int i = 0; i <10;i ++)
            {
                nums.Add(i);
            }
        }
    }
}
