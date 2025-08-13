

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

* **Docker Desktop** (^4.41 o superior)
* **.NET SDK 8.0.16** o superior
* **Git**
* **Postman** (opcional, para pruebas manuales)

---

## Configuración

1. **Base de datos**

   * El proyecto incluye un archivo `docker-compose.yml` para levantar un contenedor de SQL Server.
   * Para iniciar la base de datos:

     ```bash
     docker-compose up -d
     ```
   * Esto creará un contenedor con SQL Server en el puerto `1433`.

2. **Connection String**

   * La cadena de conexión se encuentra en `appsettings.Development.json`:

     ```json
     "ConnectionStrings": {
       "DefaultConnection": "**pendiente**"
     }
     ```
   * Cambia `TuPasswordSegura` por una contraseña segura (y actualízala también en `docker-compose.yml` si es necesario).

3. **JWT**

   * En el mismo archivo `appsettings.json`, define tu clave secreta para firmar los tokens:

     ```json
     "Jwt": {
       "Key": "**configurar aqui la clave secreta**",
       "Issuer": "ApiProducts",
       "Audience": "ApiProductsUsers"
     }
     ```

---

## Pasos para correr la API

1. **Clonar el repositorio**

   ```bash
   git clone https://github.com/tuusuario/Api-products.git](https://github.com/Liz0716/Api-products.git
   cd Api-products
   ```

2. **Levantar la base de datos con Docker**

   ```bash
   docker-compose up -d
   ```

3. **Ejecutar las migraciones de la base de datos** **Pendiente a revisar si haremos migraciones**

   ```bash
   dotnet ef database update
   ```

4. **Ejecutar la API**

   ```bash
   dotnet run
   ```

   La API estará disponible en: **Pendiente**

   * `https://localhost:` (HTTPS)
   * `http://localhost:` (HTTP)

---

## Pruebas con Postman **Pendiente**

1. **Importar la colección**

   * En la carpeta `/postman` del repositorio (crea esta carpeta y coloca un archivo `.json` con la colección de Postman exportada), encontrarás la colección lista para importar en Postman.

2. **Configurar variables de entorno**

   * `baseUrl` → `https://localhost:5001`
   * `token` → Se actualizará automáticamente tras iniciar sesión en la API.

3. **Flujo recomendado de prueba** **Pendiente si las rutas quedan asi**

   1. **Registrar usuario** (`POST /api/auth/register`)
   2. **Iniciar sesión** (`POST /api/auth/login`) → Copiar token JWT al entorno de Postman
   3. **Probar endpoints protegidos** como creación, actualización y eliminación de productos (`/api/products`)

---

## Estructura del proyecto

```
Api-products/
├── Api-products.csproj
├── Controllers/
├── Models/
├── Services/
├── Data/
├── appsettings.json
├── appsettings.Development.json
├── docker-compose.yml
└── README.md
```

---

## Licencia
**Pendiente**
---
