using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.Strategy.Adaptive.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.Rules.Conditions
{
    public abstract class AdaptiveConditionBase<T> : RuleCondition<T> where T : RuleContext
    {
        public abstract object GetLeftValue(T ruleContext);
        public abstract object GetRightValue(T ruleContext);
        public abstract Type GetDataType(T ruleContext);

        public ID Operator { get; set; }
        public string Value { get; set; }

        protected virtual RuleCondition<T> GetCondition(T ruleContext, RuleStack stack)
        {
            var type = GetDataType(ruleContext);
            if (type == null)
            {
                return null;
            }
            var condition = AdaptiveManager.Provider.GetRuleCondition<T>(type, this, ruleContext);
            return condition;
        }
        
        public override void Evaluate(T ruleContext, RuleStack stack)
        {
            var condition = GetCondition(ruleContext, stack);
            if (condition == null)
            {
                stack.Push(false);
                return;
            }
            condition.UniqueId = this.UniqueId;
            condition.Evaluate(ruleContext, stack);
        }
    }
}