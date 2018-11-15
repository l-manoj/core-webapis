# Docker
## Docker Registry
- Registry is the place to store and retrive containers
- Official docker container registry is DockerHub
- Images are stored in repos
- Repos can be public/private
- Permissions can be setup on who/how to manage repos via teams, organisations
- Third party registries are also available like Quay from CoreOs, Azure, AWS and Google container registries
- Docker Trusted Registry(DTR) is a private on-prem inside the firewall registry that can be setup via Docker EE 
- DockerHub also provide Docker Content Trust
- Docker Content Trust validates the image integrity and verifies publisher identity

## Docker Networking
### Introduction

Container Networking Model(CNM) --> Libnetwork --> Drivers  

CNM : Docker networking specification design  
Made of three important components
-- Sandbox a.k.a namespace in linux
-- Endpoints a.k.a network interfaces eg: eth0  
-- Network refers as connected endpoints  
https://github.com/docker/libnetwork/blob/master/docs/design.md  
Libnetwork : Real-world CNM implemenation written in GoLang (Control plane)  
Drivers: provide actual networking (Data Plane)

Common Commands:
docker network --help  
docker network ls  
docker network inspect $networkname  
docker network create -d bridge --subnet 10.0.0.1/24 lm-bridge  
docker container run -d --name alpine1 --network lm-bridge alpine sleep 1d   
docker container run -d -p 8080:80 --name nginx2 nginx  

### Drivers and Use Cases
#### Single-host networking (builtin BRIDGE n/w)
- On Linux, bridge driver On Windows, nat driver 
- bridge n/ws are single host
- bridge driver creates a 802.1d bridge device on the docker host  
- creating a bridge network is going to create a virtual switch or virtual bridge on the docker host
- vswitch is kernel feature on linux that is mature/stable and fast 
- containers within a network are pingable by name 
- to communicate with containers within a network from outside, a port needs to be published onto the docker host
#### Multi-host networking (builtin OVERLAY n/w)
#### Working with existing workloads (MACVLAN and IPVLAN)

#### Useful info
##### Docker Expose vs Docker Publish
Exposing a port means the container listens to traffic on that port within the same nw. Note that only connections within the same network are allowed and connections from containers on other nws and host are not allowed. 
Publishing a port maps the host port to the container port, so that all traffic to host on that port will be sent to container
##### Docker Compose vs Docker Stack
Dcoker-compose is a python project that is a separate installation beside docker engine. It is used to deploy multi-containerized apps on single docker engine. It doesnot work in swarm mode. 
Docker stack is integrated into docker engine, no separate installation needed. It is used to deploy multi-containerized apps across docker swarm. It work only in swarm mode. 
Both work with compose.yml files, but Compose supports both version 2 and 3, where as Stack supports only version 3. 
