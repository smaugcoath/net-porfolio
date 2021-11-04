#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DomainDrivenDesign.Example.Web.Api/DomainDrivenDesign.Example.Presentation.Web.Api.csproj", "DomainDrivenDesign.Example.Web.Api/"]
COPY ["DomainDrivenDesign.Example.Business/DomainDrivenDesign.Example.Application.csproj", "DomainDrivenDesign.Example.Business/"]
COPY ["DomainDrivenDesign.Example.Domain/DomainDrivenDesign.Example.Domain.csproj", "DomainDrivenDesign.Example.Domain/"]
RUN dotnet restore "DomainDrivenDesign.Example.Web.Api/DomainDrivenDesign.Example.Presentation.Web.Api.csproj"
COPY . .
WORKDIR "/src/DomainDrivenDesign.Example.Web.Api"
RUN dotnet build "DomainDrivenDesign.Example.Presentation.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DomainDrivenDesign.Example.Presentation.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DomainDrivenDesign.Example.Presentation.Web.Api.dll"]
