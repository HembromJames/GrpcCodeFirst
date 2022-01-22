using Grpc.Contracts;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Components;
using ProtoBuf.Grpc.Client;

namespace NewClient.Pages
{
    public partial class Consumer
    {
        [Inject]
        public NavigationManager _navigationManager { get; set; }
        public string Message { get; set; }
        public string name { get; set; } = string.Empty;
        public async void Submit()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7235");
            var helloClient = channel.CreateGrpcService<IHelloService>();

            var input = new HelloRequest()
            {
                Name = name
            };

            var reply = await helloClient.SayHelloAsync(input);
            _navigationManager.NavigateTo("/consumer",true);
        }        
    }
}
