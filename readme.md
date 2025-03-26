#ReservaApp

Aplicación web para gestionar reservas de servicios.  
Permite al usuario seleccionar un servicio, una fecha y hora, ingresar su nombre y crear una reserva.  
También permite visualizar todas las reservas existentes.

--Pasos para levantar el proyecto--

Levantar el Backend

1- Configurar connectionString en appsettings.json
2- Ir a la raiz del proyecto en consola
3- Aplicar las migraciones (dotnet ef database update)
4- Ejecutar la API (dotnet run)
5- Ir a "https://localhost:7039/swagger" para ver la API.

Levantar el Frontend

1- Ir a la carpeta del front end
2- Instalar dependencias(npm install)
3- Ejecutar la App (npm start)

