using AutoMapper;
using BootcampMarket.Business.Manager.Model.Country;
using BootcampMarket.Data.MSSQL.Entity;

namespace BootcampMarket.Mapper.Profiles
{
    public class EntityToDTOMapperProfile : Profile
    {
        public EntityToDTOMapperProfile()
        {
            CreateMap<CreateCountryDTO, Country>();

            CreateMap<Country, CountryDTO>();
        }
    }
}
