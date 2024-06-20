using Models;
using UserPermissionsManagement.Contexts;
namespace UserPermissionsManagement.Services;

public class PermissionTypeService: IPermissionTypeService {
    private readonly UserPermissionsContext context;
    public PermissionTypeService(UserPermissionsContext dbcontext) {
        context = dbcontext;
    }
    public IEnumerable<PermissionType> Get() {
        return context.PermissionTypes.ToList();
    }
    public async Task Save(PermissionType permissionType) {
        context.Add(permissionType);
        await context.SaveChangesAsync();
    }
    public async Task Update(int id, PermissionType permissionType) {
        var permissionTypeToUpdate = context.PermissionTypes.Find(id);
        if (permissionTypeToUpdate != null) {
            permissionTypeToUpdate.Description = permissionType.Description;
            await context.SaveChangesAsync();
        }
    }
    public async Task Delete(int id) {
        var permissionTypeToDelete = context.PermissionTypes.Find(id);
        if (permissionTypeToDelete != null) {
            context.PermissionTypes.Remove(permissionTypeToDelete);
            await context.SaveChangesAsync();
        }
    }
}

public interface IPermissionTypeService {
    IEnumerable<PermissionType> Get();
    Task Save(PermissionType permissionType);
    Task Update(int id, PermissionType permissionType);
    Task Delete(int id);
}
