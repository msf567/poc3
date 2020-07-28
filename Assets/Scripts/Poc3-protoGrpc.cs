// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: poc3-proto.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace POC3 {
  public static partial class POC3Service
  {
    static readonly string __ServiceName = "POC3.POC3Service";

    static readonly grpc::Marshaller<global::POC3.CameraOrientation> __Marshaller_POC3_CameraOrientation = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::POC3.CameraOrientation.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::POC3.SetReply> __Marshaller_POC3_SetReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::POC3.SetReply.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::POC3.SpawnPosition> __Marshaller_POC3_SpawnPosition = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::POC3.SpawnPosition.Parser.ParseFrom);

    static readonly grpc::Method<global::POC3.CameraOrientation, global::POC3.SetReply> __Method_SetCameraPosition = new grpc::Method<global::POC3.CameraOrientation, global::POC3.SetReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SetCameraPosition",
        __Marshaller_POC3_CameraOrientation,
        __Marshaller_POC3_SetReply);

    static readonly grpc::Method<global::POC3.SpawnPosition, global::POC3.SetReply> __Method_SpawnSphere = new grpc::Method<global::POC3.SpawnPosition, global::POC3.SetReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SpawnSphere",
        __Marshaller_POC3_SpawnPosition,
        __Marshaller_POC3_SetReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::POC3.Poc3ProtoReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of POC3Service</summary>
    [grpc::BindServiceMethod(typeof(POC3Service), "BindService")]
    public abstract partial class POC3ServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::POC3.SetReply> SetCameraPosition(global::POC3.CameraOrientation request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::POC3.SetReply> SpawnSphere(global::POC3.SpawnPosition request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for POC3Service</summary>
    public partial class POC3ServiceClient : grpc::ClientBase<POC3ServiceClient>
    {
      /// <summary>Creates a new client for POC3Service</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public POC3ServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for POC3Service that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public POC3ServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected POC3ServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected POC3ServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::POC3.SetReply SetCameraPosition(global::POC3.CameraOrientation request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SetCameraPosition(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::POC3.SetReply SetCameraPosition(global::POC3.CameraOrientation request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SetCameraPosition, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::POC3.SetReply> SetCameraPositionAsync(global::POC3.CameraOrientation request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SetCameraPositionAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::POC3.SetReply> SetCameraPositionAsync(global::POC3.CameraOrientation request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SetCameraPosition, null, options, request);
      }
      public virtual global::POC3.SetReply SpawnSphere(global::POC3.SpawnPosition request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SpawnSphere(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::POC3.SetReply SpawnSphere(global::POC3.SpawnPosition request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SpawnSphere, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::POC3.SetReply> SpawnSphereAsync(global::POC3.SpawnPosition request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SpawnSphereAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::POC3.SetReply> SpawnSphereAsync(global::POC3.SpawnPosition request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SpawnSphere, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override POC3ServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new POC3ServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(POC3ServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SetCameraPosition, serviceImpl.SetCameraPosition)
          .AddMethod(__Method_SpawnSphere, serviceImpl.SpawnSphere).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, POC3ServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SetCameraPosition, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::POC3.CameraOrientation, global::POC3.SetReply>(serviceImpl.SetCameraPosition));
      serviceBinder.AddMethod(__Method_SpawnSphere, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::POC3.SpawnPosition, global::POC3.SetReply>(serviceImpl.SpawnSphere));
    }

  }
}
#endregion