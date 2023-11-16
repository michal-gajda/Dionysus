namespace Dionysus.Server.Application.Common.Services;

using Dionysus.Server.Application.Common.Interfaces;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetDateTime() => DateTime.UtcNow;
    public DateOnly GetDate() => DateOnly.FromDateTime(DateTime.UtcNow);
    public TimeOnly GetTime() => TimeOnly.FromDateTime(DateTime.UtcNow);
}
