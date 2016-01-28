using System;
using Sitecore.Rules.Conditions;
using Sitecore.Strategy.Adaptive.Rules.Conditions;

namespace Sitecore.Strategy.Adaptive.ConditionSelectors.TypeBased
{
    public class BooleanConditionSelector : ConditionSelectorForTypeBase
    {
        public BooleanConditionSelector() 
            : base(typeof(bool))
        {
        }

        public override RuleCondition<T> GetCondition<T>(Type type, AdaptiveConditionBase<T> adaptiveCondition, T ruleContext)
        {
            var condition = new BooleanCompareCondition<T>();
            var left = adaptiveCondition.GetLeftValue(ruleContext);
            if (left != null)
            {
                condition.LeftValue = Parse(left.ToString());
            }
            var right = adaptiveCondition.GetRightValue(ruleContext);
            if (right != null)
            {
                condition.RightValue = Parse(right.ToString());;
            }
            condition.OperatorId = adaptiveCondition.Operator.ToString();
            return condition;
        }

        private bool Parse(string value)
        {
            value = value.Substring(value.LastIndexOf("-") + 1);

            bool result;

            if (bool.TryParse(value, out result))
            {
                return result;
            }

            return false;
        }
    }
}