# ABTS
This product contains using of the following techlogogies and libraries based on .NEY Core 3.1

  1. Elasticsearch 7 with NEST library.
  2. Redis cacheing
  3. Swagger
  4. API Versioning
  5. EF Core with PostgreSQL
  6. Hangfire with Redis

#Docker & Docker-Compose 
  
Project inclued docker-compose support. Docker-compose ups to the folwwoing containers.

  1. PostgrSQL 12
  2. Elastic search 7
  3. Kibana 7
  4. Redis
  5. ASP.NET Core API
  6. Pgadmin

Just use the following commands to up it.

  1. Close repository
  2. cd ABTS.API
  3. docker-compose up

It's done :) Happy coding.

go -> http://localhost/swagger for API swagger UI.
go -> http://localhost:5601 for Kibana UI.
go -> http://localhost:88 for Hangfire UI.

To contact Postgres use.
  -host: localhost
  -user: northwind_user
  -password: 5252
  -port: 5432