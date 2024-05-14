using businessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogic.Managers
{
    public class PatientManager
    {
        public PatientManager()
        {
        }

        public string GenerateCode(string name, string lastname, int ci)
        {
            string code = $"{name[0]}{lastname[0]}-{ci}";
            return code;
        }
    }
}
