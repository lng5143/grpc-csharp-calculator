using static System.Console;
using Grpc.Core;

namespace Calculator.ClientApp;

public class Program {
    const int Port = 50050;
    public static async Task Main(string[] args)
    {
        Channel channel = new Channel($"127.0.0.1:{Port}", ChannelCredentials.Insecure);

        var client = new Calculator.CalculatorClient(channel);

        WriteLine("What operation do you want to do? ");
        Write("Enter + - * / :");
        string operation = ReadLine();

        Write("Enter first operand: ");
        double operand1 = Double.Parse(ReadLine());

        Write("Enter second operand: ");
        double operand2 = Double.Parse(ReadLine());

        if (operation == "+")
        {
            var reply = client.Add(new OperationRequest
            {
                Operand1 = operand1,
                Operand2 = operand2
            });
            WriteLine("Result: " + reply.Result);
        }
        else if (operation == "-")
        {
            var reply = client.Subtract(new OperationRequest
            {
                Operand1 = operand1,
                Operand2 = operand2
            });
            WriteLine("Result: " + reply.Result);
        }
        else if (operation == "*")
        {
            var reply = client.Mutiply(new OperationRequest
            {
                Operand1 = operand1,
                Operand2 = operand2
            });
            WriteLine("Result: " + reply.Result);
        }
        else if (operation == "/")
        {
            var reply = client.Divide(new OperationRequest
            {
                Operand1 = operand1,
                Operand2 = operand2
            });
            WriteLine("Result: " + reply.Result);
        }
        else 
        {
            WriteLine("You need to enter the correct operation sign.");
        }

        await channel.ShutdownAsync();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}