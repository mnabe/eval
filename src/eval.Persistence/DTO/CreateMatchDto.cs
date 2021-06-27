using System;

namespace eval.Persistence.DTO
{
    public class CreateMatchDto
    {
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string OpponentName { get; set; }
        public string ReasonForLoss { get; set; }
    }
}
