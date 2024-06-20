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
        List<Permission> permissionInit = new List<Permission>();
        List<PermissionType> permissionTypeInit = new List<PermissionType>();

        permissionInit.Add(new Permission { Id = 1, NombreEmpleado = "Juan", ApellidoEmpleado = "Perez", FechaPermiso = DateTime.Now, TipoPermisoId = 1});
        permissionInit.Add(new Permission { Id = 2, NombreEmpleado = "Maria", ApellidoEmpleado = "Gomez", FechaPermiso = DateTime.Now, TipoPermisoId = 2});
        permissionInit.Add(new Permission { Id = 3, NombreEmpleado = "Pedro", ApellidoEmpleado = "Rodriguez", FechaPermiso = DateTime.Now, TipoPermisoId = 3});

        permissionTypeInit.Add(new PermissionType { Id = 1, Description = "Vacaciones"});
        permissionTypeInit.Add(new PermissionType { Id = 2, Description = "Enfermedad"});
        permissionTypeInit.Add(new PermissionType { Id = 3, Description = "Permiso sin goce de sueldo"});

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

            permission.HasData(permissionInit);
        });

        modelBuilder.Entity<PermissionType>(permissionType =>
        {
            permissionType.ToTable("PermissionType");
            permissionType.HasKey(p => p.Id);
            permissionType.Property(p => p.Description).IsRequired();

            permissionType.HasData(permissionTypeInit);
        });
    }
}