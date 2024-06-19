using System.ComponentModel.DataAnnotations;

namespace Models;

public class PermissionType
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Description { get; set; }
}
