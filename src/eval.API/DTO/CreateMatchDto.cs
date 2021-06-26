using System;

namespace eval.API.DTO
{
    public class CreateMatchDto
    {
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string OpponentName { get; set; }
        public string ReasonForLoss { get; set; }
    }
}
