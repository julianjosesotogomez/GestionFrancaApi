using System;
using System.Collections.Generic;

namespace GestionFrancaApi.Domain.Entities.GestionFrancaEntities
{
    public partial class Items
    {
        public Items()
        {
            TechnicianItem = new HashSet<TechnicianItem>();
        }

        public Guid IdItem { get; set; }
        public string? Code { get; set; }
        public string? NameItem { get; set; }

        public virtual ICollection<TechnicianItem> TechnicianItem { get; set; }
    }
}
