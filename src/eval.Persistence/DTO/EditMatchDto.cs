﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eval.Persistence.DTO
{
    public class EditMatchDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string OpponentName { get; set; }
        public string ReasonForLoss { get; set; }
    }
}