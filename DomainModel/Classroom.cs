﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("Classroom")]
    public class Classroom
    {
        public int ClassroomID { get; set; }

        [Required]
        [StringLength(30)]
        [Column("classname")]
        public string Name { get; set; } = null!;

        public int Floor { get; set; }

        public string Corridor { get; set; } = null!;

        // propriétés de navigation
        public ICollection<Student>? Students { get; set; }

        public Teacher? Teacher { get; set; }
    }
}
