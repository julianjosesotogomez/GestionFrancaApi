using AutoMapper;
using GestionFrancaApi.Application.Interface;
using GestionFrancaApi.Domain.Interface;
using GestionFrancaApi.DTO.GenericDTO;
using GestionFrancaApi.DTOs;
using Microsoft.AspNetCore.Routing.Matching;
using System.Threading.Tasks;

namespace GestionFrancaApi.Application
{
    public class GenericApplication:IGenericApplication
    {
        #region Fields
        private readonly IGenericDomainService _genericDomainServices;
        private readonly IMapper _mapper;
        #endregion
        #region Builder
        public GenericApplication(IGenericDomainService genericDomainServices, IMapper mapper) 
        {
            _genericDomainServices = genericDomainServices;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public ResponseEndPointDTO<List<BranchOfficeDto>> GetListBranchOffice()
        {
            ResponseEndPointDTO<List<BranchOfficeDto>> response = new ResponseEndPointDTO<List<BranchOfficeDto>>();
            try
            {
                var listData = _genericDomainServices.GetListBranchOffice();
                if (!listData.Any())
                {
                    response.ResponseMessage("No se encuentran sucursales registradas en BD", false);
                }
                else
                {
                    var resultList = _mapper.Map<List<BranchOfficeDto>>(listData);//Se realiza mapeo directamente a la entidad 
                    response.Result = resultList;
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }

        public ResponseEndPointDTO<List<ItemsDto>> GetListItem()
        {
            ResponseEndPointDTO<List<ItemsDto>> response = new ResponseEndPointDTO<List<ItemsDto>>();
            try
            {
                var listData = _genericDomainServices.GetListItem();
                if (!listData.Any())
                {
                    response.ResponseMessage("No se encuentran items registradas en BD", false);
                }
                else
                {
                    var resultList = _mapper.Map<List<ItemsDto>>(listData);//Se realiza mapeo directamente a la entidad 
                    response.Result = resultList;
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }
        #endregion
    }
}
