using System;
using System.ComponentModel.DataAnnotations;
using WFAPersonelTakibi.Enums;

namespace WFAPersonelTakibi.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(24)] 
        public string Phone { get; set; }

        [MaxLength(250)] 
        public string Address { get; set; }

        [MaxLength(100)]
        public string Mail { get; set; }
        public DateTime BirthDate { get; set; }
        [MaxLength(150)]
        public string ImageUrl { get; set; }
        public Gender Gender { get; set; }

        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
