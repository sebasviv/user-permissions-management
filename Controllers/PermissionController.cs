using Microsoft.AspNetCore.Mvc;
using Models;
using UserPermissionsManagement.Services;

namespace UserPermissionsManagement.Controllers;

[Route("api/[controller]")]
public class PermisssionController : ControllerBase
{
    IPermissionService permissionService;
    public PermisssionController(IPermissionService service)
    {
        this.permissionService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(permissionService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Permission permission)
    {
        permissionService.Save(permission);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Permission permission)
    {
        permissionService.Update(id, permission);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        permissionService.Delete(id);
        return Ok();
    }
}