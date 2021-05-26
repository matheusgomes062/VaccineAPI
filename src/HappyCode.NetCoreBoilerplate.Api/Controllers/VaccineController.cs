using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyCode.NetCoreBoilerplate.Api.Controllers
{
    [Route("api/vaccine")]
    public class VaccineController : ApiControllerBase
    {
        private readonly IVaccineRepository _VaccineRepository;

        public VaccineController(IVaccineRepository VaccineRepository)
        {
            _VaccineRepository = VaccineRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VaccineDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            CancellationToken cancellationToken = default)
        {
            var result = await _VaccineRepository.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VaccineDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(
            int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _VaccineRepository.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}/details")]
        [ProducesResponseType(typeof(VaccineDetailsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWithDetails(
            int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _VaccineRepository.GetByIdWithDetailsAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VaccineDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(
            [FromRoute] int id,
            [FromBody] VaccinePutDto VaccinePutDto,
            CancellationToken cancellationToken = default)
        {
            var result = await _VaccineRepository.UpdateAsync(id, VaccinePutDto, cancellationToken);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(VaccineDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(
            [FromBody] VaccinePostDto VaccinePostDto,
            CancellationToken cancellationToken = default)
        {
            var result = await _VaccineRepository.InsertAsync(VaccinePostDto, cancellationToken);
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
            var result = await _VaccineRepository.DeleteByIdAsync(id, cancellationToken);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
