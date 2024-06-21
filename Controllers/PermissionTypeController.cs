using Microsoft.AspNetCore.Mvc;
using Models;
using UserPermissionsManagement.Services;
namespace UserPermissionsManagement.Controllers
{
    [Route("api/[controller]")]
    public class PermissionTypeController : ControllerBase
    {
        IPermissionTypeService permissionTypeService;
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
        public IActionResult Post([FromBody] PermissionType permissionType)
        {
            permissionTypeService.Save(permissionType);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PermissionType permissionType)
        {
            permissionTypeService.Update(id, permissionType);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            permissionTypeService.Delete(id);
            return Ok();
        }
    }
}