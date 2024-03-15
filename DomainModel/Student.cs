﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Student")]
    public class Student : Person
    {
        public double Average { get; set; }

        public bool IsClassDelegate { get; set; }

        // propriété de navigation + fk
        public Classroom? Classroom { get; set; }
        public int? ClassroomID { get; set; }
    }
}
