using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Permission
{

    public Guid Id { get; set; }

    public string NombreEmpleado { get; set; }
    public string ApellidoEmpleado { get; set; }
    public Guid TipoPermisoId { get; set; }
    public PermissionType TipoPermiso { get; set; }
    public DateTime FechaPermiso { get; set; }
}
