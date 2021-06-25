using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eval.API.DTO
{
    public class CreateMatchDto
    {
        public DateTime Date { get; set; }
        public string OpponentName { get; set; }
        public string ReasonForLoss { get; set; }
    }
}
