﻿using System;

namespace eval.Domain
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string OpponentName { get; set; }
        public string ReasonForLoss { get; set; }
    }
}