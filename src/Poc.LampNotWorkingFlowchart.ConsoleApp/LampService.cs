namespace Poc.LampNotWorkingFlowchart.ConsoleApp;

public interface ILampService
{
    Task RepaireLamp();
    
    Task RepaireBulb();
}

class LampService : ILampService
{
    public Task RepaireLamp()
    {
        //do external stuff
        return Task.CompletedTask;
    }

    public Task RepaireBulb()
    {
        //do external stuff
        return Task.CompletedTask;
    }
}