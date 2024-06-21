using Models;
using UserPermissionsManagement.Contexts;
namespace UserPermissionsManagement.Services;

public class PermissionService : IPermissionService
{

    readonly UserPermissionsContext context;

    public PermissionService(UserPermissionsContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Permission> Get()
    {
        return context.Permissions.ToList();
    }

    public async Task Save(Permission permission)
    {
        try
        {
            await context.AddAsync(permission);
            await context.SaveChangesAsync();
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
            var permissionToUpdate = await context.Permissions.FindAsync(id);

            if (permissionToUpdate != null)
            {
                permissionToUpdate.NombreEmpleado = permission.NombreEmpleado;
                permissionToUpdate.ApellidoEmpleado = permission.ApellidoEmpleado;
                permissionToUpdate.TipoPermisoId = permission.TipoPermisoId;
                permissionToUpdate.FechaPermiso = permission.FechaPermiso;

                await context.SaveChangesAsync();
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
            var permissionToDelete = await context.Permissions.FindAsync(id);

            if (permissionToDelete != null)
            {
                context.Permissions.Remove(permissionToDelete);
                await context.SaveChangesAsync();
            }
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