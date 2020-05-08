using System;
using System.Net.Http;
using System.Threading.Tasks;
using GrpcGreeter;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        const string url = "https://localhost:5001";

        static async Task Main(string[] args)
        {
            Console.WriteLine("+".PadRight(50, '+'));
            Console.WriteLine("+++ Grpc client sample +++");
            Console.WriteLine("+".PadRight(50, '+'));

            Console.WriteLine($"Instatntiating gRPC channel to {url}");

            using var channel = GrpcChannel.ForAddress(url);
            var client = new Greeter.GreeterClient(channel);
            Console.WriteLine($"Sending new request to SayHallo ...");
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "JosipK" });
            Console.WriteLine($"Reply from server: " + reply.Message);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
