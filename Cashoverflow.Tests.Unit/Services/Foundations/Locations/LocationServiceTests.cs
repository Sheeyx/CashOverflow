using System.Linq.Expressions;
using Cashoverflow.Brokers.Loggings;
using Cashoverflow.Brokers.Storages;
using Cashoverflow.Models.Locations;
using Cashoverflow.Services.Foundations.Locations;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace Cashoverflow.Tests.Unit.Services.Foundations.Locations;

public partial class LocationServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly Mock<ILoggingBroker> loggingBrokerMock;
    private readonly ILocationService locationService;

    public LocationServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.loggingBrokerMock = new Mock<ILoggingBroker>();
        
        this.locationService = new LocationService(
            storageBroker: this.storageBrokerMock.Object,
            loggingBroker: this.loggingBrokerMock.Object
            );
    }
    
    private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
        actualException => actualException.SameExceptionAs(expectedException);
    
    [Fact]
    private DateTimeOffset GetRandomDateTimeOffset() =>
        new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();

    private Location CreateRandomLocation() =>
        CreateLocationFiller(dates:GetRandomDateTimeOffset()).Create();

    private Filler<Location> CreateLocationFiller(DateTimeOffset dates)
    {
        var filler = new Filler<Location>();

        filler.Setup()
            .OnType<DateTimeOffset>().Use(dates);

        return filler;
    }
    
} 