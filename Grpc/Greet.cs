using ProtoBuf.Grpc;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Grpc.Contracts
{
    [DataContract]
    public class HelloRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
    }
    [DataContract]
    public class HelloReply
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Task<HelloReply> SayHelloAsync(HelloRequest request,
        CallContext context = default);
    }
}
