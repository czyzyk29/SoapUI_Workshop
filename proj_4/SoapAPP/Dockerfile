FROM mcr.microsoft.com/dotnet/core/runtime:2.2
COPY ProductAPI/bin/Release/netcoreapp2.2/publish/ ProductAPI/

ENTRYPOINT ["dotnet", "ProductAPI/ProductAPI.dll"]