## Microservicio Catalog.API
![image](https://user-images.githubusercontent.com/11778651/137435235-fd9ddb97-7bd6-4323-8972-70635ffba0cd.png)

### Objetivo
---
- Tener un microservicio para utilizar con y sin docker.
- Poder comunicar api con base datos mongo.
- Configurar appsetting para configuracion de conexiones locales por fuera de docker.
- Configurar environments en docker-compose.override.yml para configuracion de conexion dentro de la red de docker.
- Exponer la API mediante Swagger

### Tecnologias Utlizadas
---
- Net Core 5.0
- MongoDB
- Docker
- MongoDriver DB
- Swagger
- Visual Studio 16.11.4

### Patrones Utilizados
---
- Repository Pattern

### Pasos para crear la API desde 0
---
No es necesario saber mongo en su totalidad para realizar esta API pero si conocimientos basicos de la base.

Lo primero y necesario para poder empezar es tener mongo instalado y ejecutando en la pc, Docker en este sentido nos facilita tener Mongo sin necesidad de instalarlo en nuestra PC
mediante un contenedor.   
   
Para ello es necesario tener instalado Docker. https://www.docker.com/get-started
Cuando se instala Docker en Windows lo recomendable es que los contenedores sean linux.

Una vez instalado docker deberemos instalar mongo, para ello nos dirigimos a powershell o consola de comandos y ejecutamos la siguiente instruccion docker   
```bash
docker run -d -p 27017:27017 --name Catalog.DB mongo
```

Esto generara un contenedor a partir de la imagen oficial de mongo como se muestra en la siguiente pantalla.

![image](https://user-images.githubusercontent.com/11778651/137431733-ac2b8a85-0a46-4287-abe3-76fe0e36cbed.png)

A partir de este momento ya tenemos instalado mongo y podemos conectarnos a la base mediante localhost:27017    

![image](https://user-images.githubusercontent.com/11778651/137432285-46d3b7b3-a6a4-4370-ac7d-af7450c5fc47.png) Atención: Esta base es temporal para poder desarrollar 
y probar momentaneamente fuera de docker, de a poco el microservicio se ira adaptando para que se pueda ejecutar dentro y fuera del contenedor junto con la base de datos.

### Crear Catalog.API
---
- Para estructurar mejor la solucion cree las carpetas src/services/catalog para ubicar el microservicio Catalog.API
![image](https://user-images.githubusercontent.com/11778651/137435576-88d597dc-67cd-4dcb-b670-7abeecf18ecb.png)
- Creo un proyecto ASP.NET Core Web API siguiendo las siguientes instrucciones
![image](https://user-images.githubusercontent.com/11778651/137435707-1bed7f57-0fd3-4b53-b9d4-79ddf3de6105.png)   
![image](https://user-images.githubusercontent.com/11778651/137435658-c5353d83-6d81-49be-a289-5c432f9eb3c1.png)   
![image](https://user-images.githubusercontent.com/11778651/137435759-856310c9-0f35-4356-b451-d5f1a57087fa.png)   
- En este paso asegurarse en Location de agregar src\services\catalog, si no lo hace el proyecto no mantendra la estructura por fuera de la solucion.   
![image](https://user-images.githubusercontent.com/11778651/137435784-b22592a4-f985-4c83-b6ab-254b32f7890a.png)   
![image](https://user-images.githubusercontent.com/11778651/137435935-99e52b5f-6f2d-4312-869a-e895829c7a35.png)   
- Por ultimo eliminar el controlador y entidad por defecto   
![image](https://user-images.githubusercontent.com/11778651/137436022-8af922f1-6fc4-48fc-9a24-18e246a1e127.png)


