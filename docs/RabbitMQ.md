# RabbitMQ

## Introduction RabbitMQ
### What is RabbitMQ?  
 Open source messaging system with messages and queues  
 Implements Advanced Message Queueing Protocol(AMQP)  0-9-1
 Written in Erlang  
 Distributed fault tolerant design
 RabbitmQ server is message broker
 RabbitMQ is reliable, persisted to disk, message acknowledments, routing, clustering and high availabilty, 
 management web ui and CLI(RabbitMQ ctrl and admin)
### Rabbitmq vs MSMQ
Centralized vs decentralized
multi-platform vs windows only 
standards based(amqp default) vs proprietary standard
###
web ui to manage message broker and HTTP api to manage rabbitmq

## Introduction to RabbitMQ Exchanges
### AMQP Protocol
Networking protocol
RabbitMQ supports version 0-9-1
enables client applications to communicate with compatible messaging system
Publisher -------> Exchange ----routes/bindings----> Queue ----subscribes/acknowledges----> Consumer
### Exchanges 


## Architecture Notes
### Notes
-- RabbitMQ initial spin up can be done with a batch job    
-- Queue and Exchange declaration in RabbitMQ is idempotent  
-- Queues should be durable  
-- Queue messages should be persisted  
### Useful Commands
docker container run -d --hostname my-rabbit --name rmq rabbitmq:3  
docker container run -d --hostname my-rabbit -p 8080:15672 --name rmqm rabbitmq:3-management  