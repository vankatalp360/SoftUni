public class Employee
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string jobTitle { get; set; }

    public override string ToString()
    {
        return $"    -{firstName} {lastName}";
    }

}