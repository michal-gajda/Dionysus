namespace Dionysus.Server.Application.Common.Interfaces;

public interface IDateTimeProvider
{
    DateTime GetDateTime();
    DateOnly GetDate();
    TimeOnly GetTime();
}
