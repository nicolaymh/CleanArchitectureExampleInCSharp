# CleanArchitectureExampleInCSharp

Este repositorio contiene un ejemplo de implementación de arquitectura limpia en C# con una Web API. El objetivo principal de este proyecto es proporcionar una base educativa para aprender sobre arquitectura limpia y el uso de DTOs en una aplicación simple. Los datos se inicializan en una lista dentro del repositorio para simplificar el enfoque y no se utiliza asincronía.

## Tabla de Contenidos

- [Descripción](#descripción)
- [Características](#características)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Requisitos Previos](#requisitos-previos)
- [Configuración del Proyecto](#configuración-del-proyecto)
- [Uso](#uso)

## Descripción

Este proyecto es una demostración educativa de cómo implementar la arquitectura limpia en una aplicación Web API usando C#. La aplicación permite realizar operaciones CRUD sobre productos utilizando una lista de productos inicializada en el repositorio para simplificar el manejo de datos. No se utiliza asincronía en este ejemplo para mantener el enfoque en los conceptos de arquitectura limpia y el uso de DTOs.

## Características

- Arquitectura en capas siguiendo los principios de Clean Architecture.
- DTOs para la transferencia de datos.
- Servicios de dominio para encapsular la lógica de negocio.
- Repositorios con datos inicializados en una lista.
- Inyección de dependencias con .NET Core.
- Documentación de la API con Swagger.
- Validación de datos.

## Estructura del Proyecto

```plaintext
/Solution
  /WebApi
    /Controllers
      ProductoController.cs
    Program.cs
  /Dominio
    /Entidades
      Producto.cs
    /Servicios
      /Interfaces
        IProductoService.cs
      ProductoService.cs
  /AccesoDatos
    /Repositorios
      ProductoRepository.cs
  /DTOs
    ProductoDTO.cs
```

## Requisitos Previos

- .NET 6.0 o superior
- Visual Studio 2022 o Visual Studio Code
- Git

## Configuración del Proyecto

### 1. Clonar el Repositorio

- Presiona F5 en Visual Studio para compilar y ejecutar la aplicación.

### 2. Restaurar Paquetes NuGet

- En Visual Studio, ve a Herramientas > Administrador de paquetes NuGet > Administrar paquetes NuGet para la solución... y restaura los paquetes necesarios.

## Uso

### 1. Ejecutar la Aplicación

- Presiona F5 en Visual Studio para compilar y ejecutar la aplicación.

### 2. Explorar la API con Swagger

- Abre tu navegador web y navega a https://localhost:<puerto>/swagger para ver y probar los endpoints de la API.