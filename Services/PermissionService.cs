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
        context.Add(permission);
        await context.SaveChangesAsync();
    }

    public async Task Update(int id, Permission permission)
    {
        var permissionToUpdate = context.Permissions.Find(id);

        if (permissionToUpdate != null)
        {
            permissionToUpdate.NombreEmpleado = permission.NombreEmpleado;
            permissionToUpdate.ApellidoEmpleado = permission.ApellidoEmpleado;
            permissionToUpdate.TipoPermisoId = permission.TipoPermisoId;
            permissionToUpdate.FechaPermiso = permission.FechaPermiso;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var permissionToDelete = context.Permissions.Find(id);

        if (permissionToDelete != null)
        {
            context.Permissions.Remove(permissionToDelete);
            await context.SaveChangesAsync();
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