using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();
        for (int i = 1; i <= n; i++)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            string name = input[0];
            int age = int.Parse(input[1]);
            people.Add(new Person(name, age));
        }
        foreach (var person in people.Where(x => x.Age > 30).OrderBy(x => x.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}