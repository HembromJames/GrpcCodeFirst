using Grpc.Contracts;
using Grpc.Net.Client;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace GrpcServiceNew.Services
{
    public class HelloService : IHelloService
    {
        private readonly IHelloService helloService;

        public HelloService(GrpcChannel channel)
        {
            helloService = channel.CreateGrpcService<IHelloService>();
        }
        public Task<HelloReply> SayHelloAsync(HelloRequest request, CallContext context = default)
        {
            return Task.FromResult(new HelloReply() { Message = request.Name });

        }
    }
}
