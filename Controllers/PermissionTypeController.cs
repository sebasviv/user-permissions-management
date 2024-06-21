using Microsoft.AspNetCore.Mvc;
using Models;
using UserPermissionsManagement.Services;
namespace UserPermissionsManagement.Controllers
{
    [Route("api/[controller]")]
    public class PermissionTypeController : ControllerBase
    {
        readonly IPermissionTypeService permissionTypeService;
        public PermissionTypeController(IPermissionTypeService service)
        {
            this.permissionTypeService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(permissionTypeService.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PermissionType permissionType)
        {
            await permissionTypeService.Save(permissionType);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PermissionType permissionType)
        {
            await permissionTypeService.Update(id, permissionType);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await permissionTypeService.Delete(id);
            return Ok();
        }
    }
}