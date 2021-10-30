using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BootcampMarket.Business.Manager.Infrastructure;
using BootcampMarket.Business.Manager.Model.Country;
using BootcampMarket.UI.Model.ViewModel.Country;
using BootcampMarket.UI.Service.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BootcampMarket.UI.Service.API
{
    [Route("[controller]")]
    public class CountriesController : BaseController
    {
        private readonly IMapper _mapper;

        private readonly ICountryManager _countryManager;

        public CountriesController(
            IMapper mapper,
            ICountryManager countryManager)
        {
            _mapper = mapper;
            _countryManager = countryManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryVM>>> List()
        {
            var countryDTOs = await _countryManager
                .GetAllCountries();

            var countryVMs = _mapper
                .Map<IEnumerable<CountryVM>>(countryDTOs);

            return Ok(countryVMs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryVM>> Get(int id)
        {
            var countryDTO = await _countryManager
                .GetCountryByIdAsync(id);

            if (countryDTO is null)
            {
                return NotFound();
            }

            var countryVM = _mapper
                .Map<CountryVM>(countryDTO);

            return countryVM;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCountryVM createCountryVM)
        {
            var createCountryDTO = _mapper
                .Map<CreateCountryDTO>(createCountryVM);

            var countryDTO = await _countryManager
                .CreateCountryAsync(createCountryDTO);

            var countryVM = _mapper
                .Map<CountryVM>(countryDTO);

            return CreatedAtAction(nameof(Get), new { id = countryVM.Id }, countryVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCountryVM updateCountryVM)
        {
            var country = await _countryManager
                .GetCountryByIdAsync(id);

            if (country is null)
            {
                return await Post(_mapper.
                    Map<CreateCountryVM>(updateCountryVM));
            }

            var updateCountryDTO = _mapper
                .Map<UpdateCountryDTO>(updateCountryVM);

            updateCountryDTO.Id = id;

            await _countryManager
                .UpdateCountryAsync(updateCountryDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _countryManager
                .GetCountryByIdAsync(id);

            if (country is null)
            {
                return NotFound();
            }

            await _countryManager
                .DeleteCountryByIdAsync(id);

            return NoContent();
        }
    }
}
