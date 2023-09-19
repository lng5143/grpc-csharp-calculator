using static System.Console;

using Grpc.Core;
using System;
using System.IO;
using System.Threading.Tasks;
using Calculator.ServerApp;

namespace Calculator.ServerApp;

internal sealed class Program {
    internal static async Task Main(string[] args)
    {
        const int Port = 50050;

        Server? server = null;

        try {
            server = new Server
            {
                Services = { Calculator.BindService(new CalculatorService()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                
            };

            server.Start();

            WriteLine($"Calculator server listening on port {Port}");
            WriteLine("Press any key to stop the server...");
            ReadKey();

        }
        catch(IOException ex)
        {
            WriteLine($"Server failed to start: {ex.Message}");
            throw;
        }
        finally{
            if (server != null){
                await server.ShutdownAsync();
            }
        }
    }
}