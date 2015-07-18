using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.Strategy.Adaptive.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.ConditionSelectors.TypeBased
{
    public class DateTimeConditionSelector : ConditionSelectorForTypeBase
    {
        public DateTimeConditionSelector() 
            : base(typeof(DateTime))
        {
        }

        public override RuleCondition<T> GetCondition<T>(Type type, AdaptiveConditionBase<T> adaptiveCondition, T ruleContext) 
        {
            var condition = new DateTimeCompareCondition<T>();
            var left = adaptiveCondition.GetLeftValue(ruleContext);
            if (left != null)
            {
                condition.LeftValue = DateUtil.ParseDateTime(left.ToString(), DateTime.MinValue);
            }
            var right = adaptiveCondition.GetRightValue(ruleContext);
            if (right != null)
            {
                condition.RightValue = DateUtil.ParseDateTime(right.ToString(), DateTime.MinValue);
            }
            condition.OperatorId = adaptiveCondition.Operator.ToString();
            return condition;
        }
    }
}