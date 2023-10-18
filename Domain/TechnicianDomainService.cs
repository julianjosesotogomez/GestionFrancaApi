using GestionFrancaApi.DataAccess.Context;
using GestionFrancaApi.Domain.Entities.GestionFrancaEntities;
using GestionFrancaApi.Domain.Interface;
using GestionFrancaApi.DTO.TechnicianDTO;
using GestionFrancaApi.DTOs;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        public List<TechnicianDto> GetListTechnicians()
        {
            var listTechnician = _context.Technician.AsNoTracking().ToList();

            List<TechnicianDto> list = new List<TechnicianDto>();
            
            foreach (var item in listTechnician)
            {
                var technicianData = new TechnicianDto();
                technicianData.TechnicianInfo = new List<TechnicianInfoList>();

                technicianData.IdTechnician = item.IdTechnician;
                technicianData.Code = item.Code;
                technicianData.Name = item.Name;
                technicianData.Salary = item.Salary;

                var listRelation = _context.TechnicianItem.AsNoTracking()
                                                          .Include(x=>x.IdBranchOfficeNavigation)
                                                          .Include(x=>x.IdItemNavigation)
                                                          .Where(x=>x.IdTechnician == item.IdTechnician).ToList();

                foreach (var itemA in listRelation )
                {
                    var dataRelation = new TechnicianInfoList();
                    dataRelation.IdTechnicianItem = itemA.IdTechnicianItem;
                    dataRelation.NameBranchOffice = itemA.IdBranchOfficeNavigation.Name;
                    dataRelation.NameItem = itemA.IdItemNavigation.NameItem;
                    dataRelation.ItemQuantity = itemA.ItemQuantity;

                    technicianData.TechnicianInfo.Add(dataRelation);
                }

                list.Add(technicianData);
            }
            return list;
        }
        public TechnicianDto GetTechnician(Guid IdTechnician) 
        {
            var data = _context.Technician.AsNoTracking().FirstOrDefault(x => x.IdTechnician == IdTechnician);

            if (data != null)
            {
                var technicianData = new TechnicianDto();
                technicianData.TechnicianInfo = new List<TechnicianInfoList>();

                technicianData.IdTechnician = data.IdTechnician;
                technicianData.Code = data.Code;
                technicianData.Name = data.Name;
                technicianData.Salary = data.Salary;

                var listRelation = _context.TechnicianItem.AsNoTracking()
                                                          .Include(x => x.IdBranchOfficeNavigation)
                                                          .Include(x => x.IdItemNavigation)
                                                          .Where(x => x.IdTechnician == data.IdTechnician).ToList();

                foreach (var itemA in listRelation)
                {
                    var dataRelation = new TechnicianInfoList();
                    dataRelation.IdTechnicianItem = itemA.IdTechnicianItem;
                    dataRelation.NameBranchOffice = itemA.IdBranchOfficeNavigation.Name;
                    dataRelation.NameItem = itemA.IdItemNavigation.NameItem;
                    dataRelation.ItemQuantity = itemA.ItemQuantity;

                    technicianData.TechnicianInfo.Add(dataRelation);
                }
                return technicianData;
            }

            return null;


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
                if (!requestCreateTechnicianDto.ListItems.Any())
                {
                    response.ResponseMessage($"Para la creación del Técnico debe tener mínimo un elemnto", false);
                    return response;
                }
                if (!requestCreateTechnicianDto.ListItems.GroupBy(item => item.IdItem).All(group => group.Count() == 1))
                {
                    response.ResponseMessage($"Verifica que no se repitan los elementos para el Técnico", false);
                    return response;
                }

                Technician newTechnician = new Technician();
                newTechnician.IdTechnician= Guid.NewGuid();
                newTechnician.Code= requestCreateTechnicianDto.Code;
                newTechnician.Name= requestCreateTechnicianDto.Name;
                newTechnician.Salary=requestCreateTechnicianDto.Salary;

                _context.Technician.Add(newTechnician);


                foreach (var item in requestCreateTechnicianDto.ListItems)
                {
                    TechnicianItem newRelation = new TechnicianItem();
                    newRelation.IdTechnicianItem = Guid.NewGuid();
                    newRelation.IdTechnician = newTechnician.IdTechnician;
                    newRelation.IdBranchOffice = item.IdBranchOffice;
                    newRelation.IdItem = item.IdItem;

                    if(!(item.ItemQuantity >= 1 && item.ItemQuantity <= 10))
                    {
                        response.ResponseMessage($"Verifica que mínimo sea 1 cantidad y máximo 10 para el item {item.IdItem}", false);
                        return response;
                    }

                    newRelation.ItemQuantity = item.ItemQuantity;

                    _context.TechnicianItem.Add(newRelation);
                }
                _context.SaveChanges();

            }
            return response;
        }

        public ResponseEndPointDTO<bool> UpdateTechnician(Guid IdTechnician,RequestUpdateTechnicianDto requestUpdateTechnicianDto)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();

            var technician = _context.Technician.AsNoTracking().FirstOrDefault(x=>x.IdTechnician == IdTechnician);
            if (technician != null) 
            {
                Technician technicianUpdate = new Technician();
                technicianUpdate.IdTechnician = IdTechnician;
                technicianUpdate.Code = requestUpdateTechnicianDto.Code is null? technician.Code: requestUpdateTechnicianDto.Code;
                technicianUpdate.Name = requestUpdateTechnicianDto.Name is null? technician.Name: requestUpdateTechnicianDto.Name;
                technicianUpdate.Salary=requestUpdateTechnicianDto.Salary is null? technician.Salary: requestUpdateTechnicianDto.Salary;


                _context.Technician.Update(technicianUpdate);
                _context.SaveChanges();
            }
            else
            {
                response.ResponseMessage($"No se encuentra informacion del Tecnico", false);
            }
            return response;
        }

        public ResponseEndPointDTO<bool> DeleteTechnician(Guid IdTechnician)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();

            var technician = _context.Technician.AsNoTracking().FirstOrDefault(x => x.IdTechnician == IdTechnician);
            if (technician != null)
            {
                var technicianItem = _context.TechnicianItem.AsNoTracking().Where(x => x.IdTechnician == IdTechnician).ToList();

                _context.TechnicianItem.RemoveRange(technicianItem);
                _context.Technician.Remove(technician);
                _context.SaveChanges();
            }
            else
            {
                response.ResponseMessage($"No se encuentra informacion del Tecnico", false);
            }
            return response;
        }
        #endregion
        #region Private Methods

        #endregion
    }
}
