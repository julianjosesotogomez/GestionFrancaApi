using GestionFrancaApi.DataAccess.Context;
using GestionFrancaApi.Domain.Entities.GestionFrancaEntities;
using GestionFrancaApi.Domain.Interface;
using GestionFrancaApi.DTO.TechnicianDTO;
using GestionFrancaApi.DTOs;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;

namespace GestionFrancaApi.Domain
{
    public class TechnicianDomainService:ITechnicianDomainService
    {
        #region Fields
        protected readonly GestionFrancaContext _context;
        #endregion
        #region Builder
        public TechnicianDomainService(GestionFrancaContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods
        public List<Technician> GetListTechnicians()
        {
            return _context.Technician.ToList();
        }
        public Technician GetTechnician(Guid IdTechnician) 
        {
            return _context.Technician.AsNoTracking().FirstOrDefault(x => x.IdTechnician == IdTechnician);
        }
        public ResponseEndPointDTO<bool> CreateTechnician(RequestTechnicianDto requestCreateTechnicianDto)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();

            var validateTechnician = _context.Technician.AsNoTracking().FirstOrDefault(x => x.Code == requestCreateTechnicianDto.Code);
            if (validateTechnician != null)
            {
                response.ResponseMessage($"Ya se encuentra registrado un Candidato con el codigo {validateTechnician.Code}", false);
            }
            else
            {
                Technician newTechnician = new Technician();
                newTechnician.IdTechnician= Guid.NewGuid();
                newTechnician.Code= requestCreateTechnicianDto.Code;
                newTechnician.Name= requestCreateTechnicianDto.Name;
                newTechnician.Salary=requestCreateTechnicianDto.Salary;

                _context.Technician.Add(newTechnician);

                if(!requestCreateTechnicianDto.ListItems.GroupBy(item => item.IdItem).All(group => group.Count() == 1))
                {
                    response.ResponseMessage($"Verifica que no se repitan los elementos para el Técnico", false);
                }
                else
                {
                    foreach (var item in requestCreateTechnicianDto.ListItems)
                    {
                        TechnicianItem newRelation = new TechnicianItem();
                        newRelation.IdTechnicianItem = Guid.NewGuid();
                        newRelation.IdTechnician = newTechnician.IdTechnician;
                        newRelation.IdBranchOffice = item.IdBranchOffice;
                        newRelation.IdItem = item.IdItem;
                        newRelation.ItemQuantity = item.ItemQuantity;

                        _context.TechnicianItem.Add(newRelation);
                    }
                }
                _context.SaveChanges();
            }
            return response;
        }
        #endregion
        #region Private Methods

        #endregion
    }
}
