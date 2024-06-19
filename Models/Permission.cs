using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

    public class Permission
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string NombreEmpleado { get; set; }
        [Required]
        public string ApellidoEmpleado { get; set; }
        [Required]
        [ForeignKey("TipoPermiso")]
        public int TipoPermiso { get; set; }
        [Required]
        public DateTime FechaPermiso { get; set; }
    }
