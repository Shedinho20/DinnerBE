
using DinnerWithMe.Application.Common.Interfaces.Services;

namespace DinnerWithMe.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
      public DateTime UtcNow => DateTime.UtcNow;

}