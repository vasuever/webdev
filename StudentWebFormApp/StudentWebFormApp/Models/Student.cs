using System.ComponentModel.DataAnnotations;

namespace StudentWebFormApp.Models
{
    public class Student
    {
        [Key]
        public int? StudentID { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? SSN { get; set; }
        [Required]
        public string? FatherName { get; set; }
        [Required]    
        public string? MotherName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
    }
}
