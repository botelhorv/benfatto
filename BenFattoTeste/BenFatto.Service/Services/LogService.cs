using BenFatto.Data.Repository;
using BenFatto.Domain.Entities;
using Infra.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BenFatto.Service.Services
{
    public class LogService : BaseService<Log>
    {
        private LogRepository repository = new LogRepository();

        
        public List<Log> GeneralSearch(string search)
        {
            return repository.GeneralSearch(search).ToList();
        }

        public List<Log> SearchByDate(DateTime? beginDate, DateTime? endDate)
        {
            return repository.SearchByDate(beginDate, endDate).ToList();
        }

        public void LogImport (string logInformation)
        {
            var lines = logInformation.Split("\n");
            
            var logs = lines
                .Select(line => line.Split('"'));
            logs = logs.Take(logs.Count() - 1);

            var logsSelected = logs
                .Select(l => new Log
                {
                    SourceIP = l[0].Split(' ')[0],
                    Channel = l[0].Split(' ')[1],
                    UserName = l[0].Split(' ')[2],
                    Created = DateImport(l[0].Split(' ')[3]),
                    Method = l[1].Split(' ')[0],
                    Url = l[1].Split(' ')[1],
                    HttpVersion = l[1].Split(' ')[2],
                    HttpCode = l[2].Split(' ')[1].TryParseInt(),
                    Port = l[2].Split(' ')[2].TryParseInt(),
                    UrlDestination = l.Length >= 4 ? l[3] : string.Empty,
                    BrowserAgent = l.Length >= 6 ? l[5] : string.Empty,
                }
                ).ToList(); 

            PostRange(logsSelected);
        }
        
        public List<Log> PostRange(List<Log> objs)
        {
            repository.AddRange(objs);
            return objs;
        }

        private static DateTime DateImport(string strDate)
        {
            strDate = strDate.Replace("[", "").Replace("\"", "");
            var date = new DateTime(Convert.ToInt32(strDate.Substring(7, 4)), //Year
                                    DateTime.ParseExact(strDate.Substring(3, 3), "MMM", System.Globalization.CultureInfo.InvariantCulture).Month, //Month
                                    Convert.ToInt32(strDate.Substring(0, 2)), //Day
                                    Convert.ToInt32(strDate.Substring(12, 2)), //Hour
                                    Convert.ToInt32(strDate.Substring(15, 2)), //Minute
                                    Convert.ToInt32(strDate.Substring(18, 2))); //Second
            return date;
        }
    }
}
