using AutoMapper;
using BootcampMarket.Business.Manager.Model.Country;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.UI.Model.ViewModel.Country;

namespace BootcampMarket.Mapper.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            EntityToDTOMaps();
            ViewModelToDTOMaps();
            ViewModelToViewModelMaps();
        }

        private void EntityToDTOMaps()
        {
            CreateMap<Country, CountryDTO>();

            CreateMap<CreateCountryDTO, Country>();

            CreateMap<UpdateCountryDTO, Country>();
        }

        private void ViewModelToDTOMaps()
        {
            CreateMap<CountryDTO, CountryVM>();

            CreateMap<CreateCountryVM, CreateCountryDTO>();

            CreateMap<UpdateCountryVM, UpdateCountryDTO>();
        }

        private void ViewModelToViewModelMaps()
        {
            CreateMap<UpdateCountryVM, CreateCountryVM>();
        }
    }
}
