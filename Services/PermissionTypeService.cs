using Models;
using UserPermissionsManagement.Repositories;
namespace UserPermissionsManagement.Services
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IPermissionTypeRepository permissionTypeRepository;

        public PermissionTypeService(IPermissionTypeRepository repository)
        {
            permissionTypeRepository = repository;
        }

        public IEnumerable<PermissionType> Get()
        {
            return permissionTypeRepository.GetAll();
        }

        public async Task Save(PermissionType permissionType)
        {
            try
            {
                await permissionTypeRepository.Add(permissionType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }

        public async Task Update(int id, PermissionType permissionType)
        {
            try
            {
                var existingPermissionType = await permissionTypeRepository.GetById(id);
                if (existingPermissionType != null)
                {
                    existingPermissionType.Description = permissionType.Description;
                    await permissionTypeRepository.Update(existingPermissionType);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await permissionTypeRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }
    }

    public interface IPermissionTypeService
    {
        IEnumerable<PermissionType> Get();
        Task Save(PermissionType permissionType);
        Task Update(int id, PermissionType permissionType);
        Task Delete(int id);
    }
}
