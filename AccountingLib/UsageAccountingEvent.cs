using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLib
{
    public class UsageAccountingEvent : AccountingEvent
    {
        public decimal Amount { get; private set; }

        public UsageAccountingEvent(int amount, DateTime whenOccurred, DateTime whenNoticed, Customer customer)
            : base(new AccountingEventType(), whenOccurred, whenNoticed, customer)
        {
            this.Amount = amount;
        }

        public double GetRate()
        {
            var serviceAgreement = Customer.ServiceAgreement;
            return serviceAgreement.Rate;
        }
    }
}
