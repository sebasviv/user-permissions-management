# .Net 8 + Entity Framework Core 8 + SQL Server

Para correr el proyecto debe tener instalado .Net 8 y SQL Server. 

Este proyecto contiene datos semillas para la tablas Permission y PermissionTypes para validar su creacion en la base de datos.


## Pasos para correr el proyecto
1. Clonar el repositorio
2. Abrir el proyecto en Visual Studio
3. Cambiar la cadena de conexión en el archivo `appsettings.json` por la cadena de conexión de su base de datos.
4. Ejecutar el comando dotnet ef database update en la consola de Nuget Package Manager para crear la base de datos.
5. Ejecutar el comando dotnet run en la consola de Nuget Package Manager para correr el proyecto.

## Endpoints
1. GET /api/permissions
2. POST /api/permissions
3. PUT /api/permissions/{id}
4. DELETE /api/permissions/{id}
5. GET /api/permissiontypes
6. POST /api/permissiontypes
7. PUT /api/permissiontypes/{id}
8. DELETE /api/permissiontypes/{id}

## Ejemplo de datos para crear un permiso.
```json
{
    "nombreEmpleado": "test",
    "apellidoEmpleado": "test",
    "tipoPermisoId": 2,
    "fechaPermiso": "2024-06-21T00:00:00Z"
}
```

## Ejemplo de datos para crear un permiso tipo de permiso.
```json
{
    "description": "Crear un registro"
}
```