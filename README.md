# core-webapis
A collection of asp.net core web api


Connecting to a container: 
docker run --rm -it microsoft/dotnet:2-runtime

Mounting a volume on MAC:
docker run --rm -it -v /Users/laxmimanojkumarpoonati/Projects/github/core-webapis/apiswagger:/apiswagger microsoft/dotnet:2-runtime

To run the app in the container:
dotnet /apiswagger/bin/Debug/netcoreapp2.0/publish/apiswagger.dll

To run the app in the container from localhost's port 8080:
docker run --rm -it -v -p 8080:80 /Users/laxmimanojkumarpoonati/Projects/github/core-webapis/apiswagger:/apiswagger microsoft/aspnetcore:2

