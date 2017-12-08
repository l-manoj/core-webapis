FROM microsoft/aspnetcore-build:2

WORKDIR /apiswagger
COPY . .

RUN dotnet build
RUN dotnet publish -o /publish

WORKDIR /publish 
ENTRYPOINT [ "dotnet","/publish/apiswagger.dll" ]