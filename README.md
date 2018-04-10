# core-webapis
##Project apiswagger: A simple ASP.Net Core 2.0 web api with docker implementation
## A collection of asp.net core web apis

## Containers
### Connecting to a container: 
docker run --rm -it microsoft/dotnet:2-runtime

### Mounting a volume on MAC:
docker run --rm -it -v /Users/laxmimanojkumarpoonati/Projects/github/core-webapis/apiswagger:/apiswagger microsoft/dotnet:2-runtime

### To run the app in the container:
dotnet /apiswagger/bin/Debug/netcoreapp2.0/publish/apiswagger.dll

### To run the app in the container from localhost's port 8080:
docker run --rm -it -p 8080:80 -v /Users/laxmimanojkumarpoonati/Projects/github/core-webapis/apiswagger:/apiswagger microsoft/aspnetcore:2

### Useful commands:
docker ps
docker images ls

## Images
Create dockerfile in working dir
run: docker build -t laxmimanoj/apiswagger .
run: docker run --rm -d -p 8080:80 dotnetcore/apiswagger 

## Docker hub:
docker push laxmimanoj/apiswagger

### Steps to build and publish an app from inside a container
docker run --rm -it -p 8080:80  
-v /Users/laxmimanojkumarpoonati/Projects/github/core-webapis/apiswagger:/apiswagger  microsoft/aspnetcore-build:2  
cd apiswagger
rm -rf /bin /obj  
dotnet restore  
dotnet build(just to check, if the build errors found try recreating the image by deleting the obj and bin on itself)  
dotnet publish (to test from host on port: 5000 using  dotnet bin/debug/netcoreapp2.0/publish/apiswagger.dll)  
dotnet run (to test from host on port 8080)  

### Above steps to build and publish inside a container can be automated using the Dockerfile and .dockerignore files
NOTE: Be mindful of content root when building images without source code  
NOTE: add dockerfile and .dockerignore files to .dockerignore to avoid cache invalidation and thereby speeding up the image build process

The drawback with having the image build and publish within  a single container makes the image bloated.
Hence, multi-stage build is useful where in we build the image in one container and run it on another. 

Also, we can perform optimization on mutli-stage build(refer corresponding git check-in of Dockerfile)

### docker-compose.yml streamlines the process of build and running.
### Useful commands
docker-compose up  
docker-compose up -d --build  
docker-compose down  

##Project ABC: Docker deep dive   

Docker Certified Associate Exam  
Docker Deep Dive HandBook  
Installation  
Play-with-docker(https://labs.play-with-docker.com/)  
Docker for Windows/Mac  
- Good for local development only  
Docker for Windows Server 2016  
- Production ready  
- Preinstall Windows Containers Feature  
- Run below instructions for clean install(powershell as Admin)  
-- Install-Module DockerProvider -Force  
-- Install-Package Docker -ProviderName DockerProvider -Force  
Docker for Linux  
- See docker docs for specfic instructions on various flavours of Linux  

Architecture and Theory
Kerner Internals:
Each container is like a virtual OS but all share single kernal on host. 
Namespaces manage isolation. 
Below are linux namespaces
Process Id (pid)  
Network (net)  
Filesytem/mount (mnt)  
Inter-proc comms (ipc)  
UTS (uts)  
User (user)

pid namepace gives each container its own isolated process tree completed with its own pid 1
net namepace gives each container its own isolated network stack like ips, routing tables, etc
net namepace gives each container its own isolated root file system(ie. C: for windows and / for linux)
ipc namepace lets all processess in a single container access shared memory but blocks everything from outside
uts namepace gives each container its own hostname
user namespace lets map accounts from inside of the container to different users on the host
Each container is an organized collection of pid, net, mnt, ipc, uts and user.  
Control groups set limits on the system resources(cgroups in linux and job objects in windows). The idea is to group processes and impose limits. 

Docker Engine:
 
DockerEngine=DockerDaemon+containerd+oci(runc on linux) runtime
General: 
Client--via rest-->daemon(Docker API)--GRPC API-->containerd(Execution/lifecycle of containers)-->OCI(runtime)--pops-->container
Linux
Client-->daemon-->containerd-->runc(oci reference implementation)-->container
Windows
Client-->daemon-->compute services-->container
container creation =client ->daemon->containerd->shim->oci(runc)->container
Client=dockere.exe, Engine=dockerd.exe
Windows host has two options for containers 
i.e native windows containers (docker container run ..) and 
hyper-v containers (docker container run .. --isolation=hyperv)

Working with Images: 

An image is the collection
--layer of filesystems
--manifest file
--appconfig file(which tells how the layers will come together to be a working app)

docker system info
docker image pull redis
docker image inspect redis
docker image rm redis

Registry is the place where we store images. Default is DockerHub. 
With in the Hub, there are repos and repos have images. 
By default latest tag will be pulled for images, but tag assignment to images is a manual thing which means latest tag does not always guarantee the most recent version of image. 

Image layers have three different ids.
-> A random uid while being stored in the storage driver of the host
-> Layers of the image are hashed with sha256 referred as content hashes on docker client
-> When pushed over the internet, content is compressed and have new hashes(sha 256) referred as Distribution hashes. 
So, not to be confused with differnt ids for the same image layers.

-- Layer id is the sha256 cryptographic key generated for the contents of the layer
-- Image is the sha256 cryptographic key generated for the manifest file

Best practises:
-> Use offical images wherever possible
-> keep your images small
-> be explicit in referencing images(docker-registry/repo/tags)

Containerizing an App:
Dockerfile Notes
- CAPITALIZE instructions
- <INSTRUCTION> <value>
- FROM always first instruction
- FROM = base image
- Good practise to list maintainer
- Some instructions add only metadata instead of layers 

#Updated Git User


