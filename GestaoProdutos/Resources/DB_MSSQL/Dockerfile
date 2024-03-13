# Utiliza a imagem oficial do SQL Server na Docker Hub
FROM mcr.microsoft.com/mssql/server:2019-latest

# Variáveis de ambiente
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=171228
ENV MSSQL_PID=Express
ENV DB_NAME=filmesDB

# Exporta a porta 1433
EXPOSE 1433

# Configura o SQL Server para aceitar conexões remotas
ENV MSSQL_TCP_PORT=1433
ENV MSSQL_BIND_ADDRESS=0.0.0.0

# Cria diretório para scripts SQL
WORKDIR /scripts

# Copia o script SQL para o contêiner
COPY ./setup.sql /scripts/setup.sql

# Roda o script SQL ao iniciar o contêiner
CMD /bin/bash -c '/opt/mssql/bin/sqlservr & /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d master -i /scripts/setup.sql'

# Nota: Este script SQL deve conter os comandos para criar o banco de dados e a tabela de filmes
