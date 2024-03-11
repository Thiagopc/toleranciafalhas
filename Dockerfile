# Usando a imagem oficial do SDK do .NET Core como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Definindo o diret�rio de trabalho dentro do cont�iner
WORKDIR /app

# Copiando todo o c�digo-fonte para o cont�iner
COPY . .

# Definindo o diret�rio de trabalho para dentro do projeto ToleranciaFalhas.api
WORKDIR /app/ToleranciaFalhas.api

# Restaurando as depend�ncias do projeto
RUN dotnet restore

# Compilando o aplicativo
RUN dotnet publish -c Release -o out

# Est�gio de implanta��o
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/ToleranciaFalhas.api/out .

# Expondo a porta em que o aplicativo estar� ouvindo
EXPOSE 80

# Comando para iniciar o aplicativo quando o cont�iner for iniciado
ENTRYPOINT ["dotnet", "ToleranciaFalhas.api.dll"]
