using Microsoft.AspNetCore.Mvc;
using PracticeTwo.BusinessLogic.Managers;
using PracticeTwo.BusinessLogic.Models;
using Serilog;
using System.Net.Http;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private PatientManager _patientManager;
        private readonly IConfiguration _configuration;
        private HttpClient _httpClient;

        public PatientController(PatientManager patientManager, IConfiguration configuration, HttpClient httpClient)
        {
            _patientManager = patientManager;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        // GET: api/<PatientController>.
        [HttpGet]
        public List<Patient> Get()
        {
            StreamWriter writer = new StreamWriter(_configuration["PatientsFilePath"]);
            
            foreach (Patient patient in _patientManager.GetPatients())
            {
                writer.WriteLine($"{patient.Name},{patient.Lastname},{patient.CI},{patient.Code}");
            }
            writer.Close();
        
            return _patientManager.GetPatients();
        }

        // GET api/<PatientController>/5
        [HttpGet("{CI}")]
        public Patient GetByCI(int CI)
        {
            return _patientManager.GetPatientByCI(CI);
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task<ActionResult<Patient>> Post(string name, string lastname, int CI)
        {   
            var patientData = new PatientData(name, lastname, CI);

            var jsonPatientData = JsonConvert.SerializeObject(patientData);
            var content = new StringContent(jsonPatientData, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5217/api/Patient", content);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Failed to generate patient code.");
            }

            var patientCode = await response.Content.ReadAsStringAsync();

            _patientManager.AddPatient(name, lastname, CI, patientCode);

            return Ok(new Patient(name, lastname, CI, patientCode));
        }

        // PUT api/<PatientController>/5
        [HttpPut("{CI}")]
        public void Put(int CI, string name, string lastname)
        {
            _patientManager.UpdatePatientByCI(CI, name, lastname);
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{CI}")]
        public void Delete(int CI)
        {
            _patientManager.DeletePatientByCI(CI);
        }
    }
}
