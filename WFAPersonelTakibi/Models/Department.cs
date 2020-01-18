using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WFAPersonelTakibi.Models
{
    public class Department
    {
        public Department()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }


        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
         
        public virtual List<Employee> Employees { get; set; }
    }
}


