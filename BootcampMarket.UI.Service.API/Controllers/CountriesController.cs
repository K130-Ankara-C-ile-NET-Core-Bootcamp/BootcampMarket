using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BootcampMarket.Business.Manager.Infrastructure;
using BootcampMarket.Business.Manager.Model.Country;
using BootcampMarket.UI.Model.ViewModel.Country;
using Microsoft.AspNetCore.Mvc;

namespace BootcampMarket.UI.Service.API
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
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

            var countryVM = _mapper
                .Map<CountryVM>(countryDTO);

            return countryVM;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCountryVM createCountryVM)
        {
            var createCountryDTO = _mapper
                .Map<CreateCountryDTO>(createCountryVM);

            // Dummy user id
            createCountryDTO.CreatedById = 1;

            var countryDTO = await _countryManager
                .CreateCountryAsync(createCountryDTO);

            var countryVM = _mapper
                .Map<CountryVM>(countryDTO);

            return CreatedAtAction(nameof(Get), new { id = countryVM.Id }, countryVM);
        }
    }
}
