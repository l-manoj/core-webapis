# Docker Networking

## Introduction

Container Networking Model(CNM) --> Libnetwork --> Drivers  

CNM : Docker networking spec design  
Libnetwork : CNM Implemenation (Control plane)  
Drivers: provide actual networking (Data Plane)

Common Commands:
docker network --help  
docker network ls  
docker network inspect $networkname  
