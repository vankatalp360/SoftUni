public class Frog : Animal
{
    private const string sound = "Ribbit";

    public Frog(string name, int age, string gender)
        : base(name, age, gender, sound)
    {

    }
}