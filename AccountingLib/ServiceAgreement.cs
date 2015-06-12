using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLib
{
    public class ServiceAgreement
    {
        public double Rate { get; set; }

        private Dictionary<AccountingEventType, Dictionary<DateTime, PostingRule>> postingRuleDic;

        public ServiceAgreement()
        {
            postingRuleDic = new Dictionary<AccountingEventType, Dictionary<DateTime, PostingRule>>();
        }

        public void AddPostingRule(AccountingEventType eventType, PostingRule rule, DateTime date)
        {
            Dictionary<DateTime, PostingRule> datePostingRuleDic = null;
            postingRuleDic.TryGetValue(eventType, out datePostingRuleDic);
            if (datePostingRuleDic == null)
            {
                datePostingRuleDic = new Dictionary<DateTime, PostingRule>();
                postingRuleDic.Add(eventType, datePostingRuleDic);
            }
            else if (datePostingRuleDic.ContainsKey(date))
                throw new Exception("Posting rule already exists!");

            datePostingRuleDic.Add(date, rule);
        }

        public PostingRule GetPostingRule(AccountingEventType eventType, DateTime when)
        {
            Dictionary<DateTime, PostingRule> datePostingRuleDic = null;
            postingRuleDic.TryGetValue(eventType, out datePostingRuleDic);
            PostingRule postingRule = null;
            datePostingRuleDic.TryGetValue(when, out postingRule);
            if (postingRule == null)
                throw new Exception("Posting rule not found!");

            return postingRule;
        }
    }
}
