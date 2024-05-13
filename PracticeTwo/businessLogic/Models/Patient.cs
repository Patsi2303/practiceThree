using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTwo.BusinessLogic.Models
{
    public class Patient
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int CI { get; set; }

        public string Bloodtype { get; set; }
        public Patient(string name, string lastname, int ci)
        {
            Name = name;
            Lastname = lastname;
            CI = ci;
            Bloodtype = GenerateRandomBloodtype();
        }

        private string GenerateRandomBloodtype()
        {
            Random rnd = new Random();
            int numeroAleatorio = rnd.Next(1, 9);
            string randomBloodtype = "";
            switch (numeroAleatorio)
            {
                case 1:
                    randomBloodtype = "O-";
                    break;
                case 2:
                    randomBloodtype = "O+";
                    break;
                case 3:
                    randomBloodtype = "A-";
                    break;
                case 4:
                    randomBloodtype = "A+";
                    break;
                case 5:
                    randomBloodtype = "B-";
                    break;
                case 6:
                    randomBloodtype = "B+";
                    break;
                case 7:
                    randomBloodtype = "AB-";
                    break;
                case 8:
                    randomBloodtype = "AB+";
                    break;
            }

            return randomBloodtype;
        }
    }
}