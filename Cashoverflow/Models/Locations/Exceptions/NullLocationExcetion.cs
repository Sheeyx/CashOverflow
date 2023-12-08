using Xeptions;

namespace Cashoverflow.Services.Foundations.Locations.Exceptions;

public class NullLocationExcetion : Xeption
{
    public NullLocationExcetion()
        : base(message: "Location is null.")
    {}
}