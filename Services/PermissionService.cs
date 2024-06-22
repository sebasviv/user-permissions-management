using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserPermissionsManagement.Repositories;

namespace UserPermissionsManagement.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Permission> Get()
        {
            return _unitOfWork.Permissions.GetAll();
        }

        public async Task Save(Permission permission)
        {
            await _unitOfWork.Permissions.Add(permission);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(int id, Permission permission)
        {
            var permissionToUpdate = await _unitOfWork.Permissions.GetById(id);
            if (permissionToUpdate != null)
            {
                permissionToUpdate.NombreEmpleado = permission.NombreEmpleado;
                permissionToUpdate.ApellidoEmpleado = permission.ApellidoEmpleado;
                permissionToUpdate.TipoPermisoId = permission.TipoPermisoId;
                permissionToUpdate.FechaPermiso = permission.FechaPermiso;
            }
            await _unitOfWork.CompleteAsync();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.Permissions.Delete(id);
            await _unitOfWork.CompleteAsync();
        }
    }

    public interface IPermissionService
    {
        IEnumerable<Permission> Get();
        Task Save(Permission permission);
        Task Update(int id, Permission permission);
        Task Delete(int id);
    }
}
