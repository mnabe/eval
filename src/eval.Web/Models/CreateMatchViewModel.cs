﻿using System;

namespace eval.Web.Models
{
    public class CreateMatchViewModel
    {
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string OpponentName { get; set; }
        public string ReasonForLoss { get; set; }
    }
}
