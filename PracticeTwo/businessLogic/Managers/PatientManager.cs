using PracticeTwo.BusinessLogic.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTwo.BusinessLogic.Managers
{
    public class PatientManager
    {
        private List<Patient> _patients;

        public PatientManager()
        {
            _patients = new List<Patient>();

            _patients.Add(new Patient("Alejandro", "Uriarte", 123456));
        }

        public void AddPatient(string name, string lastname, int ci)
        {
            try
            {
                _patients.Add(new Patient(name, lastname, ci));
            }
            catch(Exception ex)  
            {
                Log.Error($"AddPatient Method Error: {ex.Message}");
                Log.Error($"AddPatient StackTrace: {ex.StackTrace}");

                throw ex;
            }
        }

        public void UpdatePatientByCI(int ci, string newName, string newLastname)
        {
            Patient patient = _patients.FirstOrDefault(p => p.CI == ci);
            if (patient != null)
            {
                patient.Name = newName;
                patient.Lastname = newLastname;
            }
            else
            {
                Log.Error("UpdatePatientByCI Method Error: Patient not found");
                throw new KeyNotFoundException("Patient not found");
            }
        }

        public void DeletePatientByCI(int ci)
        {
            Patient patient = _patients.FirstOrDefault(p => p.CI == ci);
            if (patient != null)
            {
                _patients.Remove(patient);
            }
            else
            {
                Log.Error("DeletePatientByCI Method Error: Patient not Found");
                throw new KeyNotFoundException("Patient not found");
            }
        }

        public List<Patient> GetPatients()
        {
            return _patients;
        }

        public Patient GetPatientByCI(int ci)
        {
            return _patients.FirstOrDefault(p => p.CI == ci);
        }
    }
}
