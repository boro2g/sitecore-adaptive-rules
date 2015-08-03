using System;
using System.Collections.Generic;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.Strategy.Adaptive.Rules.Conditions;

namespace Sitecore.Strategy.Adaptive.ConditionSelectors.TypeBased
{
    public abstract class ConditionSelectorForTypeBase : IConditionSelectorForType
    {
        protected ConditionSelectorForTypeBase () : this(new HashSet<Type>())
        { 
        }

        protected ConditionSelectorForTypeBase(Type type)
            : this(new HashSet<Type>(){type})
        {
        }

        protected ConditionSelectorForTypeBase(HashSet<Type> types)
        {
            ApplicableTypes = types;
        }

        public abstract RuleCondition<T> GetCondition<T>(Type type, AdaptiveConditionBase<T> adaptiveCondition,
            T ruleContext) where T : RuleContext;


        public virtual bool DoesApplyToType(Type type)
        {
            return this.ApplicableTypes.Contains(type);
        }

        public HashSet<Type> ApplicableTypes
        {
            get; 
            protected set;
        }
    }
}