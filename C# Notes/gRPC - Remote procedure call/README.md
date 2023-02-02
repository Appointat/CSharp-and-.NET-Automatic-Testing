# gRPC - Remote procedure call


# Overview

[gRPC](https://grpc.io/) is a high-performance, open-source framework for building remote procedure call (RPC) APIs. It allows you to define APIs using the Protocol Buffer data format, which provides efficient and fast serialization and deserialization of data. gRPC supports a wide range of programming languages and can run on any platform, making it a popular choice for building scalable and efficient microservices.

# Get started! : C#, Go, C++, Java, Python

## C#/.NET

*This page used to contain the documentation for the original C# implementation of gRPC based on the native gRPC Core library (i.e. `Grpc.Core` nuget package). The implementation is currently in maintenance mode and its source code has been [moved](https://github.com/grpc/grpc/blob/master/src/csharp/README.md). We plan to deprecate the implementation in the future (see [blogpost](https://grpc.io/blog/grpc-csharp-future/)) and we recommend that all users use the [grpc-dotnet](https://github.com/grpc/grpc-dotnet) implementation instead. 此页面过去包含基于原生 gRPC 核心库（即 Grpc.Core nuget 包）的 gRPC 的原始 C# 实现的文档。 该实施目前处于维护模式，其源代码已被移动。 我们计划在未来弃用该实现（请参阅博客文章），我们建议所有用户改用 grpc-dotnet 实现。*

The following pages cover the C# implementation of gRPC for .NET ([grpc-dotnet](https://github.com/grpc/grpc-dotnet)):

- [Introduction to gRPC on .NET Core](https://docs.microsoft.com/aspnet/core/grpc)
- [Tutorial: Create a gRPC client and server in ASP.NET Core](https://docs.microsoft.com/aspnet/core/tutorials/grpc/grpc-start)

Several sample applications are available from the [examples](https://github.com/grpc/grpc-dotnet/tree/master/examples) folder in the [grpc-dotnet](https://github.com/grpc/grpc-dotnet) repository.

# Overview of gRPC on .NET

[gRPC](https://grpc.io/) is a **language-agnostic语言无关**, high-performance Remote Procedure Call (RPC) framework.

The **main benefits of gRPC** are:

- Modern, high-performance, lightweight RPC framework.
- Contract-first API development, using Protocol Buffers by default, allowing for language-agnostic implementations.
- Tooling is available for many languages to generate strongly-typed servers and clients.
- Supports client, server, and bi-directional streaming calls.
- Reduced network usage with Protobuf binary serialization.

**These benefits make gRPC ideal for:**

- Lightweight microservices where efficiency is critical.
- Polyglot systems where multiple languages are required for the development.
- Point-to-point real-time services that need to handle streaming requests or responses.

## ****C# Tooling support for .proto files****

gRPC uses a contract-first契约优先 approach to API development. Services and messages are defined in `.proto` files:

```protobuf
syntax = "proto3";

service Greeter {
	rpc SayHello (HelloRequest) returns (HelloReply);
}

message HelloRequest {
	string name = 1;
}

message HelloReply {
	string message = 1;
}
```