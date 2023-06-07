#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MinhasFinancas.Api/ControleFinancasComercio.Api.csproj", "MinhasFinancas.Api/"]
COPY ["MinhasFinancas.CrossCutting.Ioc/MinhasFinancas.CrossCutting.Ioc.csproj", "MinhasFinancas.CrossCutting.Ioc/"]
COPY ["MinhasFinancas.Application/MinhasFinancas.Application.csproj", "MinhasFinancas.Application/"]
COPY ["MinhasFinancas.Domain/MinhasFinancas.Domain.csproj", "MinhasFinancas.Domain/"]
COPY ["MinhasFinancas.Domain.Core/MinhasFinancas.Domain.Core.csproj", "MinhasFinancas.Domain.Core/"]
COPY ["MinhasFinancas.ViewModel/MinhasFinancas.ViewModel.csproj", "MinhasFinancas.ViewModel/"]
COPY ["MinhasFinancas.CrossCutting.Bus/MinhasFinancas.CrossCutting.Bus.csproj", "MinhasFinancas.CrossCutting.Bus/"]
COPY ["MinhasFinancas.Infra/MinhasFinancas.Infra.csproj", "MinhasFinancas.Infra/"]
RUN dotnet restore "MinhasFinancas.Api/ControleFinancasComercio.Api.csproj"
COPY . .
WORKDIR "/src/MinhasFinancas.Api"
RUN dotnet build "ControleFinancasComercio.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ControleFinancasComercio.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControleFinancasComercio.Api.dll"]