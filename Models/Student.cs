using System.ComponentModel.DataAnnotations.Schema;

namespace PschoolAPI.Models
{
    [Table("students", Schema = "public")]
    public class Student
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
         public int ParentId { get; set; }
        // public Parent Parent { get; set; } 
        public bool IsActive { get; set; }= true;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string grade { get; set; }

    }
}

