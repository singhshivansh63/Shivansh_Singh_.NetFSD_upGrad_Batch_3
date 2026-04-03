using WebApplication10.Models;

namespace WebApplication10.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        // Foreign Key
        public int CourseId { get; set; }

        // Navigation Property
        public Course? Course { get; set; }
    }
}
