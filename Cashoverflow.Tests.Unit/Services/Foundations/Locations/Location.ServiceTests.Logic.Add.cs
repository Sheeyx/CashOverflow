using Cashoverflow.Models.Locations;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Tynamix.ObjectFiller;
using Xunit;

namespace Cashoverflow.Tests.Unit.Services.Foundations.Locations;

public partial class LocationServiceTests
{
    [Fact]
    public async Task ShouldAddLocationAsync()
    {
        //given
        Location randomLocation = CreateRandomLocation();
        Location inputLocation = randomLocation;
        Location persitedLocation = inputLocation;
        Location expectedLocation = persitedLocation.DeepClone();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertLocationAsync(inputLocation)).ReturnsAsync(expectedLocation);
        //when
        Location actualLocation = await this.locationService.AddLocationAsync(inputLocation);
        //then
        actualLocation.Should().BeEquivalentTo(expectedLocation);
        
        this.storageBrokerMock.Verify(broker =>
            broker.InsertLocationAsync(inputLocation), Times.Once);
        
        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();

    }
}