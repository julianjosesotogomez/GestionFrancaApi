using GestionFrancaApi.Domain.Entities.GestionFrancaEntities;
using GestionFrancaApi.DTO.TechnicianDTO;
using GestionFrancaApi.DTOs;

namespace GestionFrancaApi.Domain.Interface
{
    public interface ITechnicianDomainService
    {
        public List<TechnicianDto> GetListTechnicians();
        public TechnicianDto GetTechnician(Guid IdTechnician);
        public ResponseEndPointDTO<bool> CreateTechnician(RequestTechnicianDto requestCreateTechnicianDto);
        public ResponseEndPointDTO<bool> UpdateTechnician(Guid IdTechnician,RequestUpdateTechnicianDto requestUpdateTechnicianDto);
        public ResponseEndPointDTO<bool> DeleteTechnician(Guid IdTechnician);
    }
}
