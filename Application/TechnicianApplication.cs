using AutoMapper;
using GestionFrancaApi.Application.Interface;
using GestionFrancaApi.Domain.Interface;
using GestionFrancaApi.DTO.GenericDTO;
using GestionFrancaApi.DTO.TechnicianDTO;
using GestionFrancaApi.DTOs;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;

namespace GestionFrancaApi.Application
{
    public class TechnicianApplication:ITechnicianApplication
    {
        #region Fields
        private readonly ITechnicianDomainService _technicianDomainService;
        private readonly IMapper _mapper;
        #endregion
        #region Const
        private const string PATTERN_CODE = "^[a-zA-Z0-9]*$";
        private const string PATTERN_SALARY = @"^\d{8}.\d{2}$";
        #endregion
        #region Builder
        public TechnicianApplication(ITechnicianDomainService technicianDomainService, IMapper mapper)
        {
            _technicianDomainService = technicianDomainService;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public ResponseEndPointDTO<List<TechnicianDto>> GetListTechnician()
        {
            ResponseEndPointDTO<List<TechnicianDto>> response = new ResponseEndPointDTO<List<TechnicianDto>>();
            try
            {
                var listData = _technicianDomainService.GetListTechnicians();
                if (!listData.Any())
                {
                    response.ResponseMessage("No se encuentran tecnicos registrados en BD", false);
                }
                else
                {
                    var resultList = _mapper.Map<List<TechnicianDto>>(listData);//Se realiza mapeo directamente a la entidad 
                    response.Result = resultList;
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }

        public ResponseEndPointDTO<TechnicianDto> GetTechnician(Guid IdTechnician)
        {
            ResponseEndPointDTO<TechnicianDto> response = new ResponseEndPointDTO<TechnicianDto>();
            try
            {
                var listData = _technicianDomainService.GetListTechnicians();
                if (!listData.Any())
                {
                    response.ResponseMessage("No hay registro del tecnico en BD", false);
                }
                else
                {
                    var resultList = _mapper.Map<TechnicianDto>(listData);//Se realiza mapeo directamente a la entidad 
                    response.Result = resultList;
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }

        public ResponseEndPointDTO<bool> CreateTechnician(RequestTechnicianDto requestCreateTechnicianDto)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();
            try
            {
                var validateData = ValidateData(requestCreateTechnicianDto);
                if (validateData != null)
                {
                    response.ResponseMessage(validateData, false);
                }
                else
                {
                    var resultCreate = _technicianDomainService.CreateTechnician(requestCreateTechnicianDto);
                    if (!resultCreate.Result)
                    {
                        response.ResponseMessage("No hay registro del tecnico en BD", false);
                    }
                    else
                    {

                        response.Result = resultCreate.Result;
                    }
                }

            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }
        #endregion
        #region Private Method
        /// <summary>
        /// Validación de data ingresada
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        private string ValidateData(RequestTechnicianDto requestTechnicianDto)
        {
            //Validacion de Code 
            if (!Regex.IsMatch(requestTechnicianDto.Code, PATTERN_CODE))
                return $"El formato del codigo ingresado {requestTechnicianDto.Code} no es valido";
            //Vaidacion de salary
            if (!Regex.IsMatch(requestTechnicianDto.Salary.ToString("0.00"), PATTERN_SALARY))
                return $"El formato de Salry para el valor {requestTechnicianDto.Salary} es incorrecto";

            return null;
        }
        #endregion

    }
}
