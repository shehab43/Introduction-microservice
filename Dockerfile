# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

# Copy and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the entire project and publish it
COPY . . 
RUN dotnet publish -c Release -o out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /appdocker ps -a


# Copy the published files from the build stage
COPY --from=build-env /app/out .

# Define the entry point for the application
ENTRYPOINT ["dotnet", "platFormService.dll"]
