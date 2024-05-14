using System.ComponentModel.DataAnnotations;

namespace Simple.Models
{
    public class Student
    {       
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public ushort Age { get; set; }
    }
}
