using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.Strategy.Adaptive.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Strategy.Adaptive.ConditionSelectors.TypeBased
{
    public interface IConditionSelectorForType
    {
        bool DoesApplyToType(Type type);
        HashSet<Type> ApplicableTypes { get; }
        RuleCondition<T> GetCondition<T>(Type type, AdaptiveConditionBase<T> adaptiveCondition, T ruleContext) where T:RuleContext;
    }
}
