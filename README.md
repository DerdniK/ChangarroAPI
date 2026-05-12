# Documentación Técnica: ChangarroAPI

## 1. Descripción del Proyecto

**ChangarroAPI** es una solución de backend desarrollada bajo el ecosistema **.NET 9**, diseñada para la gestión integral y automatización de procesos operativos en empresas de servicios de impresión y manufactura de artículos personalizados. El sistema actúa como una capa intermedia (Middleware) que centraliza la lógica de negocio, el control de inventarios y la gestión de activos digitales.

## 2. Arquitectura del Sistema

El proyecto implementa una arquitectura multicapa basada en los siguientes patrones de diseño:

* **Repository Pattern:** Desacopla la lógica de acceso a datos del resto de la aplicación, facilitando el mantenimiento y permitiendo la migración entre motores de base de datos.
* **Service Layer:** Centraliza las reglas de negocio y validaciones, asegurando que los controladores se limiten a la gestión de peticiones HTTP.
* **Dependency Injection (DI):** Utilizada para la gestión de ciclos de vida de objetos y la inyectabilidad de servicios y clientes de base de datos.

## 3. Especificación de Endpoints (CRUD)

La API expone los siguientes puntos de acceso para la entidad de productos bajo el prefijo de ruta `/api/v1/products`:

| Método | Endpoint | Descripción | Resultado Esperado |
| --- | --- | --- | --- |
| **GET** | `/` | Obtener catálogo completo | `200 OK` con lista de productos. |
| **GET** | `/{id}` | Obtener producto por ID | `200 OK` o `404 Not Found`. |
| **POST** | `/` | Crear nuevo producto | `201 Created` con el objeto generado. |
| **PUT** | `/{id}` | Actualizar producto existente | `204 No Content` o `400 Bad Request`. |
| **DELETE** | `/{id}` | Eliminar producto | `204 No Content` o `404 Not Found`. |

## 4. Pruebas y Conectividad

### 4.1 Cadena de conexión para los test

* **Interfaz Scalar (Documentación interactiva):** [http://localhost:5253/scalar/v1](https://www.google.com/search?q=http://localhost:5253/scalar/v1)
* **Endpoint de prueba (Postman/cURL):** [http://localhost:5253/api/v1/products/54495ad94c934721ede76d90](https://www.google.com/search?q=http://localhost:5253/api/v1/products/54495ad94c934721ede76d90)

### 4.2 Datos de prueba

* **ID de referencia:** `54495ad94c934721ede76d90`
* **Comportamiento esperado:** Al realizar una petición `GET` con este identificador, el sistema debe retornar un código de estado `404 Not Found`, dado que el objeto no reside actualmente en la base de datos y sirve para validar el manejo de excepciones de búsqueda.

## 5. Alcance Futuro

* **Gestión de Inventarios:** Alertas de stock bajo para insumos de impresión.
* **Motor de Cotizaciones:** Cálculo dinámico de costos según material y dimensiones.
* **Trazabilidad de Pedidos:** Seguimiento de estados desde preprensa hasta entrega.
* **Integración GridFS:** Almacenamiento centralizado de archivos de diseño de alta resolución.

## 6. Instrucciones de Implementación

1. **Requisitos:** .NET 9 SDK y MongoDB Server (Puerto 27017).
2. **Despliegue:** Ejecutar `dotnet run` desde el directorio raíz.
3. **Validación:** Acceder a la ruta de Scalar para verificar la disponibilidad de los servicios.

---

**Fecha de última actualización:** 12 de mayo de 2026.