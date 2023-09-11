# Online-Shopping-Api

## Description

Online-Shopping-Api is a Rest API, that I am using to expand my knowledge of Rest API's, currently it has basic CRUD functionality.

## Documentation

Additional Information on how to run the app can be found in the Docs, directory.

## Packages at play

[MediatR](https://github.com/jbogard/MediatR), Provides an extremely easy way to implement the CQRS Pattern.

[FluentValidation](https://github.com/FluentValidation/FluentValidation), Ties in extremely nicely with MediatR to validate Objects.

[Testcontainers](https://github.com/isen-ng/testcontainers-dotnet), Allows you to spin up an test instance of a container that you might need, in my case it was an MsSqlContainer.

## Running locally

You should be able to run it locally with ease:
1) Clone the repo
2) Browse to the directly to where the docker-compose file is.
3) Open terminal/cmd/powershell in the directory
4) Run "docker-compose up"
5) It should pull everything you need and start the api.
6) You should be able to hit the swagger by going to http://localhost:6969/swagger/index.html
7) Note you need to authenticate before you can use any of the cart,customer or product calls.
8) Use the auth call to get your token, click the authorize button and type "bearer {token that you received via the call}"

If you wish to run it via Visual Studio:
1) Clone the solution
2) Open the solution using Visual Studio
3) set start up to docker-compose
4) Hit F5
5) App should start up and automatically take you to http://localhost:6969/swagger/index.html

## Running the tests

You should be able to run all the tests in the solution and they should be recognised by visual studio.
