using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWithEFCore.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
