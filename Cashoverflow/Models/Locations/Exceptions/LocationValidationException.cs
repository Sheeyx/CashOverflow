using Xeptions;

namespace Cashoverflow.Services.Foundations.Locations.Exceptions;

public class LocationValidationException : Xeption
{
    public LocationValidationException(Xeption innerException)
        : base(message: "Location validation error occurred, fix the errors and try again.", innerException)
    { }
}