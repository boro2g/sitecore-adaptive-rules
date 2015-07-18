using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Strategy.Adaptive.ConditionSelectors.TypeBased;
using Sitecore.Strategy.Adaptive.MacroSelectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.Config
{
    public abstract class MacroSelectorConfigForTypeBase : IMacroSelectorConfigForType
    {
        public MacroSelectorConfigForTypeBase()
        {
            this.OperatorSelectors = new Dictionary<Type,IMacroSelectorForType>();
            this.ValueSelectors = new Dictionary<Type, IMacroSelectorForType>();
            this.ConditionSelectors = new Dictionary<Type, IConditionSelectorForType>();
        }
        public abstract bool DoesApplyToType(Type type);
        public abstract HashSet<Type> ApplicableTypes { get; }

        public Dictionary<Type, IMacroSelectorForType> OperatorSelectors { get; private set; }
        public Dictionary<Type, IMacroSelectorForType> ValueSelectors { get; private set; }
        public Dictionary<Type, IConditionSelectorForType> ConditionSelectors { get; private set; }

        protected virtual void AddSelector(IMacroSelectorForType selector, Dictionary<Type, IMacroSelectorForType> list)
        {
            Assert.ArgumentNotNull(selector, "selector");
            Assert.ArgumentNotNull(list, "list");

            foreach (var type in selector.ApplicableTypes)
            {
                if (!list.ContainsKey(type))
                {
                    list.Add(type, selector);
                }
            }
        }
    
        protected virtual IMacroSelectorForType GetSelector(Type type, Dictionary<Type, IMacroSelectorForType> list)
        {
            Assert.ArgumentNotNull(type, "type");
            Assert.ArgumentNotNull(list, "list");

            if (list.ContainsKey(type))
            {
                return list[type];
            }
            if (list.ContainsKey(typeof(System.Object)))
            {
                return list[typeof(System.Object)];
            }
            return null;
        }

        public virtual void AddOperatorSelector(IMacroSelectorForType selector)
        {
            AddSelector(selector, this.OperatorSelectors);
        }
        public virtual IMacroSelectorForType GetOperatorSelector(Type type)
        {
            return GetSelector(type, this.OperatorSelectors);
        }
        public virtual void AddValueSelector(IMacroSelectorForType selector)
        {
            AddSelector(selector, this.ValueSelectors);
        }
        public virtual IMacroSelectorForType GetValueSelector(Type type)
        {
            return GetSelector(type, this.ValueSelectors);
        }

        public virtual void AddConditionSelector(IConditionSelectorForType selector)
        {
            Assert.ArgumentNotNull(selector, "selector");
            foreach (var type in selector.ApplicableTypes)
            {
                if (!this.ConditionSelectors.ContainsKey(type))
                {
                    this.ConditionSelectors[type] = selector;
                }
            }
        }
        public virtual IConditionSelectorForType GetConditionSelector(Type type)
        {
            if (this.ConditionSelectors.ContainsKey(type))
            {
                return this.ConditionSelectors[type];
            }
            return null;
        }
    }
}