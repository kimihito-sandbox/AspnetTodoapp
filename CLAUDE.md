# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is an ASP.NET Core MVC web application targeting .NET 10.0. It follows the standard MVC pattern with Controllers, Views, and Models.

## Build and Run Commands

### Development
```bash
# Build the project
dotnet build

# Run the application (development mode with hot reload)
dotnet run

# Run with specific profile
dotnet run --launch-profile https  # HTTPS on port 7134
dotnet run --launch-profile http   # HTTP on port 5280

# Watch mode for development (auto-restart on file changes)
dotnet watch run
```

### Testing
Currently no test projects exist in this solution.

## Architecture

### Project Structure

- **Program.cs**: Application entry point and service configuration. Uses minimal hosting model with WebApplicationBuilder
- **Controllers/**: MVC controllers handling HTTP requests
  - `HomeController.cs`: Main controller with Index, Privacy, and Error actions
- **Models/**: Data models and view models
  - `ErrorViewModel.cs`: Model for error display pages
- **Views/**: Razor view templates following MVC conventions
  - `Views/Home/`: Views for HomeController actions
  - `Views/Shared/`: Shared layouts and partials (_Layout.cshtml, Error.cshtml, _ValidationScriptsPartial.cshtml)
  - `_ViewStart.cshtml`: Sets default layout for all views
  - `_ViewImports.cshtml`: Imports namespaces and tag helpers globally
- **wwwroot/**: Static files (CSS, JavaScript, images, client libraries)
- **Properties/launchSettings.json**: Development server configuration

### Key Configuration

- **Target Framework**: .NET 10.0
- **Nullable Reference Types**: Enabled
- **Implicit Usings**: Enabled
- **Development URLs**:
  - HTTPS: https://localhost:7134
  - HTTP: http://localhost:5280

### Routing

The application uses attribute routing with a custom route on HomeController.Index (`[Route("/")]`). Other routes follow convention-based routing patterns. The app uses `MapControllers().WithStaticAssets()` instead of the traditional `MapControllerRoute` pattern.

### Middleware Pipeline

Standard ASP.NET Core middleware pipeline (in order):
1. Exception handling (UseExceptionHandler in production, developer exception page in dev)
2. HSTS (production only)
3. HTTPS redirection
4. Routing
5. Authorization
6. Static assets mapping
7. Controller endpoint mapping with static assets

### View Conventions

- All views use `_Layout.cshtml` as the default layout (configured in `_ViewStart.cshtml`)
- Tag Helpers are enabled globally via `_ViewImports.cshtml`
- Bootstrap 5 and jQuery are included via client-side libraries in wwwroot/lib
