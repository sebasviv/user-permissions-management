using Models;
using UserPermissionsManagement.Contexts;

namespace UserPermissionsManagement.Repositories
{
    public interface IPermissionTypeRepository : IRepository<PermissionType>
    {
        
    }

    public class PermissionTypeRepository : Repository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(UserPermissionsContext context) : base(context)
        {
        }
    }
}
