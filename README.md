# core-webapis
A collection of asp.net core web api


Connecting to a container: 
docker run --rm -it microsoft/dotnet:2-runtime

Mounting a volume on MAC:
docker run --rm -it -v /Users/laxmimanojkumarpoonati/Projects/github/core-webapis/apiswagger:/apiswagger microsoft/dotnet:2-runtime

To run the app in the container:
dotnet /apiswagger/bin/Debug/netcoreapp2.0/publish/apiswagger.dll

To run the app in the container from localhost's port 8080:
docker run --rm -it -p 8080:80 -v /Users/laxmimanojkumarpoonati/Projects/github/core-webapis/apiswagger:/apiswagger microsoft/aspnetcore:2

Useful commands:
docker ps
docker images ls

BUILDING IMAGES:
Create dockerfile in working dir
run: docker build -t dotnetcore/apiswagger .
run: docker run --rm -it -p 8080:80 dotnetcore/apiswagger 

To push to docker hub:
docker tag dotnetcore/apiswagger laxmimanoj/dotnetcore:apiswagger (change tag first)
docker push laxmimanoj/dotnetcore:apiswagger



