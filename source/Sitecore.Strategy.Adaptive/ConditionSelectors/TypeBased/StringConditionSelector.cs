using Sitecore.Data;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.Strategy.Adaptive.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.ConditionSelectors.TypeBased
{
    public class StringConditionSelector : IConditionSelectorForType
    {
        public virtual bool DoesApplyToType(Type type)
        {
            if (typeof(string) == type)
            {
                return true;
            }
            return false;
        }

        public RuleCondition<T> GetCondition<T>(Type type, AdaptiveConditionBase<T> adaptiveCondition, T ruleContext) where T : RuleContext
        {
            var condition = new StringCompareCondition<T>();
            var left = adaptiveCondition.GetLeftValue(ruleContext);
            if (left != null) 
            {
                condition.LeftValue = left.ToString();
            }
            var right = adaptiveCondition.GetRightValue(ruleContext);
            if (right != null) 
            {
                condition.RightValue = right.ToString();
            }
            condition.OperatorId = adaptiveCondition.Operator.ToString();
            return condition;
        }
    }
}