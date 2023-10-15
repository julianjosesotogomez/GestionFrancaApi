using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionFrancaApi.DTO.TechnicianDTO
{
    public class RequestTechnicianDto
    {
        /// <summary>
        /// Codigo del tecnico
        /// </summary>
        public string Code {  get; set; }
        /// <summary>
        /// Nombre del tecnico
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Salario del tecnico
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// Listado de los items a registrar
        /// </summary>
        public List<ListItem> ListItems { get; set; }
        
    }
    public class ListItem
    {
        /// <summary>
        /// Id del Item
        /// </summary>
        public Guid IdItem { get; set; }
        /// <summary>
        /// Cantidad del Item
        /// </summary>
        public int ItemQuantity { get; set; }
        /// <summary>
        /// Id de la sucursal donde se registra
        /// </summary>
        public Guid IdBranchOffice { get; set; }
    }
}
