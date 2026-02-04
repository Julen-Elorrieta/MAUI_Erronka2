# MAUI_Erronka2

Aplicación multiplataforma para la gestión y consulta de centros educativos, desarrollada con .NET 8, .NET MAUI y Blazor.

Repositorio: [https://github.com/Julen-Elorrieta/MAUI_Erronka2](https://github.com/Julen-Elorrieta/MAUI_Erronka2)

---

## Tabla de contenidos

- [Descripción](#descripción)
- [Características](#características)
- [Tecnologías utilizadas](#tecnologías-utilizadas)
- [Estructura del proyecto](#estructura-del-proyecto)
- [Requisitos previos](#requisitos-previos)
- [Instalación y ejecución](#instalación-y-ejecución)
- [Configuración de la localización](#configuración-de-la-localización)
- [Configuración de la API meteorológica](#configuración-de-la-api-meteorológica)
- [Personalización](#personalización)
- [Licencia](#licencia)

---

## Descripción

**MAUI_Erronka2** es una aplicación multiplataforma que permite gestionar y consultar información de centros educativos. Incluye funcionalidades de listado, filtrado, edición y visualización de detalles de cada centro, así como integración con mapas y previsión meteorológica.

---

## Características

- Visualización de la lista de centros educativos con filtros por tipo, territorio y municipio.
- Búsqueda por nombre, dirección o municipio.
- Paginación de resultados.
- Formulario para crear y editar centros.
- Visualización detallada de cada centro, incluyendo:
  - Mapa interactivo con ubicación.
  - Información de contacto.
  - Previsión meteorológica actual y a 5 días (OpenWeather).
- Localización multilingüe mediante archivos `.resx`.
- Interfaz moderna y adaptable con Bootstrap.

---

## Tecnologías utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- [.NET MAUI](https://learn.microsoft.com/dotnet/maui/)
- [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
- [Bootstrap 5](https://getbootstrap.com/)
- [OpenWeather API](https://openweathermap.org/api)

---

## Estructura del proyecto

MAUI_Erronka2/
├── Components/
│   ├── Pages/            # Componentes de página Blazor (listas, formularios, detalles)
│   ├── Model/            # Modelos de datos (por ejemplo, Centro)
│   └── Shared/           # Componentes compartidos (menús, layouts, etc.)
├── Services/             # Servicios para acceso a datos y lógica de negocio
├── Resources/            # Archivos de recursos .resx para localización y textos
├── wwwroot/              # Recursos estáticos (CSS, JS, imágenes)
├── MauiProgram.cs        # Configuración principal de la app MAUI
├── App.xaml              # Configuración global de la app
├── App.razor             # Componente raíz de la app Blazor
├── MainPage.xaml         # Página principal de la app MAUI
└── README.md             # Documentación del proyecto

---

## Requisitos previos

- [Visual Studio 2022](https://visualstudio.microsoft.com/) con soporte para .NET MAUI y Blazor.
- .NET 8 SDK instalado.
- Acceso a una API backend (configurable en `MauiProgram.cs`).
- Clave de API de [OpenWeather](https://openweathermap.org/api) para la previsión meteorológica.

---

## Instalación y ejecución

1. **Clona el repositorio:**


2. **Configura la URL del backend:**

   - Abre `MauiProgram.cs` y ajusta la variable `backendUrl` si es necesario.

3. **Configura la clave de OpenWeather:**

   - Abre `Components/Pages/Center.razor`.
   - Sustituye el valor de `apiKey` en el método `CargarDatosMeteorologicosAsync` por tu propia clave de OpenWeather.

4. **Abre el proyecto en Visual Studio 2022.**

5. **Selecciona la plataforma de destino** (Android, Windows, etc.) y ejecuta la aplicación.

---

## Configuración de la localización

- Los textos de la interfaz están gestionados mediante archivos `.resx` en la carpeta `Resources`.
- El idioma predeterminado es español (`es-ES`). Puedes cambiarlo en el arranque de la app (`MauiProgram.cs`).
- Para añadir un nuevo idioma:
  1. Crea un archivo de recursos con el sufijo del idioma, por ejemplo: `Strings.fr.resx` para francés.
  2. Añade las traducciones correspondientes.
  3. La aplicación seleccionará automáticamente el idioma según la cultura configurada.

---

## Configuración de la API meteorológica

- La previsión meteorológica se obtiene de [OpenWeather](https://openweathermap.org/api).
- Necesitas una clave de API gratuita o de pago.
- Sustituye la clave en el método `CargarDatosMeteorologicosAsync` de `Center.razor`:

  
---

## Personalización

- **Estilos:** Puedes modificar los estilos en `wwwroot/css` o directamente en los archivos `.razor`.
- **Campos de los centros:** Para añadir o quitar campos, edita el modelo `Centro` y los formularios en `Form.razor`.
- **Filtros y paginación:** Los filtros y la paginación se gestionan en `Centerlist.razor`.
- **Mapas:** La integración de mapas se realiza mediante JavaScript interoperable en el componente de detalle (`Center.razor`).

---

## Licencia

Este proyecto está bajo la licencia MIT. Puedes ver el archivo [LICENSE](LICENSE) para más detalles.

---
   