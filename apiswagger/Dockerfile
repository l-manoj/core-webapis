#Build Stage
FROM microsoft/aspnetcore-build:2 AS build-env

WORKDIR /apiswagger

COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -o /publish

#Runtime stage
FROM microsoft/aspnetcore:2 AS runtime-env
WORKDIR /publish
COPY --from=build-env /publish .
ENTRYPOINT [ "dotnet","apiswagger.dll" ]