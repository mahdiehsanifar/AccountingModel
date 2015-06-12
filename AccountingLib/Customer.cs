using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLib
{
    public class Customer
    {
        public ServiceAgreement ServiceAgreement { get; set; }

        private List<Entry> entries = new List<Entry>();

        public Customer()
        {

        }

        public void AddEntry(Entry entry)
        {
            entries.Add(entry);
        }

        public List<Entry> GetEntries()
        {
            return entries.ToList();
        }
    }
}
