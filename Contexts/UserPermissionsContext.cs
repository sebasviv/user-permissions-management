namespace UserPermissionsManagement.Contexts;
using Microsoft.EntityFrameworkCore;
using Models;

public class UserPermissionsContext : DbContext
{
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<PermissionType> PermissionTypes { get; set; }

    public UserPermissionsContext(DbContextOptions<UserPermissionsContext> options) : base(options){}
}