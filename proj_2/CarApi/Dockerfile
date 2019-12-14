FROM mcr.microsoft.com/dotnet/core/runtime:2.2
#mcr.microsoft.com/dotnet/core/aspnet:2.2

#mcr.microsoft.com/dotnet/core/sdk:2.2
#COPY CarApi/bin/Debug/netcoreapp2.2/ CarApi/

ENTRYPOINT ["dotnet", "CarApi/CarApi.dll"]



FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app
# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "CarApi.dll"]