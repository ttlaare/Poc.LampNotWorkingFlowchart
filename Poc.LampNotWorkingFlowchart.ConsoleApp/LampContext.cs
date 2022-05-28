using Poc.LampNotWorkingFlowchart.ConsoleApp.Nodes;

namespace Poc.LampNotWorkingFlowchart.ConsoleApp;

public class LampContext
{
    public bool LampPluggedIn { get; set; }
    
    public bool BulbBurnedOut { get; set; }

    public bool SocketIsNearby { get; set; }

    private LampNode? LampNode { get; set; }
    
    public async Task<LampNode> SetLampNodeAsync(LampNode lampNode)
    {
        LampNode = lampNode;
        await LampNode.HandleOnSetAsync();
        return LampNode;
    }
}