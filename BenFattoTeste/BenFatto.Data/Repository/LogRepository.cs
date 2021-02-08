using BenFatto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenFatto.Data.Repository
{
    public class LogRepository : BaseRepository<Log>
    {
        public IQueryable<Log> GeneralSearch(string search)
        {
            return SelectAll().Where(w =>
                                w.SourceIP.Contains(search) ||
                                w.Channel.Contains(search) ||
                                w.UserName.Contains(search) ||
                                w.Method.Contains(search) ||
                                w.Url.Contains(search) ||
                                w.UrlDestination.Contains(search) ||
                                w.BrowserAgent.Contains(search)
                                ).AsQueryable();
        }

        public IQueryable<Log> SearchByDate(DateTime? beginDate, DateTime? endDate)
        {
            var logs = SelectAll().AsQueryable();
            if (beginDate != null)
            {
                logs = logs.Where(w => w.Created >= beginDate);
            }
            if (endDate != null)
            {
                logs = logs.Where(w => w.Created <= endDate);
            }
            return logs.AsQueryable();
        }
    }
}
