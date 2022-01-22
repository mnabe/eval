using eval.Domain.Enums;
using System;

namespace eval.Persistence
{
    public class MatchEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string OpponentName { get; set; }
        public string TimeControl { get; set; }
        public Color Color { get; set; }
        public string Opening { get; set; }
        public string ReasonForLoss { get; set; }
        public string SiteForMatch { get; set; }
    }
}
