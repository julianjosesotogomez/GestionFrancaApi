using GestionFrancaApi.Domain.Entities.GestionFrancaEntities;

namespace GestionFrancaApi.Domain.Interface
{
    public interface IGenericDomainService
    {
        public List<BranchOffice> GetListBranchOffice();
        public List<Items> GetListItem();
    }
}
