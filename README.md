## Iniciativa de Dotnetgroup 😁
Proyecto para aprender :)

Este proyecto se hace con el fin de especializarnos
y conocer más a fondo la tecnología .net si quieres
interactuar con los integrantes o bien formar parte
del equipo y conocer todas las partes del proceso
de desarrollo de software únete a nuestro grupo de
Telegram

https://t.me/dotnetdevspanish

### Objetivo del proyecto 📌
---
El objetivo de este proyecto es que el usuario cuente con un espacio donde vender sus productos, hacer sus promociones y promover los servicios que este ofrece para que otras personas puedan consumirlos. Estamos hablando de un Marketplace, con tiendas diferentes las cuales se gestionan de forma independiente por cada dueño de la tienda y los empleados que esta tenga


### Arquitectura 🧱
---
El sistema contará con un arquitectura de microservicios, y seguiremos dentro de cada microservicios un patrón DDD. Dentro de las ventajas que ofrece esta arquitectura se encuentra el aislamiento que presenta del resto de componentes del sistema, ya que cada microservicio es en entorno aislado, independiente y escalable. Como desventaja encontramos que es un poco complejo de diseñar pero no imposible :) y siguiendo una correcta guía puedes ver la belleza de esta arquitectura.

La arquitectura de microservicios si bien no es necesario Docker para su implementación y despliegue, alcanza su verdadero potencial usando esta tecnología. 

Como recomendación te dejamos el e-book correspondiente a la bibliografía 1, el cual me fue de mucha ayuda para aprender Docker y esta arquitecura

Dentro de los microservicios detectados están
- Microservicio de autenticación y usuarios
- Microservicio de Tiendas
- Microservicio de integración a pasarelas de pago
- Microservicio de Blog

### Metodología de desarrollo ⚙️
---
Escoger la metodología de trabajo es uno de los pasos más importantes en la etapa inicial de desarrollo. Nosotros escogimos SCRUM, el cual acompañamos con tarjetas de historias de usuario, para elaborar estas historias de usuario y hacer un tablero de SCRUM usamos la herramienta https://miro.com, SRUM provee de una alta flexibilidad a los cambios que se puedan presentar.

### Construido con 🛠️
---
- .Net 5
- PostgreSQL
- MongoDb
- Entity Framework Core
- Docker

### Documentación y videos 📚
---
A medida que vaya avanzando el desarrollo toda la bibliografía y videos para la implementación del sistema se irá poniendo aquí
1) https://raw.githubusercontent.com/dotnet-architecture/eBooks/main/current/microservices/NET-Microservices-Architecture-for-Containerized-NET-Applications.pdf
2) https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&cad=rja&uact=8&ved=2ahUKEwjK69zsn-LzAhV7QjABHUyyB-oQFnoECAIQAQ&url=https%3A%2F%2Foa.upm.es%2F54274%2F1%2FTFG_CARLOS_JIMENEZ_ALIAGA.pdf&usg=AOvVaw2Acx-FQ4-livoHX4BSiKbY
3) https://docs.microsoft.com/es-es/aspnet/core/test/integration-tests?view=aspnetcore-5.0
