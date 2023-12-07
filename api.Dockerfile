FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /api

RUN ls -l
# Copy everything
COPY ./ ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /api
COPY --from=build-env /api/out .
ENTRYPOINT ["/api/api"]

