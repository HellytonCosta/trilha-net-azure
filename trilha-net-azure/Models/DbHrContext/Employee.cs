using System.ComponentModel.DataAnnotations;

namespace trilha_net_azure.Models.DbHrContext
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Extension { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public DateTime AdmissionDate { get; set; }

    }
}
