using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BootcampMarket.Business.Operation.Infrastructure;
using BootcampMarket.Core.Exception.DatabaseException;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.UnitOfWork.Infrastructure;

namespace BootcampMarket.Business.Operation
{
    public class CountryOperations : ICountryOperations
    {
        private readonly IUnitOfWork _uow;

        public CountryOperations(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                var entity = await _uow.CountryRepository.InsertAsync(country);

                _uow.Commit();

                return entity;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message, ex);
            }
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            try
            {
                return await _uow.CountryRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            try
            {
                return await _uow.CountryRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message, ex);
            }
        }

        public async Task<int> UpdateCountryAsync(Country country)
        {
            try
            {
                var result = await _uow.CountryRepository.UpdateAsync(country);

                _uow.Commit();

                return result;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message, ex);
            }
        }

        public async Task<int> DeleteCountryAsync(Country country)
        {
            try
            {
                var result = await _uow.CountryRepository.DeleteAsync(country);

                _uow.Commit();

                return result;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message, ex);
            }
        }
    }
}
