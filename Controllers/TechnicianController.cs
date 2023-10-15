﻿using GestionFrancaApi.Application.Interface;
using GestionFrancaApi.DTO.GenericDTO;
using GestionFrancaApi.DTO.TechnicianDTO;
using GestionFrancaApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GestionFrancaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnicianController : ControllerBase
    {
        #region Fields
        private readonly ITechnicianApplication _technicianApplication;
        #endregion
        #region Builder
        public TechnicianController(ITechnicianApplication technicianApplication)
        {
            _technicianApplication = technicianApplication;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Servicio que me permite obtener el listado de los tecnicos registrados 
        /// </summary>
        /// <returns>Listado de las tecnicos en BD</returns>
        [HttpGet]
        [Route(nameof(TechnicianController.GetListTechnician))]
        public async Task<ResponseEndPointDTO<List<TechnicianDto>>> GetListTechnician()
        {
            return await Task.Run(() =>
            {
                return _technicianApplication.GetListTechnician();
            });
        }

        /// <summary>
        /// Servicio que me permite obtener información del tecnico registrado 
        /// </summary>
        /// <returns>Información del tecnico en BD</returns>
        [HttpGet]
        [Route(nameof(TechnicianController.GetTechnician))]
        public async Task<ResponseEndPointDTO<TechnicianDto>> GetTechnician(Guid IdTechnician)
        {
            return await Task.Run(() =>
            {
                return _technicianApplication.GetTechnician(IdTechnician);
            });
        }

        [HttpPost]
        [Route(nameof(TechnicianController.CreateTechnician))]
        public async Task<ResponseEndPointDTO<bool>> CreateTechnician(RequestTechnicianDto requestCreateTechnicianDto)
        {
            return await Task.Run(() =>
            {
                return _technicianApplication.CreateTechnician(requestCreateTechnicianDto);
            });
        }
        #endregion
    }
}