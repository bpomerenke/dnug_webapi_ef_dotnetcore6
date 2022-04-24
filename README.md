# Example API using EF Core 6

## Overview
This API is intended to drive a Phone-A-Thon app that enables users to recieve donor lists, call for a donation, and record the result.  Though this repository does not represent the actual application's API, the domain is being used to show off the capabilities of Entity Framework, WebAPI and various tools/libraries to use in concert with them to build production worthy applications.

DISCLAIMER: The choices made for the data model, testing (or lack thereof), and operational needs of the API were made to simple show off the technology.  Do not use this code wholesale or expect it to represent what good looks like.  It is merely a demonstration.


## Getting Started
* Install tool
  * `dotnet tool install --global dotnet-ef`
* Install Docker and Docker Compose
  * https://docs.docker.com/get-docker/
* Setup db using docker compose
  * `docker compose -f database.yml up`