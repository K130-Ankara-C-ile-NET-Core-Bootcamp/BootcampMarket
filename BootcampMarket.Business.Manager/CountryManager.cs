using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BootcampMarket.Business.Manager.Infrastructure;
using BootcampMarket.Business.Manager.Model.Country;
using BootcampMarket.Business.Operation.Infrastructure;
using BootcampMarket.Core.Exception.BusinessException;
using BootcampMarket.Core.Exception.DatabaseException;
using BootcampMarket.Data.MSSQL.Entity;
using FluentValidation;

namespace BootcampMarket.Business.Manager
{
    public class CountryManager : ICountryManager
    {
        private readonly IMapper _mapper;

        private readonly ICountryOperations _countryOperations;

        private readonly IValidator<Country> _countryValidator;

        public CountryManager(
            IMapper mapper,
            ICountryOperations countryOperations,
            IValidator<Country> countryValidator)
        {
            _mapper = mapper;
            _countryOperations = countryOperations;
            _countryValidator = countryValidator;
        }

        public async Task<CountryDTO> CreateCountryAsync(CreateCountryDTO country)
        {
            try
            {
                var entity = _mapper.Map<Country>(country);

                var result = await _countryValidator.ValidateAsync(entity);

                if (!result.IsValid)
                {
                    throw new BusinessException(string.Join(",", result.Errors));
                }

                entity = await _countryOperations.CreateCountryAsync(entity);

                var entityDTO = _mapper.Map<CountryDTO>(entity);

                return entityDTO;
            }
            catch (Exception ex) when (ex is not BusinessException && ex is not DatabaseException)
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
            catch (Exception ex) when (ex is not BusinessException && ex is not DatabaseException)
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
            catch (Exception ex) when (ex is not BusinessException && ex is not DatabaseException)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }

        public async Task UpdateCountryAsync(UpdateCountryDTO country)
        {
            try
            {
                var entity = await _countryOperations.GetCountryByIdAsync(country.Id);

                if (entity is null)
                {
                    throw new BusinessException("Not found");
                }

                entity = _mapper.Map(country, entity);

                await _countryOperations.UpdateCountryAsync(entity);
            }
            catch (Exception ex) when (ex is not BusinessException && ex is not DatabaseException)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }

        public async Task DeleteCountryByIdAsync(int id)
        {
            try
            {
                var entity = await _countryOperations.GetCountryByIdAsync(id);

                if (entity is null)
                {
                    throw new BusinessException("Not found");
                }

                await _countryOperations.DeleteCountryAsync(entity);
            }
            catch (Exception ex) when (ex is not BusinessException && ex is not DatabaseException)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }
    }
}
