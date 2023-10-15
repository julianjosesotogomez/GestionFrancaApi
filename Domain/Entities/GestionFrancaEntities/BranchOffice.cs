using System;
using System.Collections.Generic;

namespace GestionFrancaApi.Domain.Entities.GestionFrancaEntities
{
    public partial class BranchOffice
    {
        public BranchOffice()
        {
            TechnicianItem = new HashSet<TechnicianItem>();
        }

        public Guid IdBranchOffice { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<TechnicianItem> TechnicianItem { get; set; }
    }
}
