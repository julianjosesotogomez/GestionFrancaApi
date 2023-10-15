namespace GestionFrancaApi.DTO.TechnicianDTO
{
    public class TechnicianDto
    {
        /// <summary>
        /// Id del tecnico 
        /// </summary>
        public Guid IdTechnician { get; set; }
        /// <summary>
        /// Codigo del tecnico
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Nombre del tecnico
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Salario del tecnico
        /// </summary>
        public decimal? Salary { get; set; }
        /// <summary>
        /// Lista de la informacion relaciona Elementos- Sucursal
        /// </summary>
        public List<TechnicianInfoList> TechnicianInfo { get; set; }
    }
    public class TechnicianInfoList
    {
        /// <summary>
        /// Id de la relacion Elementos -Sucursal
        /// </summary>
        public Guid IdTechnicianItem { get; set; }
        /// <summary>
        /// Nombre de la sucursal
        /// </summary>
        public string NameBranchOffice { get; set; }
        /// <summary>
        /// Nombre del elemento
        /// </summary>
        public string NameItem { get; set; }
        /// <summary>
        /// cantidad del elemento
        /// </summary>
        public int? ItemQuantity { get; set; }
    }
}
