using System;
using System.Collections.Generic;

namespace GestionFrancaApi.Domain.Entities.GestionFrancaEntities
{
    public partial class Technician
    {
        public Guid IdTechnician { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public decimal? Salary { get; set; }
    }
}
