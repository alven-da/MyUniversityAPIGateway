FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY MyUniversityAPIGateway.csproj src/
RUN dotnet restore "src/MyUniversityAPIGateway.csproj"

COPY . .

RUN dotnet build "MyUniversityAPIGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyUniversityAPIGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyUniversityAPIGateway.dll"]