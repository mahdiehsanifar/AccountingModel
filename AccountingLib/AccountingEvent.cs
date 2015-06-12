using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLib
{
    public class AccountingEvent
    {
        public AccountingEventType Type { get; private set; }

        public DateTime WhenOccurred { get; private set; }

        public DateTime WhenNoticed { get; private set; }

        public Customer Customer { get; private set; }

        private List<Entry> resultingEntries = new List<Entry>();

        public AccountingEvent()
        {

        }

        public AccountingEvent(AccountingEventType type, DateTime whenOccurred, DateTime whenNoticed, Customer customer)
        {
            this.Type = type;
            this.WhenOccurred = whenOccurred;
            this.WhenNoticed = whenNoticed;
            this.Customer = customer;
        }

        public void AddResultingEntry(Entry entry)
        {
            resultingEntries.Add(entry);
        }

        public void Process()
        {
            var rule = FindRule();
            rule.Process(this);
        }

        PostingRule FindRule()
        {
            var customerServiceAgreement = Customer.ServiceAgreement;
            var rule = customerServiceAgreement.GetPostingRule(this.Type, this.WhenOccurred);

            return rule;
        }
    }
}
