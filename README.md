# core-webapis
## A collection of asp.net core web api


## Connecting to a container: 
docker run --rm -it microsoft/dotnet:2-runtime

## Mounting a volume on MAC:
docker run --rm -it -v /Users/laxmimanojkumarpoonati/Projects/github/core-webapis/apiswagger:/apiswagger microsoft/dotnet:2-runtime

## To run the app in the container:
dotnet /apiswagger/bin/Debug/netcoreapp2.0/publish/apiswagger.dll

## To run the app in the container from localhost's port 8080:
docker run --rm -it -p 8080:80 -v /Users/laxmimanojkumarpoonati/Projects/github/core-webapis/apiswagger:/apiswagger microsoft/aspnetcore:2

### Useful commands:
docker ps
docker images ls

## BUILDING IMAGES:
Create dockerfile in working dir
run: docker build -t laxmimanoj/apiswagger .
run: docker run --rm -d -p 8080:80 dotnetcore/apiswagger 

## To push to docker hub:
docker push laxmimanoj/apiswagger

## Steps to build and publish an app from inside a container
docker run --rm -it -p 8080:80  
-v /Users/laxmimanojkumarpoonati/Projects/github/core-webapis/apiswagger:/apiswagger  microsoft/aspnetcore-build:2
cd apiswagger
rm -rf /bin /obj  
dotnet restore  
dotnet build(just to check, if the build errors found try recreating the image by deleting the obj and bin on itself)  
dotnet publish (to test from host on port: 5000 using  dotnet bin/debug/netcoreapp2.0/publish/apiswagger.dll)  
dotnet run (to test from host on port 8080)  

### Above steps to build and publish inside a conatiner can be automated using the Dockerfile and .dockerignore files
NOTE: Be mindful of content root when building images without source code
NOTE: add dockerfile and .dockerignore files to .dockerignore to avoid cache invalidation and thereby speeding up the image build process

The drawback with having the image build and publish within  a single container makes the image bloated.
Hence, multi-stage build is useful where in we build the image in one conatiner and run it on another. 

Also, we can perform optimization on mutli-stage build(refer corresponding git check-in of Dockerfile)

## docker-compose.yml streamlines the process of build and running.
### Useful commands
docker-compose up
docker-compose up -d --build
docker-compose down



