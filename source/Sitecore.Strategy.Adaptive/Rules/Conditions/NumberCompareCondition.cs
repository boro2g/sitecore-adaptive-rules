using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.Rules.Conditions
{
    public class NumberCompareCondition<T> : OperatorCondition<T> where T : RuleContext
    {
        public float LeftValue { get; set; }
        public float RightValue { get; set; }
        
        protected virtual bool Compare(float leftValue, float rightValue)
        {
            switch (base.GetOperator())
            {
                case ConditionOperator.Equal:
                    return (leftValue == rightValue);

                case ConditionOperator.GreaterThanOrEqual:
                    return (leftValue >= rightValue);

                case ConditionOperator.GreaterThan:
                    return (leftValue > rightValue);

                case ConditionOperator.LessThanOrEqual:
                    return (leftValue <= rightValue);

                case ConditionOperator.LessThan:
                    return (leftValue < rightValue);

                case ConditionOperator.NotEqual:
                    return (leftValue != rightValue);
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