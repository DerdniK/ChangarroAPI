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
| **GET** | `/` | Obtener catálogo completo | `200 OK` con la lista de productos en formato JSON. |
| **GET** | `/{id}` | Obtener producto por ID | `200 OK` con el detalle o `404 Not Found` si no existe. |
| **POST** | `/` | Crear nuevo producto | `201 Created` con el objeto generado (el `Id` es autogenerado por MongoDB). |
| **PUT** | `/{id}` | Actualizar producto existente | `204 No Content` tras la mutación exitosa o `400 Bad Request`. |
| **DELETE** | `/{id}` | Eliminar producto | `204 No Content` tras el borrado o `404 Not Found`. |

## 4. Control de Excepciones y Reglas de Negocio

El sistema cuenta con validaciones nativas y capas de abstracción para mitigar fallas en tiempo de ejecución:

* **Validación de Claves Duplicadas (Error 11000):** La API intercepta las excepciones de escritura de datos (`MongoWriteException`). Se restringe el envío manual de identificadores (`_id`) en las peticiones de inserción (**POST**), delegando la instanciación de punteros únicos al motor de base de datos para garantizar la integridad referencial.
* **Manejo de Nulos:** Los métodos de búsqueda implementan tipos de referencia anulables (`Producto?`) para asegurar una transición limpia hacia respuestas HTTP estandarizadas en la capa del controlador.

## 5. Pruebas y Conectividad

### 5.1 Cadenas de conexión para los test

* **Interfaz Scalar (Documentación interactiva):** [http://localhost:5253/scalar/v1](https://www.google.com/search?q=http://localhost:5253/scalar/v1)
* **Endpoint para inserciones (POST):** [http://localhost:5253/api/v1/products/](https://www.google.com/search?q=http://localhost:5253/api/v1/products/)
* **Endpoint de consulta por ID (GET):** [http://localhost:5253/api/v1/products/54495ad94c934721ede76d90](https://www.google.com/search?q=http://localhost:5253/api/v1/products/54495ad94c934721ede76d90)

### 5.2 Estructura de datos para inserción (Payload JSON)

Para registrar un nuevo elemento en la base de datos a través del endpoint de inserción, se debe enviar la petición con el método **POST** configurando el cuerpo (Body) en formato `application/json` con la siguiente estructura:

```json
{
  "title": "Evangelion",
  "imageId": "54495ad94c934721ede76d90",
  "type": "Poster",
  "category": "Anime",
  "price": 80,
  "stock": 2
}

```

### 5.3 Datos de validación de errores

* **ID de referencia:** `54495ad94c934721ede76d90`
* **Comportamiento esperado:** Al realizar una petición `GET` con este identificador, el sistema debe retornar un código de estado `404 Not Found`, dado que el objeto no reside actualmente en la base de datos y sirve para validar el correcto aislamiento de excepciones de búsqueda. Intentar forzar manualmente este valor en el campo identificador durante un proceso de inserción provocará un error por duplicidad de llaves.

## 6. Alcance Futuro

* **Gestión de Inventarios:** Alertas de stock bajo para insumos de impresión.
* **Motor de Cotizaciones:** Cálculo dinámico de costos según material y dimensiones.
* **Trazabilidad de Pedidos:** Seguimiento de estados desde preprensa hasta entrega.
* **Integración GridFS:** Almacenamiento centralizado de archivos de diseño de alta resolución.

## 7. Instrucciones de Implementación

1. **Requisitos:** .NET 9 SDK y MongoDB Server de forma local (Puerto 27017) o instancia en la nube.
2. **Despliegue:** Ejecutar `dotnet run` desde el directorio raíz.
3. **Validación:** Acceder a la ruta de Scalar para verificar la disponibilidad de los servicios.

---

**Fecha de última actualización:** 19 de mayo de 2026.