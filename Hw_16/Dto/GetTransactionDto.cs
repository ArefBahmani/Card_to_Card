﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardBankTransaction_HW_15.Dto
{
    public class GetTransactionDto
    {
        public string SourceCardNumber { get; set; }
        public string DestinationsCardNumber { get; set; }
        public DateTime AtTime { get; set; }
        public float Amount { get; set; }
        public bool IsSuccess { get; set; }
        
    }
}
