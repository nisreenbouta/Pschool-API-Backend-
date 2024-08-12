using System.ComponentModel.DataAnnotations.Schema;

namespace PschoolAPI.Models
{
    [Table("parents", Schema = "public")]
    public class Parent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WorkPhone { get; set; }   
        public string HomePhone { get; set; } 
        public string HomeAddress { get; set; }
        public bool IsActive { get; set; }= true;

    }

}


