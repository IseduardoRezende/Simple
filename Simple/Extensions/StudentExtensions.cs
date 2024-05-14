using Simple.Models;
using Simple.ViewModels.Students;

namespace Simple.Extensions
{
    public static class StudentExtensions
    {
        public static Student ToBase(this CreateStudentViewModel student)
        {
            return new Student() { Name = student.Name, Age = student.Age };
        }

        public static Student ToBase(this UpdateStudentViewModel student)
        {
            return new Student() { Id = student.Id, Name = student.Name, Age = student.Age };
        }
    }
}
