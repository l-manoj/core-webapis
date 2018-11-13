# Kubernetes
## Overview
- Born out of Google
- Open sourced to CNSF in 2014
- Version 1 released in 2015
- Written in GoLang
- Github: https://github.com/kubernetes/kubernetes 

### What is Kubernetes?
- K8s is an orchestrator for deploying containerized microservices.

### Kubernetes Architecture
#### Master
Master can be refereed as control plane of the k8s cluster.  
Master manages the cluster. It has four main components
##### kube-apiserver
- main front-end of the k8s cluster
- exposes rest api and accepts json
- only public facing component of k8s cluster
- commands are usually passed via kubectl command line 
##### cluster store
- stores the config and state of k8s cluster as persistent storage
- uses etcd distributed key-value store
- source-of-truth for the k8s cluster
##### kube-controller-manager
- controller manager is like a controller of controllers
- it monitors the cluster for desired state changes
##### kube-scheduler
- monitors the cluster for new pods
- schedules the pods on workers  

Communication to master is through apiserver only via kubectl command line utility.  
kubectl takes a yaml/json deployment file   
#### Nodes/Minions
Nodes is where the actual work is run.   
Every node has its own set of default pods like health, logging, dns etc  
##### kubelet
- main kubernetes agent on the node. 
- registers the node with cluster 
- monitors for change on the apiserver and runs pods accordingly
- reports any/all issues to master
##### container-runtime
- Pluggable  
- Default is docker and other option is rkt  
##### kube-proxy
- manages networks on the cluster
- also manages low-level load balancing across pods and services
#### Declarative/desired state
- Kubernetes works on the concept of declarative(vs iterative) state   
#### Pods
- Atomic unit of work in Kubernetes
- k8s unit of scaling is also a Pod
- Pod is a ring-fenced environment with its own namespaces and filesystems, which means all containers in the pod share the same network and ip address. Therefore, we have to identify different containers via port mapping. 
- Pods cannot be shared across nodes  
- Upon creation a pod runs and dies. A pod is never restarted.
#### Replication controllers
- replication controllers are k8s rest objects that are used to scale pods,maintain desired state etc 
#### Services
- services are k8s rest object which help to load balance across pods providing stable networking
- services uses labels to acheive this load balancing
- services only route traffic to healthy pods
- can be configured for session affinity in yaml file
- can point to things outside the cluster
- services perform random load balancing (dns round-robin is supported)
- default to TCP (udp is supported) 
#### Deployments
- a deployment is also a k8s rest object which makes it easy to deploy multi-containerized app
- deployment is an abstraction over replication controller with additional features
- self documenting, versioned, spec-once deploy-may, simple rolling updates and rollbacks
- a deployment is a REST object deployed via yaml/json manifest file, adds features to replication controllers and deployed via the apiserver

### Installing k8s

### Working with Pods

### Services

### Deployments

