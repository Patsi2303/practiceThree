using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using businessLogic.Managers;
using businessLogic.Models;

namespace PracticeThree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PatientController : ControllerBase
    {
        private PatientManager _patientManager;

        public PatientController(PatientManager patientManager)
        {
            _patientManager = patientManager;
        }

        [HttpPost]
        public ActionResult<string> GeneratePatientCode([FromBody] Patient patientData)
        {
            // Verifica si los datos del paciente son válidos
            if (string.IsNullOrEmpty(patientData.Name) || string.IsNullOrEmpty(patientData.Lastname))
            {
                return BadRequest("Nombre, Apellido y CI son requeridos.");
            }

            // Genera el código del paciente utilizando la lógica de la biblioteca de clases
            var patientCode = _patientManager.GenerateCode(patientData.Name, patientData.Lastname, patientData.CI);
            return Ok(patientCode);
        }
    }
}
