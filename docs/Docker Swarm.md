# Docker Swarm 
Getting Started with Docker Swarm Mode  
https://app.pluralsight.com/library/courses/docker-swarm-mode-getting-started/table-of-contents

## Need for multiple container hosts?
Problems with single node hosting  
- Scale capacity   
-- multiple containers: eventually will run out of space  
-- load balancing: more instances of an app we spin up/down, need to load balance across them  
- Container Failure  
-- restart policy can be setup but tedious job  
- Node Failure  
-- need strategy to redistribute containers upon node failure  
-- plan to replace node  
-- consider options for reloacting containers  
-- node maintenance  
- Internal Communication  
-- if an app requires container to container communication then   
  --- in production each of those microservices have to be load balanced  
  --- in dev we can either expose all apis to host and map the published host port via env variable 
      or we can create a bridge n/w and map with api name(as service discovery will resolve the app name via embedded dns)

## Swarm creation and service basics
set the 'experimental features' flag in daemon settings to use experimental features    
docker swarm init --starts the swarm mode   
docker info --chek if swarm is running or not  
docker node ls --list all nodes in swarm  
docker node --help --for further commands  
dokker service ls --list tasks in service  
docker service ps --list containers in service  
docker service rm --remove a task   
docker service update --{options} -- to update a service  
docker service scale {servicename}={noofreplicas} --serves the same purpose of docker service update --replicas={noof} {servicename}  

A service is a declartive definition of an application.      
It can contain info regarding port mapping, network, cpu/memory limits, rolling update policy and replicas.     
A task is the atomic unit of scheduling within a swarm. A set of tasks form a service or services leads to tasks.  
Swarm manager takes the service definations as desired state and ensures desired state is always maintained. 

Swarm manager flow:   
docker service create -->   
api (accepts commands and creates service object)-->   
orchestrator (creates tasks for service objects) -->   
allocator (allocates ip addressess to tasks)-->   
dispatcher (assigns tasks to nodes)-->   
scheduler (instructs as worker to run a task)  
Worker node flow:  
worker(runs container) --connects to dispatcher and looks for assigned tasks  
executor --executes tasks assigned to worker node  
Hypothetically, you could implement other types of tasks such as virtual machine tasks or non-containerized process tasks. The scheduler and orchestrator are agnostic about the type of task. However, the current version of Docker only supports container tasks.  

A service can be in pending status for several reasons, say, nodes unavailable, memory/placement constraints, etc.  
Note: If your only intention is to prevent a service from being deployed, scale the service to 0 instead of trying to configure it in such a way that it remains in pending.  

### Replicated and global services
There are two types of service deployments, 
- replicated: For a replicated service, you specify the number of identical tasks you want to run  
- global: A global service is a service that runs one task on every node.  Good candidates are monitoring agents, an anti-virus scanners     
Swarm mode routing mesh publishes a port on every single node in the swarm, thereby when request arrives at any node they are routed to swarm load balancer and this will send the request to the appropriate container.



