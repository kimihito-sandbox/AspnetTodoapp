# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is an ASP.NET Core MVC web application targeting .NET 10.0 with Vite and Tailwind CSS integration. It combines traditional server-side MVC with modern frontend tooling for fast development and optimized production builds.

## Build and Run Commands

### Development
```bash
# Recommended: Run .NET with auto-restart (Vite starts automatically via appsettings.Development.json)
dotnet watch run

# Alternative: Run .NET and Vite separately
dotnet run                    # Backend server
npm run dev                   # Vite dev server (separate terminal)

# Run with specific profile
dotnet run --launch-profile https  # HTTPS on port 7134
dotnet run --launch-profile http   # HTTP on port 5280

# Build .NET project
dotnet build
```

### Frontend Build
```bash
# Install npm dependencies
npm install

# Development mode with HMR
npm run dev

# Production build (outputs to wwwroot/)
npm run build
```

### Testing
Currently no test projects exist in this solution.

## Architecture

### Project Structure

- **Program.cs**: Application entry point with Vite integration
  - Configures `AddViteServices()` for Vite middleware
  - Uses `UseViteDevelopmentServer()` in development mode
  - Enables `MapControllers().WithStaticAssets()` for attribute routing
- **Controllers/**: MVC controllers with attribute routing
  - `HomeController.cs`: Uses `[Route("/")]` on Index action
- **Models/**: Data models and view models
- **Views/**: Razor view templates
  - `_ViewImports.cshtml`: Imports `Vite.AspNetCore.TagHelpers` for Vite tag helpers
  - `_Layout.cshtml`: Uses `<script type="importmap">`, `<link rel="stylesheet" href="~/@vite/client">`, and `<script type="module" src="~/@vite/main.js">`
- **Assets/**: Frontend source files (processed by Vite)
  - `main.js`: JavaScript entry point (imports main.css)
  - `main.css`: Tailwind CSS entry point
- **wwwroot/**: Build output directory for Vite assets
- **vite.config.js**: Vite configuration
  - Root: `./Assets`
  - Output: `../wwwroot`
  - Entry: `./Assets/main.js`
  - Tailwind CSS plugin enabled

### Key Configuration

- **Target Framework**: .NET 10.0
- **Nullable Reference Types**: Enabled
- **Implicit Usings**: Enabled
- **NuGet Packages**: `Vite.AspNetCore` (v2.4.1)
- **npm Dependencies**: Vite 7.2, Tailwind CSS 4.1
- **Development URLs**:
  - HTTPS: https://localhost:7134
  - HTTP: http://localhost:5280
- **Vite Auto-Run**: Enabled in `appsettings.Development.json` (AutoRun: true)

### Routing

The application uses attribute routing with a custom route on HomeController.Index (`[Route("/")]`). Other routes follow convention-based routing patterns. The app uses `MapControllers().WithStaticAssets()` instead of the traditional `MapControllerRoute` pattern.

### Middleware Pipeline

ASP.NET Core middleware pipeline with Vite integration (in order):
1. **Vite Development Server** (development only, before exception handling)
2. Exception handling (UseExceptionHandler in production, developer exception page in dev)
3. HSTS (production only)
4. HTTPS redirection
5. Routing
6. Authorization
7. Static assets mapping
8. Controller endpoint mapping with static assets

**Important**: `UseViteDevelopmentServer()` must be called early in the pipeline (after builder.Build() but before other middleware) to proxy Vite's dev server requests.

### Vite Integration Architecture

The application uses a dual-mode approach for frontend assets:

**Development Mode**:
- Vite dev server runs automatically when `dotnet watch run` is executed (via `appsettings.Development.json`)
- Vite serves files from `Assets/` directory with HMR enabled
- `UseViteDevelopmentServer()` proxies requests to Vite's dev server
- Tag helpers in `_Layout.cshtml` reference Vite dev server URLs (`~/@vite/client`, `~/@vite/main.js`)

**Production Mode**:
- Run `npm run build` to compile assets
- Vite outputs bundled files to `wwwroot/` with manifest
- ASP.NET Core serves static files directly from `wwwroot/`
- Tag helpers automatically switch to bundled asset references

**Key Integration Points**:
- `Program.cs`: `AddViteServices()` and `UseViteDevelopmentServer()`
- `_ViewImports.cshtml`: `@addTagHelper *, Vite.AspNetCore`
- `_Layout.cshtml`: Vite-specific script and link tags
- `vite.config.js`: Build configuration with manifest generation

### Frontend Stack

- **Tailwind CSS 4.1**: Utility-first CSS framework
  - Entry point: `Assets/main.css` with `@import "tailwindcss"`
  - Plugin configured in `vite.config.js`
- **Vite 7.2**: Fast build tool with HMR
  - Custom app type for ASP.NET Core integration
  - ES modules with import maps support

### View Conventions

- All views use `_Layout.cshtml` as the default layout (configured in `_ViewStart.cshtml`)
- Tag Helpers are enabled globally via `_ViewImports.cshtml`
- Vite tag helpers handle asset references in development and production

## AI Assistant Instructions

This is a learning project for studying ASP.NET Core. When the user asks for code changes:

1. **Show the code, don't write it** - Provide code snippets for the user to type themselves (写経 style)
2. **Explain what each part does** - Help the user understand the concepts
3. **Answer questions patiently** - The user is learning, so explain terminology and patterns
4. **Suggest next steps** - Guide the learning process incrementally
