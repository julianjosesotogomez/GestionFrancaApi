namespace GestionFrancaApi.DTO.TechnicianDTO
{
    public class TechnicianDto
    {
        public Guid IdTechnician { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public decimal? Salary { get; set; }
        public Guid? IdBranchOffice { get; set; }
        public Guid? IdItem { get; set; }
        public int? ItemQuantity { get; set; }
    }
}
