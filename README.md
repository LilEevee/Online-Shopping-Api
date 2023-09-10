# Online-Shopping-Api

Online-Shopping-Api is a Rest API, that I am using to expand my knowledge of Rest API's, currently it has basic CRUD functionality.

## Packages at play

MediatR (https://github.com/jbogard/MediatR), Provides an extremely easy way to implement the CQRS Pattern.

FluentValidation (https://github.com/FluentValidation/FluentValidation), Ties in extremely nicely with MediatR to validate Objects.

Testcontainers (https://github.com/isen-ng/testcontainers-dotnet/tree/master), Allows you to spin up an test instance of a container that you might need, in my case it was an MsSqlContainer.
