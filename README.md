# Pre-requisitos
## Instalar

- docker
https://hub.docker.com/editions/community/docker-ce-desktop-windows/

- workbench (mysql)
https://dev.mysql.com/downloads/file/?id=500617

# Subir imagens

- Na pasta "PatromonioAPI\docker-img" contém as imagens do docker para subir.

Nela teremos
- Docker para mysql
- Docker para redis
- Docker para rabbit (adicional)

**comando para subir os container:

docker-componse up (na pasta das configurações do container)

**OBS: para login e senha consultar o arquivo de config do projeto / docker-compose.yml

# Inicializar Swagger
- http://localhost:5000/swagger/index.html
