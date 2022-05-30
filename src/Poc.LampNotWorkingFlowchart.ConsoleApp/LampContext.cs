using Poc.LampNotWorkingFlowchart.ConsoleApp.Nodes;

namespace Poc.LampNotWorkingFlowchart.ConsoleApp;

public class LampContext
{
    public bool LampPluggedIn { get; set; }

    public bool BulbBurnedOut { get; set; }

    public bool SocketIsNearby { get; set; }

    public LampNode? CurrentLampNode { get; private set; }

    public async Task<LampContext> SetLampNodeAsync(LampNode lampNode)
    {
        CurrentLampNode = lampNode;
        await CurrentLampNode.HandleOnSetAsync();
        return this;
    }
}