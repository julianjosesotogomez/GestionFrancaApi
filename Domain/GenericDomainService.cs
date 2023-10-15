using GestionFrancaApi.DataAccess.Context;
using GestionFrancaApi.Domain.Entities.GestionFrancaEntities;
using GestionFrancaApi.Domain.Interface;

namespace GestionFrancaApi.Domain
{
    public class GenericDomainService: IGenericDomainService
    {
        #region Fields
        protected readonly GestionFrancaContext _context;
        #endregion
        #region Builder
        public GenericDomainService(GestionFrancaContext context) 
        {
            _context = context;
        }
        #endregion
        #region Methods
        public List<BranchOffice> GetListBranchOffice()
        {
            return _context.BranchOffice.ToList();
        }

        public List<Items> GetListItem()
        {
            return _context.Items.ToList();
        }
        #endregion
    }
}
