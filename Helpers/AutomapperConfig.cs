

using AutoMapper;
using GestionFrancaApi.Domain.Entities.GestionFrancaEntities;
using GestionFrancaApi.DTO.GenericDTO;

namespace GestionFrancaApi.Helpers
{
    public class AutomapperConfig : Profile
    {

        public AutomapperConfig()
        {
                
            CreateMap<BranchOfficeDto, BranchOffice>().ReverseMap();
            CreateMap<ItemsDto, Items>().ReverseMap();

        }

    }
}
