using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using NUnit.Framework;
using Poc.LampNotWorkingFlowchart.ConsoleApp.Factories;
using Poc.LampNotWorkingFlowchart.ConsoleApp.Nodes;
using System.Threading.Tasks;

namespace Poc.LampNotWorkingFlowchart.ConsoleApp.Tests;

public class LampContextTests
{
    private LampNodeFactory lampNodeFactory = null!;
    private readonly Fixture fixture = new();

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        fixture.Customize(new AutoNSubstituteCustomization() { ConfigureMembers = true});
        lampNodeFactory = fixture.Create<LampNodeFactory>();
    }

    [TestCase(false, false, true, LampAction.PlugLampIntoSocket)]
    [TestCase(true, false, true, LampAction.RepairLamp)]
    [TestCase(true, true, true, LampAction.ReplaceBulb)]
    public async Task Set_Lamp_Node_Should_Return_Lamp_Action_Result(bool lampPluggedIn, bool bulbBurnedOut, bool socketIsNearby, LampAction expected)
    {
        var sut = new LampContext()
        {
            LampPluggedIn = lampPluggedIn,
            BulbBurnedOut = bulbBurnedOut,
            SocketIsNearby = socketIsNearby
        };

        var initialNode = lampNodeFactory.CreateLampNode<LampDoesNotWorkNode>(sut);

        (await sut.SetLampNodeAsync(initialNode))
            .LampActionResult
            .Value
            .Should()
            .Be(expected);
    }
    
    [Test]
    public async Task Given_Socket_Not_Nearby_When_Set_Lamp_Node_Should_Return_Failed_Result()
    {
        var sut = new LampContext()
        {
            LampPluggedIn = false,
            BulbBurnedOut = false,
            SocketIsNearby = false
        };

        var initialNode = lampNodeFactory.CreateLampNode<LampDoesNotWorkNode>(sut);

        (await sut.SetLampNodeAsync(initialNode))
            .LampActionResult
            .IsFailed
            .Should()
            .BeTrue();
    }
}