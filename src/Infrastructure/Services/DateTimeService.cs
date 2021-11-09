using CovTestMgmt.Application.Interfaces;
using System;

namespace CovTestMgmt.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
