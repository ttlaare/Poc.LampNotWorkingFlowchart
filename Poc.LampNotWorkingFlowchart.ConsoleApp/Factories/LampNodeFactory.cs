using Poc.LampNotWorkingFlowchart.ConsoleApp.Nodes;

namespace Poc.LampNotWorkingFlowchart.ConsoleApp.Factories;

public class LampNodeFactory
{
    private readonly ILampService lampService;

    public LampNodeFactory(ILampService lampService)
    {
        this.lampService = lampService;
    }

    public LampNode CreateLampNode<TNode>(LampContext context) where TNode : LampNode
    {
        var nodeType = typeof(TNode);
        
        if (nodeType == typeof(LampDoesNotWorkNode))
        {
            return new LampDoesNotWorkNode(context, this);
        }

        if (nodeType == typeof(LampIsPluggedInNode))
        {
            return new LampIsPluggedInNode(context, lampService);
        }
        
        if (nodeType == typeof(LampIsNotPluggedInNode))
        {
            return new LampIsNotPluggedInNode(context);
        }

        throw new ArgumentException($"Not able to create lamp node of type {nodeType.FullName}");
    }
}