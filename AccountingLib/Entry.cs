using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLib
{
    public class Entry
    {
        public DateTime Date { get; private set; }
        
        public EntryType Type { get; private set; }
        
        public decimal Amount { get; private set; }

        public Entry(decimal amount, DateTime date, EntryType type)
        {
            this.Amount = amount;
            this.Date = Date;
            this.Type = type;
        }
    }
}
