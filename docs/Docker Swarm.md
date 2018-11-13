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
