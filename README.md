# RRHH_UDLA ANDRES DAVILA BASTIDAS
Proyecto RRHH Proceso Seleccion
# Proyecto Backend en .NET 8 y Frontend en React

Este proyecto consiste en un backend en **.NET 8** que expone una API RESTful para manejar la gestión de personas (CRUD), y un frontend en **React** que interactúa con esta API para realizar operaciones de creación, lectura, actualización y eliminación de usuarios.

## Descripción

El **Backend** está desarrollado en **.NET 8** y proporciona una API para gestionar registros de personas, incluyendo su creación, visualización, actualización y eliminación.

El **Frontend** está desarrollado en **React** y se conecta al backend para interactuar con los usuarios, mostrando los datos de la API y permitiendo la manipulación de los mismos.

Además, se incluye un archivo **ScriptCreacionBDD** en la carpeta `Script BDD` para la creación de la base de datos y las inserciones iniciales de registros.

## Tecnologías Utilizadas

- **Backend**: .NET 8 (C#)
- **Frontend**: React
- **Base de Datos**: SQL Server
- **Herramientas**:
  - Axios para consumo de API en React
  - Visual Studio Code para desarrollo

## Instrucciones de Instalación

### Backend (.NET 8)

1. Clona el repositorio del backend:
   ```bash
   git clone https://github.com/tu-usuario/backend-repo.git
2. Abre el proyecto en Visual Studio o tu editor preferido.

3. Ejecuta el proyecto para iniciar el servidor en localhost.

4. La API estará disponible en https://localhost:7237/api/People.

Frontend (React)
Clona el repositorio del frontend:

bash
Copiar
Editar
git clone https://github.com/APDavila/RRHH_UDLA.git
Navega al directorio del frontend: recursos-humanos-frontend

bash
Copiar
Editar
cd recursos-humanos-frontend
Instala las dependencias:

bash
Copiar
Editar
npm install
Ejecuta el servidor de desarrollo:

bash
Copiar
Editar
npm start
El frontend estará disponible en http://localhost:3000.

ScriptCreacionBDD
Dentro de la carpeta Script BDD encontrarás el archivo ScriptCreacionBDD.sql, que contiene los scripts para la creación de la base de datos, las tablas y las inserciones iniciales de registros. Ejecútalo en tu servidor SQL para configurar la base de datos.

Estructura del Proyecto
bash
Copiar
Editar
/backend
  └── /src
      └── /Controllers
	  └── /Data.cs
      └── /Models
      └── /Migrations
      └── /Repositories.cs
	  └── /Services.cs
	  └── Program.cs
	  └── appsettings.json


/frontend
  └── /src
	  └── /assets
      └── /components
      └── /styles      
      └── App.js
  └── /public
  └── /node_modules
  └── package.json
