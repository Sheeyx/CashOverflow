using Cashoverflow.Models.Locations;
using Cashoverflow.Services.Foundations.Locations.Exceptions;
using FluentAssertions;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace Cashoverflow.Tests.Unit.Services.Foundations.Locations;

public partial class LocationServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationExceptionOnAddIfInputIsNullAndLogItAsync()
    {
        //given
        Location nullLocation = null;
        var nullLocationException = new NullLocationExcetion();
        var expectedLocationValidationException = new LocationValidationException(nullLocationException);
        //when
        ValueTask<Location> addLocationTask = this.locationService.AddLocationAsync(nullLocation);
        LocationValidationException actualLocationValidationException =
            await Assert.ThrowsAsync<LocationValidationException>(addLocationTask.AsTask);
        //then
        actualLocationValidationException.Should().BeEquivalentTo(expectedLocationValidationException);
        this.loggingBrokerMock.Verify(broker=>
            broker.LogError(It.Is(SameExceptionAs(expectedLocationValidationException))), Times.Once);
        
        this.storageBrokerMock.Verify(broker => 
            broker.InsertLocationAsync(It.IsAny<Location>()),Times.Never);
        
        this.loggingBrokerMock.VerifyNoOtherCalls();
        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}