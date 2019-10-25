# /dev/null as a Service (.NET)

A grossly over-engineered implementation of [/dev/null as a Service](https://devnull-as-a-service.com/) in ASP.NET Core 3.0.

This is completely, totally serious.  [Seriously.](https://www.google.com/search?q=this+is+a+joke&source=lnms&tbm=isch&sa=X&ved=0ahUKEwiW65SonLblAhXYu54KHdffAqwQ_AUIEigB&biw=1440&bih=766)

## Features

- Implementation of [/dev/null as a Service](https://devnull-as-a-service.com/) that actually copies data to `/dev/null`  😂
- Supports `GET`s on `/dev/zero`
- Live, interactive Swagger documentation
- Uses latest [C# 8.0 features](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8), such as [Nullable Reference Types](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references)

## TODO

- [x] [Base implementation in basic asp-net-core 3.0](https://github.com/stephen-riley/devnull-as-a-service-dot-net/tree/base-implementation)
- [x] [Swaggerize](https://github.com/stephen-riley/devnull-as-a-service-dot-net/tree/swaggerized)
- [x] [API versioning](https://github.com/stephen-riley/devnull-as-a-service-dot-net/tree/api-versioning) [ref](https://youtu.be/WFEE5yVJwGU)
- [x] [Testing project (xUnit)](https://github.com/stephen-riley/devnull-as-a-service-dot-net/tree/added-tests)
- [x] [Convert project to use nullable reference types](https://github.com/stephen-riley/devnull-as-a-service-dot-net/tree/use-nullable-refs)
- [ ] Turn on code analyzers with warnings as errors
- [ ] Class-backed configuration
- [ ] Build on commit with GitHub Actions
- [ ] Fancy logging
- [x] [GETs on /dev/zero](https://github.com/stephen-riley/devnull-as-a-service-dot-net/tree/support-gets)
- [ ] Dockerize
- [ ] RabbitMQ support? [ref](https://www.tutorialdocs.com/article/dotnet-generic-host.html)
- [ ] Auth? [ref](https://auth0.com/blog/how-to-build-and-secure-web-apis-with-aspnet-core-3/)
