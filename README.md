# UniversitiesApiRest

**UniversitiesApiRest** API REST con **.NET** la arquitectura se basa en una estructura en capas.

## 🛠️ **Tecnologías Utilizadas**

- **C#**  
- **.NET Core / .NET 6**  
- **Entity Framework Core**  
- **SQL Server**  
- **ASP.NET Web API** 
---

## 📁 **Estructura del Proyecto**

```
UniversitiesApiRest-master/
│
├── UniversitiesApp.sln                          # Archivo de solución principal
│
├── UniversitiesApp.DistributedService.WebApi/   # Capa de presentación (API)
│   ├── Controllers/
│   │   └── UniversityController.cs              # Controlador principal para universidades
│   ├── Program.cs                               # Punto de entrada de la API
│   ├── appsettings.json                         # Configuración general de la API
│   └── appsettings.Development.json             # Configuración para entorno de desarrollo
│
├── UniversitiesApp.Domain.Models/               # Modelos de dominio
│   ├── UniversityModel.cs                       # Modelo para universidades
│   └── Validators/                              # Validadores de modelos
│       └── UniversityModelValidator.cs
│
├── UniversitiesApp.Infrastructure.Contracts/    # Interfaces para el acceso a datos
│   └── IUniversityRepository.cs                 # Interfaz del repositorio de universidades
│
├── UniversitiesApp.Infrastructure.Impl/         # Implementación del acceso a datos
│   ├── UniversityRepository.cs                  # Implementación del repositorio
│   └── DbContexts/
│       └── UniversityDBContext.cs               # Contexto de base de datos con Entity Framework
│
├── UniversitiesApp.Library.Contracts/           # Interfaces y DTOs de servicios
│   └── DTOs/
│       └── UniversityMigrationDto.cs            # DTO para migraciones de universidades
│
└── UniversitiesApp.Library.Impl/                # Implementación de servicios
    └── UniversityService.cs                     # Lógica de negocio para universidades
```
