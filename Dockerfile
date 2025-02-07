# Use a imagem base do .NET SDK para compilar o código
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Defina o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copie o arquivo de solução
COPY Tourmine.Tournament.Service.sln ./

# Copie todos os arquivos .csproj dos projetos
COPY src/Application/Tourmine.Tournament.Application/Tourmine.Tournament.Application.csproj ./src/Application/Tourmine.Tournament.Application/
COPY src/Domain/Tourmine.Tournament.Domain/Tourmine.Tournament.Domain.csproj ./src/Domain/Tourmine.Tournament.Domain/
COPY src/Infrastructure/Tourmine.Tournament.Infrastructure/Tourmine.Tournament.Infrastructure.csproj ./src/Infrastructure/Tourmine.Tournament.Infrastructure/
COPY src/WebAPI/Tourmine.Tournament.API/Tourmine.Tournament.API.csproj ./src/WebAPI/Tourmine.Tournament.API/

# Restaure as dependências
RUN dotnet restore

# Copie o restante do código do projeto
COPY src ./src

# Compile o projeto
RUN dotnet publish -c Release -o /app/out

# Use uma imagem de runtime para a execução do aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

WORKDIR /app

# Copie o aplicativo compilado da etapa anterior
COPY --from=build /app/out .

# Exponha a porta onde o serviço irá rodar
EXPOSE 8080

# Defina o comando para iniciar o aplicativo
ENTRYPOINT ["dotnet", "Tourmine.Tournament.API.dll"]
