namespace Models;

public class PermissionType
{

    public Guid Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Permission> Permission { get; set; }
}
