using System.Collections.Generic;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;
using BootcampMarket.Data.MSSQL.UnitOfWork.Dapper;
using BootcampMarket.Data.MSSQL.UnitOfWork.EntityFramework;
using BootcampMarket.Service.API.Models.Country;
using Microsoft.AspNetCore.Mvc;

namespace BootcampMarket.Service.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly EntityFrameworkUnitOfWork _uow;

        public CountriesController(EntityFrameworkUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> List()
        {
            var result = new List<CountryVM>();

            foreach (var country in await _uow
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
            var country = await _uow
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
            await _uow
                   .CountryRepository
                   .InsertAsync(new Country
                   {
                       Name = "Türkiye",
                       CreatedById = 1
                   });

            await _uow
                   .CountryRepository
                   .InsertAsync(new Country
                   {
                       Name = "Amerika",
                       CreatedById = 1
                   });

            _uow.Commit();

            return null;
            //return CreatedAtAction(nameof(Get), new { id = insertedId }, country);
        }
    }
}
