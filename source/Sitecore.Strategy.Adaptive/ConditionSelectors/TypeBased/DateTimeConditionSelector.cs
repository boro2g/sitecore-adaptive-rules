using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.Strategy.Adaptive.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.ConditionSelectors.TypeBased
{
    public class DateTimeConditionSelector : IConditionSelectorForType
    {
        public virtual bool DoesApplyToType(Type type)
        {
            if (typeof(DateTime) == type)
            {
                return true;
            }
            return false;
        }

        public RuleCondition<T> GetCondition<T>(Type type, AdaptiveConditionBase<T> adaptiveCondition, T ruleContext) where T : RuleContext
        {
            throw new NotImplementedException();
        }
    }
}