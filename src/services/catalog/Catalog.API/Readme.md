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
