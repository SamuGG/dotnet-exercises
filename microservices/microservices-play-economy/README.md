# .NET Microservices + Clean Architecture

**WHAT :** Backend services for a fantasy game where users can buy items from a store, using a fantasy currency, and keep them in their inventory

**WHY :** For learning to develop .NET microservices using clean architecture concepts.

**HOW :** Architecture description:

We'll use 4 microservices: Catalog, Inventory, Identity and trading.

Each microservice has its own exclusive database and no access to each other databases.

For interservice communication, we'll introduce a message broker that will allow the services to publish and consume messages asynchronously.

All the authentication and authorization accross the system will be handled by the Identity microservice.

A front-end portal will allow a friendly interface for interacting with all services.

Eventually moving the system to a cloud-hosted solution will also use an API Gateway for all communications between client applications and our microservices.

Client applications are not part of the exercise so aren't included.

The microservices will interact with some cloud components like: logging, monitoring and distributed tracing; to help troubleshoot issues and check the system remains healthy.

**Technologies Used :**

All microservices are implemented as [.NET](https://dotnet.microsoft.com) web applications; running in [Docker](https://www.docker.com/) containers.

Databases use [MongoDB](https://www.mongodb.com) for storage.

Message broker uses [RabbitMQ](https://www.rabbitmq.com) and for distributed messaging the [MassTransit](https://masstransit-project.com) framework.

[Identity Server](https://docs.identityserver.io/en/latest/) for managing authentication and authorization.

[Emissary Ingress](https://www.getambassador.io/products/api-gateway/) for the API Gateway.

Microservices front-end use a single-page [React](https://reactjs.org) application.

Logs collected and centralized via [Seq](https://datalust.co/seq).

Distributed tracing will be enabled via [Open Telemetry](https://opentelemetry.io) and [Jaeger](https://www.jaegertracing.io).

And for monitoring we'll use [Prometheus](https://prometheus.io) and [Grafana](https://grafana.com).
