namespace GestionFrancaApi.DTO.TechnicianDTO
{
    public class RequestUpdateTechnicianDto
    {
        /// <summary>
        /// Id de la tabla Technician
        /// </summary>
        public Guid IdTechnician { get; set; }
        /// <summary>
        /// Codigo del Tecnico (Actualizar)
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Nombre del Tecnico (Actualizar)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Salario del Tecnico (Actualizar)
        /// </summary>
        public decimal? Salary { get; set; }
    }
}
