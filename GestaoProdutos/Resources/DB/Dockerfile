# Use a imagem oficial do MySQL
FROM mysql:latest

# Defina as variáveis de ambiente
ENV MYSQL_ROOT_PASSWORD=171228
ENV MYSQL_DATABASE=filmedb
ENV MYSQL_USER=filme_user
ENV MYSQL_PASSWORD=171228

# Copie o script de inicialização para o diretório de inicialização do MySQL
COPY init.sql /docker-entrypoint-initdb.d/

# Exponha a porta padrão do MySQL
EXPOSE 3306
