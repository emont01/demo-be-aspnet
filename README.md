# Comandos recomendados

1. Instalación de dependencias
`dotnet restore`

2. Compilación
`dotnet build`

3. Pruebas
`dotnet test`

4. Generación de reportes, necesitará instalar dotnet-coverage y [dotnet-reportgenerator-globaltool](https://reportgenerator.io/usage)
`dotnet coverage collect 'dotnet test --no-build' -f xml -s dotnet-coverage-settings.xml -o coverage.xml && dotnet tool run reportgenerator -reports:coverage.xml -targetdir:reports`

5. Levantar contenedores locales
`docker-compose up -d`
