using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Permission
{

    public int Id { get; set; }

    public string NombreEmpleado { get; set; }
    public string ApellidoEmpleado { get; set; }
    public int TipoPermisoId { get; set; }
    public PermissionType TipoPermiso { get; set; }
    public DateTime FechaPermiso { get; set; }
}
