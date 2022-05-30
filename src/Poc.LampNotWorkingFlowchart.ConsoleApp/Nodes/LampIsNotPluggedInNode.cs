using FluentResults;

namespace Poc.LampNotWorkingFlowchart.ConsoleApp.Nodes;

public class LampIsNotPluggedInNode : LampNode
{
    public LampIsNotPluggedInNode(LampContext lampContext)
        : base(lampContext)
    {
    }

    public override async Task HandleOnSetAsync()
    {
        LampActionResult = LampContext.SocketIsNearby
            ? LampAction.PlugLampIntoSocket.ToResult()
            : Result.Fail("Socket is not nearby");
    }
}