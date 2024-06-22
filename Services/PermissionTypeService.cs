using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserPermissionsManagement.Repositories;

namespace UserPermissionsManagement.Services
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PermissionType> Get()
        {
            return _unitOfWork.PermissionTypes.GetAll();
        }

        public async Task Save(PermissionType permissionType)
        {
            await _unitOfWork.PermissionTypes.Add(permissionType);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(int id, PermissionType permissionType)
        {
            var existingPermissionType = await _unitOfWork.PermissionTypes.GetById(id);
            if (existingPermissionType != null)
            {
                existingPermissionType.Description = permissionType.Description;
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.PermissionTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
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
