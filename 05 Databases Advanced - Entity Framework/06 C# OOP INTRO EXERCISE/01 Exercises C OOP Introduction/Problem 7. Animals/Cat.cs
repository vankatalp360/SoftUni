public class Cat : Animal
{
    private const string sound = "Meow meow";

    public Cat(string name, int age, string gender)
        : base(name, age, gender, sound)
    {

    }

    public Cat(string name, int age, string gender, string sound)
        : base(name, age, gender, sound)
    {

    }
}