using GestionFrancaApi.DTO.TechnicianDTO;
using GestionFrancaApi.DTOs;

namespace GestionFrancaApi.Application.Interface
{
    public interface ITechnicianApplication
    {
        public ResponseEndPointDTO<List<TechnicianDto>> GetListTechnician();
        public ResponseEndPointDTO<TechnicianDto> GetTechnician(Guid IdTechnician);
        public ResponseEndPointDTO<bool> CreateTechnician(RequestTechnicianDto requestCreateTechnicianDto);
        public ResponseEndPointDTO<bool> UpdateTechnician(Guid IdTechnician,RequestUpdateTechnicianDto requestUpdateTechnicianDto);
        public ResponseEndPointDTO<bool> DeleteTechnician(Guid IdTechnician);
    }
}
