namespace P01_StudentSystem.Data.Models
{
    using P01_StudentSystem.Data.Models;
    using System;

    public class Homework
    {
        public int HomeworkId{ get; set; }
        public string Content{ get; set; }
        public ContentType contentType{ get; set; }
        public DateTime SubmissionTime{ get; set; }

        public int StudentId{ get; set; }
        public Student Student{ get; set; }

        public int CourseId{ get; set; }
        public Course Course{ get; set; }
    }
}
