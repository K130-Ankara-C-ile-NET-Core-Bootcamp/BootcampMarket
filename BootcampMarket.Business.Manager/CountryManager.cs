using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BootcampMarket.Business.Manager.Infrastructure;
using BootcampMarket.Business.Manager.Model.Country;
using BootcampMarket.Business.Operation.Infrastructure;
using BootcampMarket.Core.Exception.BusinessException;
using BootcampMarket.Data.MSSQL.Entity;

namespace BootcampMarket.Business.Manager
{
    public class CountryManager : ICountryManager
    {
        private readonly IMapper _mapper;

        private readonly ICountryOperations _countryOperations;

        public CountryManager(
            IMapper mapper,
            ICountryOperations countryOperations)
        {
            _mapper = mapper;
            _countryOperations = countryOperations;
        }

        public async Task<CountryDTO> CreateCountryAsync(CreateCountryDTO country)
        {
            try
            {
                var entity = _mapper.Map<Country>(country);

                entity = await _countryOperations.CreateCountryAsync(entity);

                var entityDTO = _mapper.Map<CountryDTO>(entity);

                return entityDTO;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }

        public async Task<CountryDTO> GetCountryByIdAsync(int id)
        {
            try
            {
                var entity = await _countryOperations.GetCountryByIdAsync(id);

                var entityDTO = _mapper.Map<CountryDTO>(entity);

                return entityDTO;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<CountryDTO>> GetAllCountries()
        {
            try
            {
                var countryEntities = await _countryOperations.GetAllCountries();

                var countryDTOs = _mapper.Map<IEnumerable<CountryDTO>>(countryEntities);

                return countryDTOs;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }
    }
}
