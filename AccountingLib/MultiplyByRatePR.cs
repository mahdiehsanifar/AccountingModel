using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLib
{
    public class MultiplyByRatePR : PostingRule
    {
        public MultiplyByRatePR(EntryType entryType)
            : base(entryType)
        {
            
        }

        protected override decimal CalculateAmount(AccountingEvent accountingEvent)
        {
            UsageAccountingEvent usageEvent = (UsageAccountingEvent)accountingEvent;
            //??
            var result = usageEvent.Amount * (decimal)usageEvent.GetRate();

            return result;
        }
    }
}
