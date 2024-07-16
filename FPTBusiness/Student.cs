using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTBusiness
{
    public class Student
    {
        public int StudentId { get; set; }

        public string? StudentCode { get; set; }

        public string StudentName { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
