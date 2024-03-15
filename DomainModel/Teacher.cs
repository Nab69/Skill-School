using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Teacher")]
    public class Teacher : Person
    {
        [Required]
        [StringLength(30)]
        public string Discipline { get; set; } = null!;

        public int Salary { get; set; }

        // propriété de navigation + fk
        public Classroom? Classroom { get; set; }

        public int? ClassroomID { get; set; }
    }
}
