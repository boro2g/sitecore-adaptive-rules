using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.Rules.Conditions
{
    public class StringCompareCondition<T> : StringOperatorCondition<T> where T : RuleContext
    {
        public string LeftValue { get; set; }
        public string RightValue { get; set; }
        protected override bool Execute(T ruleContext)
        {
            return base.Compare(this.LeftValue, this.RightValue);
        }

    }
}