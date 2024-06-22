
using UserPermissionsManagement.Contexts;

namespace UserPermissionsManagement.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPermissionTypeRepository PermissionTypes { get; }
        IPermissionRepository Permissions { get; }

        Task<int> CompleteAsync();
    }


    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserPermissionsContext _context;

        public UnitOfWork(UserPermissionsContext context)
        {
            _context = context;
            PermissionTypes = new PermissionTypeRepository(_context);
            Permissions = new PermissionRepository(_context);
        }

        public IPermissionTypeRepository PermissionTypes { get; private set; }
        public IPermissionRepository Permissions { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
