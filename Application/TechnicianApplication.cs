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
                    response.Result = listData;
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
                var data = _technicianDomainService.GetTechnician(IdTechnician);
                if (data == null)
                {
                    response.ResponseMessage("No hay registro del tecnico en BD", false);
                }
                else
                {
                    response.Result = data;
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
                var validateData = ValidateData(requestCreateTechnicianDto.Code);
                if (validateData != null)
                {
                    response.ResponseMessage(validateData, false);
                }
                else
                {
                    var resultCreate = _technicianDomainService.CreateTechnician(requestCreateTechnicianDto);
                    if (!resultCreate.Successful)
                    {
                        response.ResponseMessage(resultCreate.Message,false);
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
        public ResponseEndPointDTO<bool> UpdateTechnician(Guid IdTechnician,RequestUpdateTechnicianDto requestUpdateTechnicianDto)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();
            try
            {
                var validateData = ValidateData(requestUpdateTechnicianDto.Code);
                if (validateData != null)
                {
                    response.ResponseMessage(validateData, false);
                }
                else
                {
                    var resultUpdate = _technicianDomainService.UpdateTechnician(IdTechnician,requestUpdateTechnicianDto);
                    if (!resultUpdate.Successful)
                    {
                        response.ResponseMessage(resultUpdate.Message, false);
                    }
                    else
                    {
                        response.Result = resultUpdate.Result;
                    }
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }

        public ResponseEndPointDTO<bool> DeleteTechnician(Guid IdTechnician)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();
            try
            {
                var resultUpdate = _technicianDomainService.DeleteTechnician(IdTechnician);
                if (!resultUpdate.Successful)
                {
                    response.ResponseMessage(resultUpdate.Message, false);
                }
                else
                {
                    response.Result = resultUpdate.Result;
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
        private string ValidateData(string code)
        {
            //Validacion de Code 
            if (!Regex.IsMatch(code, PATTERN_CODE))
                return $"El formato del codigo ingresado {code} no es valido";
            
            //Se pueden realizar mas validaciones si es necesario 

            return null;
        }
        #endregion

    }
}
