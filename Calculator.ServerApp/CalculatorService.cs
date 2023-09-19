using System.Threading.Tasks;
using Grpc.Core;

namespace Calculator.ServerApp;

public sealed class CalculatorService : Calculator.CalculatorBase 
{
    public override Task<OperationResponse> Add(OperationRequest request, ServerCallContext context)
    {
        return Task.FromResult(new OperationResponse
        {
            Result = $"{request.Operand1 + request.Operand2}"
        });
    }

    public override Task<OperationResponse> Subtract(OperationRequest request, ServerCallContext context)
    {
        return Task.FromResult(new OperationResponse
        {
            Result = $"{request.Operand1 - request.Operand2}"
        });
    }

    public override Task<OperationResponse> Mutiply(OperationRequest request, ServerCallContext context)
    {
        return Task.FromResult(new OperationResponse
        {
            Result = $"{request.Operand1 * request.Operand2}"
        });
    }

    public override Task<OperationResponse> Divide(OperationRequest request, ServerCallContext context)
    {
        if (request.Operand2 == 0)
        {
            return Task.FromResult(new OperationResponse
            {
                Result = "Cannot divide by zero."
            });
        }

        return Task.FromResult(new OperationResponse
        {
            Result = $"{request.Operand1 / request.Operand2}"
        });
    }
}