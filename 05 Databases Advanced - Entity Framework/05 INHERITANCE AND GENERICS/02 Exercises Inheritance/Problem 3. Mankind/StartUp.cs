
namespace Problem_3.Mankind
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] studentInfo = Console.ReadLine().Split();
                var studFirstName = studentInfo[0];
                var studLastName = studentInfo[1];
                var studFacultyNumber = studentInfo[2];

                string[] workerInfo = Console.ReadLine().Split();
                var workerFirstName = workerInfo[0];
                var workerLastName = workerInfo[1];
                var workerSalaryPerWeek = decimal.Parse(workerInfo[2]);
                var workerWorkHoursPerDay = double.Parse(workerInfo[3]);

                Student student = new Student(studFirstName, studLastName, studFacultyNumber);
                Worker worker = new Worker(workerFirstName, workerLastName, workerSalaryPerWeek, workerWorkHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
