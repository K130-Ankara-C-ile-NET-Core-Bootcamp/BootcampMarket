using System.Collections.Generic;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;
using BootcampMarket.Data.MSSQL.UnitOfWork.Dapper;
using BootcampMarket.Service.API.Models.Country;
using Microsoft.AspNetCore.Mvc;

namespace BootcampMarket.Service.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly DapperUnitOfWork _dapperUnitOfWork;

        public CountriesController(DapperUnitOfWork dapperUnitOfWork)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> List()
        {
            var result = new List<CountryVM>();

            foreach (var country in await _dapperUnitOfWork
                .CountryRepository.GetAllAsync())
            {
                result.Add(new CountryVM
                {
                    Id = country.Id,
                    Name = country.Name
                });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryVM>> Get(int id)
        {
            var country = await _dapperUnitOfWork
                .CountryRepository
                .GetByIdAsync(id);

            if (country == null)
            {
                return BadRequest();
            }

            return new CountryVM
            {
                Id = country.Id,
                Name = country.Name,
            };
        }

        [HttpPost]
        public async Task<IActionResult> Post(CountryVM countryVM)
        {
            var country = new Country
            {
                Name = countryVM.Name,
                CreatedBy = 1
            };

            var insertedId = await _dapperUnitOfWork
                .CountryRepository
                .InsertAsync(country);

            country = new Country
            {
                Name = countryVM.Name + " 2",
                CreatedBy = 1
            };

            insertedId = await _dapperUnitOfWork
                .CountryRepository
                .InsertAsync(country);

            _dapperUnitOfWork.Commit();

            return CreatedAtAction(nameof(Get), new { id = insertedId }, country);
        }
    }
}
