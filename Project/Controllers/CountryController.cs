using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Contracts.CountryContract;
using Project.DTOs.Country;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _repository;

        public CountryController(IMapper mapper, ICountryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryReadDto>>> GetCountries()
        {
            return Ok(_mapper.Map<List<CountryReadDto>>(await _repository.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDetailDto>> GetCountry(int id)
        {
            var country = _mapper.Map<CountryDetailDto>(await _repository.GetDetails(id));

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CountryCreateDto countryCreateDto)
        {
            var country = _mapper.Map<Country>(countryCreateDto);
            await _repository.AddAsync(country);
            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, CountryUpdateDto countryUpdateDto)
        {
            if (id != countryUpdateDto.Id)
            {
                return BadRequest();
            }

            var country = await _repository.GetByIdAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            _mapper.Map(country, countryUpdateDto);

            try
            {
                await _repository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _repository.GetByIdAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(country);

            return NoContent();
        }

        private async Task<bool> CountryExistsAsync(int id) => await _repository.Exists(id);
    }
}
