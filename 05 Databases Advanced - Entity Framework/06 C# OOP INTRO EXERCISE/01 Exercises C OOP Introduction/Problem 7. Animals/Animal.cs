using System;

public class Animal
{
    private string name;
    private int age;
    private string gender;
    private string sound;

    public Animal(string name, int age, string gender, string sound)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
        this.Sound = sound;
    }

    public string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentException("Invalid input!");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get => this.age;
        set
        {
            if (value < 0)
            {
                throw new System.ArgumentException("Invalid input!");
            }
            this.age = value;
        }
    }

    public string Gender
    {
        get => this.gender;
        set
        {
            if (value != "Male" && value != "Female")
            {
                throw new System.ArgumentException("Invalid input!");
            }
            this.gender = value;
        }
    }

    public string Sound
    {
        get => this.sound;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentException("Invalid input!");
            }
            this.sound = value;
        }
    }

    public string ProduceSound()
    {
        if (string.IsNullOrWhiteSpace(this.sound))
        {
            throw new System.ArgumentException("Invalid input!");
        }
        return this.sound;
    }

    public override string ToString()
    {
        return $"{this.GetType()}" + Environment.NewLine + $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine + this.ProduceSound();
    }
}
