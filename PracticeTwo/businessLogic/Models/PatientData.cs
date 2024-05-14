using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTwo.BusinessLogic.Models
{
    public class PatientData
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int CI { get; set; }
        public PatientData(string name, string lastname, int ci)
        {
            Name = name;
            Lastname = lastname;
            CI = ci;
        }
    }
}
