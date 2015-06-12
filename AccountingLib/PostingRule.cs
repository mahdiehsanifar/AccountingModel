using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLib
{
    abstract public class PostingRule
    {
        protected EntryType entryType;

        public PostingRule()
        {

        }

        protected PostingRule(EntryType entryType)
        {
            this.entryType = entryType;
        }

        private void MakeEntry(AccountingEvent accountingEvent, decimal amount)
        {
            var newEntry = new Entry(amount, accountingEvent.WhenNoticed, entryType);
            accountingEvent.Customer.AddEntry(newEntry);
            accountingEvent.AddResultingEntry(newEntry);
        }

        public void Process(AccountingEvent accountingEvent)
        {
            var amount = CalculateAmount(accountingEvent);
            MakeEntry(accountingEvent, amount);
        }

        abstract protected decimal CalculateAmount(AccountingEvent accountingEvent);
    }
}
