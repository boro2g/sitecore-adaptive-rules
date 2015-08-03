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
    public class StringConditionSelector : ConditionSelectorForTypeBase
    {
        public StringConditionSelector() 
            :base(typeof (string))
        {
        }

        public override RuleCondition<T> GetCondition<T>(Type type, AdaptiveConditionBase<T> adaptiveCondition, T ruleContext) 
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
            if (adaptiveCondition.Operator == Sitecore.Strategy.Adaptive.Items.ItemIDs.BooleanOperatorTrue)
            {
                adaptiveCondition.Operator = Sitecore.Strategy.Adaptive.Items.ItemIDs.StringOperatorTrue;
            }
            else if (adaptiveCondition.Operator == Sitecore.Strategy.Adaptive.Items.ItemIDs.BooleanOperatorFalse)
            {
                adaptiveCondition.Operator = Sitecore.Strategy.Adaptive.Items.ItemIDs.StringOperatorFalse;
            }
            condition.OperatorId = adaptiveCondition.Operator.ToString();
            return condition;
        }
    }
}