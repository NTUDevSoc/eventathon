FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DevSoc.Eventathon/DevSoc.Eventathon.csproj", "DevSoc.Eventathon/"]
RUN dotnet restore "DevSoc.Eventathon/DevSoc.Eventathon.csproj"
COPY . .
WORKDIR "/src/DevSoc.Eventathon"
RUN dotnet build "DevSoc.Eventathon.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevSoc.Eventathon.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevSoc.Eventathon.dll"]
