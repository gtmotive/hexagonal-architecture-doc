Se utiliza el SDK 6.0.417

Se crea un web APi con dos controladores, Vehicle y Rent

Se crean los tipicos métodos de consulta tipo GetAll y GetById y los especificos que se solicitan en el ejecicios.

Las clases se injectan en la clase GtMotive.Estimate.Microservice.Api.DependencyInjection.InjectionExtensions

La logica de negocio se encuentra en el proyecto GtMotive.Estimate.Microservice.Api y la regla de acceso a datos en GtMotive.Estimate.Microservice.Infrastructure

Las estructuras de datos se crean en tres capas. Request y Response en el proyecto Host. Las clases Api en el proyecto de Business y las clases de acceso a datos en Domain. La conexión entre clases se mapean usando la libreria AutoMapper. 
Por ejemplo : 
RequestRentDto => RentAPI => Rent
Rent => RentAPI => ResponseRentDto

Para la clase de acceso a datos se utilizan un modelo de ficheros de texto en formato Json definidos en el AppSettings.json en la entrada "FileSystemSettings"
Se podría segregar este proyecto en varios modelos de acceso a datos. Por ejemplo : Base de datos relacionales, MongoDb, Redis, etc.
Este último modelos Redis sería muy util para cachear información y aumentar la performance de la aplicación.

Se crean test unitarios con un ejemplo de Mock para la conexión a la capa de datos y un test funcional.

Los controllers no tiene habilitada autentificación. Se podría agregar una autentificación mediante JWT. Esta preparado el fichero de coniguración para utilizar el middleware 
JwtAuthority https://identity.mygtmotive.com






