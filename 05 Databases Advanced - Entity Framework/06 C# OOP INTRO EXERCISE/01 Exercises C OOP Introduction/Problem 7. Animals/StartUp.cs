using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        while (true)
        {
            string type = Console.ReadLine().Trim();
            if (type == "Beast!") break;
            string[] details = Console.ReadLine().Split();
            string name = details[0];
            try
            {
                int age;
                bool result = int.TryParse(details[1].Trim(), out age);
                if(!result)
                {
                    throw new ArgumentException("Invalid input!");
                }
                switch (type)
                {
                    case "Dog":
                        string gender = details[2].Trim();
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                        break;
                    case "Cat":
                        gender = details[2];
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                        break;
                    case "Frog":
                        gender = details[2];
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                        break;
                    case "Kitten":
                        Kitten kittens = new Kitten(name, age);
                        animals.Add(kittens);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}