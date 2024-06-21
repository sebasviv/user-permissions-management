using Models;
using UserPermissionsManagement.Contexts;
namespace UserPermissionsManagement.Services;

public class PermissionTypeService : IPermissionTypeService
{
    private readonly UserPermissionsContext context;
    public PermissionTypeService(UserPermissionsContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<PermissionType> Get()
    {
        return context.PermissionTypes.ToList();
    }
    public async Task Save(PermissionType permissionType)
    {

        try
        {
            await context.AddAsync(permissionType);
            await context.SaveChangesAsync();
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
            var permissionTypeToUpdate = await context.PermissionTypes.FindAsync(id);
            if (permissionTypeToUpdate != null)
            {
                permissionTypeToUpdate.Description = permissionType.Description;
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
            var permissionTypeToDelete = await context.PermissionTypes.FindAsync(id);
            if (permissionTypeToDelete != null)
            {
                context.PermissionTypes.Remove(permissionTypeToDelete);
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

public interface IPermissionTypeService
{
    IEnumerable<PermissionType> Get();
    Task Save(PermissionType permissionType);
    Task Update(int id, PermissionType permissionType);
    Task Delete(int id);
}
