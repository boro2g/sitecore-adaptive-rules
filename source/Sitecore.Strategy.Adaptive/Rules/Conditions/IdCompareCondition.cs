using Sitecore.Data;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.Rules.Conditions
{
    public class IdCompareCondition<T> : StringCompareCondition<T> where T : RuleContext
    {
        protected override bool Execute(T ruleContext)
        {
            if (! ID.IsID(this.LeftValue) || ! ID.IsID(this.RightValue))
            {
                return false;
            }
            var left = new ID(this.LeftValue).ToString();
            var right = new ID(this.RightValue).ToString();
            return base.Compare(left, right);
        }

    }
}