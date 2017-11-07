namespace Problem_1.Oldest_Family_Member
{
    using System;
    using System.Reflection;

    public class StartUp
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 1; i <= n; i++)
            {
                try
                {
                    string[] tokens = Console.ReadLine().Split();
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    Person person = new Person(name, age);
                    family.AddMember(person);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            try
            {
                Person theOldest = family.GetOldestMember();
                Console.WriteLine(theOldest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
