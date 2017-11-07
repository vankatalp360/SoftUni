public class Kitten : Cat
{
    private const string sound = "Meow";
    private const string gender = "Female";

    public Kitten(string name, int age)
        : base(name, age, gender, sound)
    {

    }
}