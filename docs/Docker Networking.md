# Docker Networking

## Introduction

Container Networking Model(CNM) --> Libnetwork --> Drivers  

CNM : Docker networking spec design  
Made of three importamt aspects.
-- Sandbox a.k.a namespace in linux
-- Endpoints a.k.a network interfaces eg: eth0  
-- Network refers as connected endpoints  
https://github.com/docker/libnetwork/blob/master/docs/design.md  
Libnetwork : Real-world CNM Implemenation written in GoLang (Control plane)  
Drivers: provide actual networking (Data Plane)

Common Commands:
docker network --help  
docker network ls  
docker network inspect $networkname  
