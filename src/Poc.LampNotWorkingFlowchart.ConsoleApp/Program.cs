// See https://aka.ms/new-console-template for more information

using FluentResults;
using Poc.LampNotWorkingFlowchart.ConsoleApp;
using Poc.LampNotWorkingFlowchart.ConsoleApp.Factories;
using Poc.LampNotWorkingFlowchart.ConsoleApp.Nodes;

var service = new LampService();
var factory = new LampNodeFactory(service);

var context = new LampContext()
{
    LampPluggedIn = true,
    BulbBurnedOut = true,
    SocketIsNearby = true,
};

Result<LampAction> lampActionResult = (await context.SetLampNodeAsync(factory.CreateLampNode<LampDoesNotWorkNode>(context)))
    .CurrentLampNode
    !.LampActionResult;

if (lampActionResult.IsFailed)
{
    Console.WriteLine($"Failed: {lampActionResult.Errors.First().Message}");
}
else
{
    Console.WriteLine(lampActionResult.Value);
}

Console.ReadKey();