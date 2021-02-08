using System;

namespace BenFatto.Domain.Entities
{
    public class Log : BaseEntity
    {
        public string SourceIP { get; set; }
        public string Channel { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public string Method { get; set; }
        public string Url { get; set; }
        public string HttpVersion { get; set; }
        public int HttpCode { get; set; }
        public string UrlDestination { get; set; }
        public int? Port { get; set; }
        public string BrowserAgent { get; set; }

    }
}
