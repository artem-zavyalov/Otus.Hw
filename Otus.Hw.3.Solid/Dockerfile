FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Otus.Hw.3.Solid/Otus.Hw.3.Solid.csproj", "Otus.Hw.3.Solid/"]
RUN dotnet restore "Otus.Hw.3.Solid/Otus.Hw.3.Solid.csproj"
COPY . .
WORKDIR "/src/Otus.Hw.3.Solid"
RUN dotnet build "Otus.Hw.3.Solid.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Otus.Hw.3.Solid.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Otus.Hw.3.Solid.dll"]
