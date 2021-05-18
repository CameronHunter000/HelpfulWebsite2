using System;
using HelpfulWebsite_2.Application.Common.Interfaces;

namespace HelpfulWebsite_2.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
