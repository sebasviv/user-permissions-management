using Models;
using UserPermissionsManagement.Contexts;
using UserPermissionsManagement.Repositories;
namespace UserPermissionsManagement.Services;

public class PermissionService : IPermissionService
{

    private readonly IPermissionRepository permissionRepository;

    public PermissionService(IPermissionRepository repository)
    {
        permissionRepository = repository;
    }
    public IEnumerable<Permission> Get()
    {
        return permissionRepository.GetAll();
    }

    public async Task Save(Permission permission)
    {
        try
        {
            await permissionRepository.Add(permission);
      
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }

    }

    public async Task Update(int id, Permission permission)
    {
        try
        {
            var permissionToUpdate = await permissionRepository.GetById(id);

            if (permissionToUpdate != null)
            {
                permissionToUpdate.NombreEmpleado = permission.NombreEmpleado;
                permissionToUpdate.ApellidoEmpleado = permission.ApellidoEmpleado;
                permissionToUpdate.TipoPermisoId = permission.TipoPermisoId;
                permissionToUpdate.FechaPermiso = permission.FechaPermiso;

                await permissionRepository.Update(permissionToUpdate);
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
            await permissionRepository.Delete(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }

    }

}


public interface IPermissionService
{
    IEnumerable<Permission> Get();

    Task Save(Permission permission);

    Task Update(int id, Permission permission);

    Task Delete(int id);
}