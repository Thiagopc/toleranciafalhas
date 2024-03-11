# Usando a imagem oficial do SDK do .NET Core como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Definindo o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copiando todo o código-fonte para o contêiner
COPY . .

# Definindo o diretório de trabalho para dentro do projeto ToleranciaFalhas.api
WORKDIR /app/ToleranciaFalhas.api

# Restaurando as dependências do projeto
RUN dotnet restore

# Compilando o aplicativo
RUN dotnet publish -c Release -o out

# Estágio de implantação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/ToleranciaFalhas.api/out .

# Expondo a porta em que o aplicativo estará ouvindo
EXPOSE 80

# Comando para iniciar o aplicativo quando o contêiner for iniciado
ENTRYPOINT ["dotnet", "ToleranciaFalhas.api.dll"]
