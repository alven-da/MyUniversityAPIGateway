# My University API Gateway

My practice project in developing a simple backend service using C# by applying Hexagonal or Clean Architecture, Dependency Injection / Inversion of Control and Test-Driven Development principles coming from my experience in Java and/or TypeScript.

## The Setup

### Environment Variables

Your `.env` file should have the following variables

```
ENVIRONMENT=
JWT_KEY=
JWT_ISSUER=
JWT_AUDIENCE=
```

### Local Setup

```
dotnet watch
```

### Testing

```
dotnet test MyUniversityAPIGateway.Tests/MyUniversityAPIGateway.Tests.csproj
```

### Containerizing

This will build the Dockerfile and run as a container
```
docker-compose up
```
