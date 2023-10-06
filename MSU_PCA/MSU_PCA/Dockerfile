FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MSU_PCA.csproj", "./"]
RUN dotnet restore "MSU_PCA.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "MSU_PCA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MSU_PCA.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MSU_PCA.dll"]
