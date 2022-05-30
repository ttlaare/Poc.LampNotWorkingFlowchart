using FluentResults;

namespace Poc.LampNotWorkingFlowchart.ConsoleApp.Nodes;

public class LampIsPluggedInNode : LampNode
{
    private readonly ILampService lampService;

    public LampIsPluggedInNode(LampContext lampContext, ILampService lampService)
        : base(lampContext)
    {
        this.lampService = lampService;
    }

    public override async Task HandleOnSetAsync()
    {
        if (LampContext.BulbBurnedOut)
        {
            await lampService.RepaireBulb();
            LampActionResult = LampAction.ReplaceBulb.ToResult();
            return;
        }

        await lampService.RepaireLamp();
        LampActionResult = LampAction.RepairLamp.ToResult();
    }
}