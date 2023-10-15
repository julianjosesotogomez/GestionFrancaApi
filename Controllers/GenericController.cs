
using GestionFrancaApi.Application.Interface;
using GestionFrancaApi.DTO.GenericDTO;
using GestionFrancaApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GestionFrancaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController: ControllerBase
    {
        #region Fields
        private readonly IGenericApplication _genericApplication;
        #endregion
        #region Builder
        public GenericController(IGenericApplication genericApplication) 
        {
            _genericApplication = genericApplication;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Servicio que me permite obtener el listado de las sucursales
        /// </summary>
        /// <returns>Listado de las sucursales en BD</returns>
        [HttpGet]
        [Route(nameof(GenericController.GetListBranchOffice))]
        public async Task<ResponseEndPointDTO<List<BranchOfficeDto>>> GetListBranchOffice()
        {
            return await Task.Run(() =>
            {
                return _genericApplication.GetListBranchOffice();
            });
        }

        /// <summary>
        /// Servicio que me permite obtener el listado de los items
        /// </summary>
        /// <returns>Listado de los items en BD</returns>
        [HttpGet]
        [Route(nameof(GenericController.GetListItems))]
        public async Task<ResponseEndPointDTO<List<ItemsDto>>> GetListItems()
        {
            return await Task.Run(() =>
            {
                return _genericApplication.GetListItem();
            });
        }
        #endregion
    }
}
