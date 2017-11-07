public class Person
{
    private string name;
    private int age;

    public Person(string name , int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value)||value.Length<3)
            {
                throw new System.ArgumentException("Name's length should not be less than 3 symbols!");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if(value<0)
            {
                throw new System.ArgumentException("Age must be positive!");
            }
            this.age = value;
        }
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}