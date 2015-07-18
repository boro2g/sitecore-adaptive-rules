using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.Rules.Conditions
{
    public class DateTimeCompareCondition<T> : OperatorCondition<T> where T : RuleContext
    {
        public DateTime LeftValue { get; set; }
        public DateTime RightValue { get; set; }

        protected virtual bool Compare(DateTime leftValue, DateTime rightValue)
        {
            var diffInMinutes = DateUtil.CompareDatesIgnoringSeconds(leftValue, RightValue);

            switch (base.GetOperator())
            {
                case ConditionOperator.Equal:
                    return diffInMinutes == 0;

                case ConditionOperator.NotEqual:
                    return diffInMinutes != 0;

                case ConditionOperator.GreaterThanOrEqual:
                    return diffInMinutes >= 0;

                case ConditionOperator.GreaterThan:
                    return diffInMinutes > 0;

                case ConditionOperator.LessThanOrEqual:
                    return diffInMinutes <= 0;

                case ConditionOperator.LessThan:
                    return diffInMinutes < 0;

            }
            return false;
        }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");
            return this.Compare(this.LeftValue, this.RightValue);
        }
    }
}