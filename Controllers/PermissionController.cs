using Microsoft.AspNetCore.Mvc;
using Models;
using UserPermissionsManagement.Services;

namespace UserPermissionsManagement.Controllers;

[Route("api/[controller]")]
public class PermissionController : ControllerBase
{
    readonly IPermissionService permissionService;
    public PermissionController(IPermissionService service)
    {
        this.permissionService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(permissionService.Get());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Permission permission)
    {
        await permissionService.Save(permission);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Permission permission)
    {
        await permissionService.Update(id, permission);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await permissionService.Delete(id);
        return Ok();
    }
}