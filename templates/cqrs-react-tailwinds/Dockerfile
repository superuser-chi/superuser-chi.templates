FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app
# Copy csproj and restore as distinct layers
COPY *.sln .
COPY Domain/*.csproj ./Domain/
COPY Persistence/*.csproj ./Persistence/
COPY Application/*.csproj ./Application/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY WebUI/*.csproj ./WebUI/

RUN dotnet restore

# Install npm
RUN apt-get update
RUN apt-get -y install curl gnupg
RUN curl -sL https://deb.nodesource.com/setup_12.x  | bash -
RUN apt-get -y install nodejs

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENV SeedUserPW=Test@123
CMD ["dotnet", "WebUI.dll"]