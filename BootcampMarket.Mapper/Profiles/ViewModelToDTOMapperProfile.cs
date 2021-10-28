using AutoMapper;
using BootcampMarket.Business.Manager.Model.Country;
using BootcampMarket.UI.Model.ViewModel.Country;

namespace BootcampMarket.Mapper.Profiles
{
    public class ViewModelToDTOMapperProfile : Profile
    {
        public ViewModelToDTOMapperProfile()
        {
            CreateMap<CreateCountryVM, CreateCountryDTO>();

            CreateMap<CountryDTO, CountryVM>();
        }
    }
}
