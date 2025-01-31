# Use a imagem base do .NET SDK para compilar o código
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Defina o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copie o arquivo de solução e restaure as dependências
COPY *.sln ./
COPY src/**/*.csproj ./src/
RUN dotnet restore

# Copie o restante do código do projeto
COPY . ./

# Compile o projeto
RUN dotnet publish -c Release -o /app/out

# Use uma imagem de runtime para a execução do aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

WORKDIR /app

# Copie o aplicativo compilado da etapa anterior
COPY --from=build /app/out .

# Exponha a porta onde o serviço irá rodar
EXPOSE 80

# Defina o comando para iniciar o aplicativo
ENTRYPOINT ["dotnet", "Tourmine.Tournament.API.dll"]
