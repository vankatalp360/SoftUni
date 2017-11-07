public class Child : Person
{
    private int age;

    public Child(string name, int age)
            : base(name, age)
    {
        this.ChildAge = age;
    }

    public int ChildAge
    {
        get
        {
            return age;
        }
        set
        {
            if (value < 0 || value > 15)
            {
                throw new System.ArgumentException("Child's age must be less than 15!");
            }
            this.age = value;
        }
    }
}