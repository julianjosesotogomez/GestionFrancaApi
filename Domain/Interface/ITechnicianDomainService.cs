using GestionFrancaApi.Domain.Entities.GestionFrancaEntities;
using GestionFrancaApi.DTO.TechnicianDTO;
using GestionFrancaApi.DTOs;

namespace GestionFrancaApi.Domain.Interface
{
    public interface ITechnicianDomainService
    {
        public List<Technician>GetListTechnicians();
        public Technician GetTechnician(Guid IdTechnician);
        public ResponseEndPointDTO<bool> CreateTechnician(RequestTechnicianDto requestCreateTechnicianDto);
    }
}
