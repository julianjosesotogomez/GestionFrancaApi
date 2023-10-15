using System;
using System.Collections.Generic;

namespace GestionFrancaApi.Domain.Entities.GestionFrancaEntities
{
    public partial class TechnicianItem
    {
        public Guid IdTechnicianItem { get; set; }
        public Guid? IdTechnician { get; set; }
        public Guid? IdBranchOffice { get; set; }
        public Guid? IdItem { get; set; }
        public int? ItemQuantity { get; set; }

        public virtual BranchOffice? IdBranchOfficeNavigation { get; set; }
        public virtual Items? IdItemNavigation { get; set; }
    }
}
