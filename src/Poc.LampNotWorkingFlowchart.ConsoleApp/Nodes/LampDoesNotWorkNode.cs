using Poc.LampNotWorkingFlowchart.ConsoleApp.Factories;

namespace Poc.LampNotWorkingFlowchart.ConsoleApp.Nodes;

public class LampDoesNotWorkNode : LampNode
{
    private readonly LampNodeFactory lampNodeFactory;

    public LampDoesNotWorkNode(LampContext lampContext, LampNodeFactory lampNodeFactory) 
        : base(lampContext)
    {
        this.lampNodeFactory = lampNodeFactory;
    }

    public override async Task HandleOnSetAsync()
    {
        if (LampContext.LampPluggedIn)
        {
            var lampIsPluggedInNode = lampNodeFactory.CreateLampNode<LampIsPluggedInNode>(LampContext);
            await SetToNextNodeAsync(lampIsPluggedInNode);
        }
        else
        {
            var lampIsNotPluggedInNode = lampNodeFactory.CreateLampNode<LampIsNotPluggedInNode>(LampContext);
            await SetToNextNodeAsync(lampIsNotPluggedInNode);
        }
    }
}