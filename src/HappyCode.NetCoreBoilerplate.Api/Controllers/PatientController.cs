using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyCode.NetCoreBoilerplate.Api.Controllers
{
    [Route("api/patient")]
    public class PatientController : ApiControllerBase
    {
        private readonly IPatientRepository _PatientRepository;

        public PatientController(IPatientRepository PatientRepository)
        {
            _PatientRepository = PatientRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PatientDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            CancellationToken cancellationToken = default)
        {
            var result = await _PatientRepository.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(
            int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _PatientRepository.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}/details")]
        [ProducesResponseType(typeof(PatientDetailsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWithDetails(
            int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _PatientRepository.GetByIdWithDetailsAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(
            [FromRoute] int id,
            [FromBody] PatientPutDto PatientPutDto,
            CancellationToken cancellationToken = default)
        {
            var result = await _PatientRepository.UpdateAsync(id, PatientPutDto, cancellationToken);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PatientDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(
            [FromBody] PatientPostDto PatientPostDto,
            CancellationToken cancellationToken = default)
        {
            var result = await _PatientRepository.InsertAsync(PatientPostDto, cancellationToken);
            Response.Headers.Add("x-date-created", DateTime.UtcNow.ToString("s"));
            return CreatedAtAction("Get", new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _PatientRepository.DeleteByIdAsync(id, cancellationToken);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
