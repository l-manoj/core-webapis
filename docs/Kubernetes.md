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
kubelet takes a yaml/json deployment file   
#### Nodes
Nodes is where the actual applications are run. 
##### kubelet
- main kubernetes agent on the node. 
- registers the node with cluster 
- monitors for change on the apiserver and runs pods accordingly
- reports any/all issues to master
##### container-runtime
- Pluggable  
- Default is docker and other option is rkt  
##### kube-proxy
- manages node networks on the cluster
- also manages low-level load balancing across pods and services
#### Declarative/desired state
- Kubernetes works on the concept of declarative(vs iterative) state declaration
#### Pods
- Atomic unit of work in Kubernetes
- Pod is a ring-fenced environment with its own namespaces and filesystems, which means all containers in the pod share the same network and ip address. Therefore, we have to identify different containers via port mapping. 
- Pods cannot be shared across nodes  
- Pods are created and dead. A pod is never restarted.
#### Services
#### Deployments

### Installing k8s

### Working with Pods

### Services

### Deployments

