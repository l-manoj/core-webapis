FROM microsoft/aspnetcore-build:2

WORKDIR /apiswagger
COPY . .

RUN dotnet build
RUN dotnet publish

ENTRYPOINT [ "dotnet","bin/Debug/netcoreapp2.0/publish/apiswagger.dll" ]