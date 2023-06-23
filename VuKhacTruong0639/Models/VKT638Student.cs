using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuKhacTruong0639.Models
{
    [Table("VKT638Student")]
    public class VKT638Student
    { 
        [Key]
        public int StudentID { get; set;}

        public string StudentName { get; set;}

        public float StudentAge { get; set;}

    }
}