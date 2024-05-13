using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogic.Models
{
    public class Patient
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int CI { get; set; }

        public Patient(string name, string lastname, int ci)
        {
            Name = name;
            Lastname = lastname;
            CI = ci;
        }

    }
}
