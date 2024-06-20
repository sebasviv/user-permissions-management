namespace UserPermissionsManagement.Contexts;
using Microsoft.EntityFrameworkCore;
using Models;

public class UserPermissionsContext : DbContext
{
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<PermissionType> PermissionTypes { get; set; }

    public UserPermissionsContext(DbContextOptions<UserPermissionsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>(permission =>
        {
            permission.ToTable("Permission");
            permission.HasKey(p => p.Id);
            permission.Property(p => p.NombreEmpleado).IsRequired();
            permission.Property(p => p.ApellidoEmpleado).IsRequired();
            permission.Property(p => p.FechaPermiso).IsRequired();

            permission.HasOne(p => p.TipoPermiso)
                    .WithMany(pt => pt.Permission)
                    .HasForeignKey(p => p.TipoPermisoId);
        });

        modelBuilder.Entity<PermissionType>(permissionType =>
        {
            permissionType.ToTable("PermissionType");
            permissionType.HasKey(p => p.Id);
            permissionType.Property(p => p.Description).IsRequired();
        });
    }
}