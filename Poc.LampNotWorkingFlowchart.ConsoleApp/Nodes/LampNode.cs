using FluentResults;

namespace Poc.LampNotWorkingFlowchart.ConsoleApp.Nodes;

public abstract class LampNode
{
    protected readonly LampContext LampContext;

    protected LampNode(LampContext lampContext)
    {
        LampContext = lampContext;
    }

    public Result<LampAction> LampActionResult { get; protected set; } = Result.Fail("Lamp action result not set");

    /// <summary>
    /// Set LampNode to a child node or set property 'LampActionResult' when at the end of the node
    /// </summary>
    /// <returns></returns>
    public abstract Task HandleOnSetAsync();

    protected async Task SetToNextNodeAsync(LampNode lampNode)
    {
        await LampContext.SetLampNodeAsync(lampNode);
    }
}