using GestionFrancaApi.DTO.GenericDTO;
using GestionFrancaApi.DTOs;

namespace GestionFrancaApi.Application.Interface
{
    public interface IGenericApplication
    {
        public ResponseEndPointDTO<List<BranchOfficeDto>> GetListBranchOffice();
        public ResponseEndPointDTO<List<ItemsDto>> GetListItem();
    }
}
