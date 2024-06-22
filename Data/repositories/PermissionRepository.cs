using Models;
using UserPermissionsManagement.Contexts;

namespace UserPermissionsManagement.Repositories
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        
    }

    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(UserPermissionsContext context) : base(context)
        {
        }
    }
}