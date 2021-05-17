using ClientApp.API.Services.Logger;
using System;

namespace ClientApp.API.Services.ReportEvent
{
    public class ReportEvent : IReportEvent
    {
        private readonly ILoggerManager _logger;
        public ReportEvent(ILoggerManager logger)
        {
            _logger = logger;
        }

        public bool AddReportEvent(ReportEventModel reportEventModel)
        {
            throw new NotImplementedException();
        }
    }
}
