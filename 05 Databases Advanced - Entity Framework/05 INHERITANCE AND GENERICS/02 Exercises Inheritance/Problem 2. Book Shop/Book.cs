using System;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Title = title;
        this.Price = price;
        this.Author = author;
    }

    public string Author
    {
        get
        {
            return author;
        }
        set
        {
            if (string.IsNullOrEmpty(value)|| !AuthorSecondNameVerification(value))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    private bool AuthorSecondNameVerification(string author)
    {
        bool validationName = true;
        string[] names = author.Split();
        if (names.Length!=2)
        {
            validationName = false;
        }
        else
        {
            string secondName = names[1];
            if (secondName.Length>0)
            {
                int number;
                bool result = Int32.TryParse(secondName[0].ToString(), out number);
                if(result)
                {
                    validationName = false;
                }
            }
            
        }
        return validationName;
    }

    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            {
                throw new System.ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value <= 0)
            {
                throw new System.ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        return $"Type: {this.GetType()}" + Environment.NewLine +
            $"Title: {this.Title}" + Environment.NewLine +
            $"Author: {this.author}" + Environment.NewLine +
            $"Price: {this.Price:F2}" + Environment.NewLine;
    }
}
