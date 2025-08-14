# API-Products

API para la gestión de productos, desarrollada en **.NET 8.0.16** con base de datos **SQL Server** desplegada en contenedor **Docker**.

## Tecnologías utilizadas

* **.NET 8.0.16**
* **SQL Server (Docker)**
* **Docker Desktop** (^4.41 o superior)
* **Entity Framework Core** (para acceso a datos)
* **JWT (JSON Web Token)** para autenticación y autorización

---

## Prerrequisitos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

* **Git**
* **Docker Desktop** (^4.41 o superior)
* **.NET SDK 8.0.16** o superior
* **Postman** (opcional, para pruebas manuales)

---

## Pasos para correr la API

1. **Clonar el repositorio**

   ```bash
   git clone https://github.com/Liz0716/Api-products.git
   cd Api-products
   ```

2. **Configurar la base de datos**

   * El proyecto incluye un archivo `docker-compose.yml` para levantar SQL Server.
   * Cambia la contraseña en `docker-compose.yml` y posteriormente en `appsettings.json` si quieres personalizarla.

3. **Levantar la base de datos con Docker**

   ```bash
   docker compose up -d
   ```

   * Esto creará un contenedor con SQL Server en el puerto `1433`.

4. **Configurar `appsettings.json`**

   * Cadena de conexión:

     ```json
     {
       "ConnectionStrings": {
         "StoreConnection": "Server=localhost,1433;Database=ProductDb;User Id=SA;Password=TuPassword123!;TrustServerCertificate=True"
       }
     }
     ```

   * JWT:

     ```json
     "Jwt": {
       "Issuer": "TechOrdersApi",
       "Audience": "TechOrdersClients",
       "Key": "r9ZtM5pXk7wQeL2uF6JcNvYb8HtRuC1ohjklfghjklnhugctcgvhbhvu",
       "AccessTokenMinutes": 14400
     }
     ```

   > Cambia `TuPassword123!` y `Key` por valores seguros.

5. **Ejecutar las migraciones de la base de datos**

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

6. **Ejecutar la API**

   ```bash
   dotnet build
   dotnet run
   ```

   La API estará disponible en:

   * `http://localhost:5147` (HTTP)

---

## Pruebas con Postman

1. **Importar la colección**

   * En la carpeta `/Postman` del repositorio encontrarás la colección lista para importar en Postman.

2. **Configurar variables de entorno**

   * `baseUrl` → `https://localhost:5147`
   * `token` → Se actualizará automáticamente tras iniciar sesión en la API.

3. **Flujo recomendado de prueba**

   1. Registrar usuario (`POST /api/auth/register`)
   2. Iniciar sesión (`POST /api/auth/login`) → Copiar token JWT al entorno de Postman
   3. Probar endpoints protegidos como creación, actualización, lectura y eliminación de productos (`/api/products`)

---

## Estructura del proyecto

```
ApiProducts/
├── ApiProducts.csproj
├── ApiProducts.sln
├── appsettings.json
├── appsettings.Development.json
├── docker-compose.yml
├── README.md
├── Controllers/
│   └── AuthController.cs
├── Models/
│   ├── Auth.cs
│   ├── OrderItems.cs
│   ├── Orders.cs
│   ├── ProductContext.cs
│   ├── Products.cs
│   ├── Rol.cs
│   └── Users.cs
├── Services/
│   └── JwtService.cs
├── Migrations/
└── Postman/
```

---

## Licencia

**Pendiente**
