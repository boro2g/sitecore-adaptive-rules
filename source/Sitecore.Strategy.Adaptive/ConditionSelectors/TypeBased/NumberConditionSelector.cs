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
    public class NumberConditionSelector : IConditionSelectorForType
    {
        public virtual bool DoesApplyToType(Type type)
        {
            if (typeof(short) == type || 
                typeof(ushort) == type || 
                typeof(int) == type || 
                typeof(uint) == type || 
                typeof(long) == type || 
                typeof(ulong) == type || 
                typeof(float) == type ||
                typeof(double) == type)
            {
                return true;
            }
            return false;
        }

        public RuleCondition<T> GetCondition<T>(Type type, AdaptiveConditionBase<T> adaptiveCondition, T ruleContext) where T : RuleContext
        {
            var condition = new NumberCompareCondition<T>();
            var left = adaptiveCondition.GetLeftValue(ruleContext);
            if (left != null) 
            {
                condition.LeftValue = float.Parse(left.ToString());
            }
            var right = adaptiveCondition.GetRightValue(ruleContext);
            if (right != null) 
            {
                condition.RightValue= float.Parse(right.ToString());
            }
            condition.OperatorId = adaptiveCondition.Operator.ToString();
            return condition;
        }
    }
}