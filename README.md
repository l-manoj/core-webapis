# core-webapis
## Project apiswagger: A simple ASP.Net Core 2.0 web api with docker implementation
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

## Docker deep dive   

Docker Certified Associate Exam  
Docker Deep Dive HandBook  
### Installation  
- Play-with-docker(https://labs.play-with-docker.com/)   
- Docker for Windows/Mac (Good for local development only)   
- Docker for Windows Server 2016(Production ready)  
 -- Preinstall Windows Containers Feature  
 -- Run below instructions for clean install(powershell as Admin)  
--- Install-Module DockerProvider -Force   
--- Install-Package Docker -ProviderName DockerProvider -Force   
- Docker for Linux   
 -- See docker docs for specfic instructions on various flavours of Linux   

### Architecture and Theory
 #### Kerner Internals
 Each container is like a virtual OS but all share single kernal on host  
###### Namespaces manage isolation  
Below are linux namespaces  
- Process Id (pid)  
- Network (net)  
- Filesytem/mount (mnt)  
- Inter-proc comms (ipc)  
- UTS (uts)  
- User (user)

- pid namepace gives each container its own isolated process tree completed with its own pid 1  
- net namepace gives each container its own isolated network stack like ips, routing tables, etc  
- mnt namepace gives each container its own isolated root file system(ie. C: for windows and / for linux)  
- ipc namepace lets all processess in a single container access shared memory but blocks everything from outside  
- uts namepace gives each container its own hostname  
- user namespace lets map accounts from inside of the container to different users on the host    
###### Each container is an organized collection of pid, net, mnt, ipc, uts and user     
###### Control groups set limits on the system resources(cgroups in linux and job objects in windows). The idea is to group processes and impose limits    

#### Docker Engine:  
 
###### DockerEngine = DockerDaemon+containerd+oci(runc on linux) runtime  
###### General:   
Client--via rest-->daemon(Docker API)--GRPC API-->containerd(Execution/lifecycle of containers)-->OCI(runtime)--pops-->container  
###### Linux  
Client-->daemon-->containerd-->runc(oci reference implementation)-->container  
###### Windows  
Client-->daemon-->compute services-->container  
container creation =client ->daemon->containerd->shim->oci(runc)->container  
###### Client=dockere.exe  Engine=dockerd.exe  
###### Windows host has two options for containers   
- i.e native windows containers (docker container run ..)    
- hyper-v containers (docker container run .. --isolation=hyperv)

### Working with Images   

An image is a collection  
--layer of filesystems  
--manifest file  
--appconfig file(which tells how the layers will come together to be a working app)  
On Linux, images are stored in storage driver   
On Windows, image are stored at C:/ProgramData/Docker/WindowsFilter  

docker system info  
docker image pull redis    
docker image inspect redis    
docker image rm redis    

###### Registry is the place where we store images. Default is DockerHub. 
With in the Hub, there are repos and repos have images. 
By default latest tag will be pulled for images, but tag assignment to images is a manual thing which means latest tag does not always guarantee the most recent version of image. 

###### Image layers have three different ids.
- A random uid while being stored in the storage driver of the host
- Layers of the image are hashed with sha256 referred as content hashes on docker client
- When pushed over the internet, content is compressed and have new hashes(sha 256) referred as Distribution hashes. 
###### So, not to be confused with differnt ids for the same image layers.

- Layer id is the sha256 cryptographic key generated for the contents of the layer  
- Image is the sha256 cryptographic key generated for the manifest file  

###### Best practises
- Use offical images wherever possible
- keep your images small
- be explicit in referencing images(docker-registry/repo/tags)

### Containerizing an App
###### Dockerfile Notes
- CAPITALIZE instructions
- INSTRUCTION value
- FROM always first instruction
- FROM = base image
- Good practise to list maintainer
- Some instructions add only metadata instead of layers 

### Working with Containers
  * Container is the smallest unit of work in Docker world  
  * Container is just a thin writable layer on top of a read-only image(run-time version of an image)   
  * Container lifecycle is  start, stop, pause, restart, and delete
  * Containers are not only for microservices but for traditional apps too
  * Containers should be viewed as ephimeral(short-lived) and immutable 
 
 - Ctrl+P+Q exits a container without actually killing its main process
 - Default Processess for new containers
  CMD: Run-time args override cmd args
  EntryPoint: Run-time args are appended to cmd entrypoint

some commands 
docker container run -it -p 8080:80 microsoft/aspnetcore-build
docker container stop _container_  
docker container start _container_
docker container rm _container_
docker container exec _container_ process
docker port _container_

###### Logging 
Two types of logs 
Daemon/Engine Logs
Linux: 
- systemd: journalctl -u docker.service
- nonsystemd: try /var/log/messages
Windows:
~/AppData/Local/Docker and WindowsEventLogs
Container/App Logs
- Design the application to run as pid 1 and ideally log to stdout and stderr
- Logs are captured by stdout and stderr
- Third party log frameworks like syslog, splunk, fluentid can be integrated to stderr and stdout via logging drivers.
- Set default logging driver in *daemon.json*
- Override per container via --log-driver and --log-opts
- inspect logs with *docker logs _container_*

### Swarm
Swarm is a secure cluster of docker nodes
Swarm has two parts - Secure Cluster and Orchestration
Secure Cluster 
- has nodes as managers and workers
- managers and workers authenticate mutually via MTLS protocol
- all network chat is encrypted
- has distributed encrypted cluster store(etcd) available to all managers (but not to workers) 
- has cryptographic manager join-token and worker join-token
- can handle native swarn work or kubernetes work

###### To acheive quorum, always prefer to have 3, 5 or 7 managers
###### Swarm Mode refers to a node in a cluster
###### Single-engine mode refers to a node not in a cluster 
###### Within in a swarm, all the distribution consensus is handled by raft
Autolock mode:
Impact
- prevents mangegers from auto rejoin onto cluster
- prevents automatically restoring old copy of swarm 

- Orchestration can be done via swarn or kubernetes
###### enerate a ssh key-pair : ssh-keygen -t rsa -b 2048

First manager in a cluster is elected as a leader.
- It is the root ca 
- builds a cluster store
- issues a client certificate
- built in certificate rotation policy 
Common commands
docker system info  
docker swarm init   
docker swarm init --external-ca  ..
docker swarm join  
docker node ls  
docker swarm join-token manager
docker swarm join-token worker 
docker swarm join-token --rotate worker
docker swarm init --autolock
docker swarm update --autolock=true  
service docker restart  
docker swarm unlock   
docker swarm update --cert-expiry 48h  

### Docker Networking
###### Refer "Docker Networking" course on Pluralsight
##### bridge (linux)/nat(windows) 
- single host l2network
- turned on default 
- each container gets its own ip
- needs port mapping to talk to other networks even on same host 
- commonly referred as docker0
##### overlay 
- multi host l2network (swarm level)
- control plane is encrypted by default, data plane can be encrypted via (-o encryted flag)
- but container only
##### macvlan(linux)/ transparent(windows)
- gives each conatiner its own mac and ip address on the existing nw
- external connections 
- but must allow promiscuous mode
##### ipvlan 
- similar to macvlan but does not need promiscuous mode
- experimental 

Network Services:  
Service Discovery  
- locate a service in a swarm  
Load Balancing
- access a service from any node in the swarm 
 
Common Useful Commands
docker network create -d overlay/bridge $networkname
docker network create -o encrypted -d overlay/bridge --name $networkname
docker network ls
docker network inspect $networkname
docker port $container
docker service ps $servicename  
docker service create -d --name sv1 --replicas 3 --network ol1 alpine sleep 48h


### Volumes and Persistent Data
Volumes live on graph driver of the host  
As long as the storage supports docker driver, any volume can be plugged into containers  
Also supports SAN and NAS storage mounts  
Common Useful Commands  
docker volume create $volumename  
docker container run -d --name al --mount source=v1,target=/al alpine sleep 48h  

### Working with Secrets
Secrets works in Swarm mode and with services only  
Working:   
A secret is sent to the manager via secure channel and stored in the cluster store in its encrypted form.   
Secret when required by a service is only sent to those nodes that run the replicas via secure channel  
On Linux nodes, these secrets are stored in-memory in their un-encrypted form and are never persisted to disk  
Available in memory at /run/secrets/
On Windows nodes, these secrets are persisted to physical servers  
Peristed to C:\ProgamData\Docker\Secrets  
Once worker nodes no longer need the secret, they are instructed to flush them from memory  
Also, cannnot delete a secret in use    

Common Useful Commands  
docker secret create $name $file  
docker secret inspect $name  
docker service create --name svc1 --secret sec1 --replicas 2 ....  

### Deploy with Stacks and Services  
Highest level of docker application hierarchy  
Stack file is a compose YAML file 
Stacks provide a declarative way of defining application state  
Stack file is defining the desired state of entire application in one place (version,services, newtworks and volumes)  
Refer to docs for syntax of compose files  

###### Topology-aware scheduling: Schedule based on node labels(like manager or worker etc)
###### Health-aware scheduling: Only schedule to healthy nodes  
###### H/A Scheduling: Spread replicas across multiple nodes 

Common Useful Commands   
docker stack deploy -c stackfile.yml $name  
docker stack ls   
docker stack ps $name  
docket stack services $name  

### Enterprise Tooling
- Docker EE    
- Docker Universal Control Plane (UCP) Operations UI  
 -- It is a GUI for managing swarm and kubernetes apps  
 -- It is a microservices based containered app running on top of Docker EE  
 -- It is a swarm based cluster in which UCP manager handles the control plane and we apps are scheduled UCP workers  
- Docker Trusted Registry (DTR)  
 -- Also a containerzed app   
 -- configure the setup in UCP and get the instructions for deployment on the swarm cluster  
- Role-Based Access Control (RBAC)  
 -- Subject (Users or Teams) ++ Role (Actions) ++ Collections (set of resources) ===> Grant   
- Image Scanning  
 -- Scans images(on push) against known vulnerabilities  
- Load Balancing    
-- Swarm-mode Routing Mesh
  --- Transport Layer(L4) Load Balancing where in any service on the cluster can be discoverd from any node in the swarm      
  --- Every Service gets a Virtual IP and all the replicas ips are mapped to the VIP. When a request arrives on the published port in any of the nodes in the cluster, the DNS resolves the request to the VIP and then VIP round-robins within the available replicas  
-- HTTP Routing Mesh (HRM)  
  --- Application Layer(L7) Load Balancing allows to publish multiple services on the same swarm wide port and the DNS is resolved by the inspecting http host header      


### Additional Info
Docker Deep Dive Handbook
Docker Certified Associate
Kubernetes
