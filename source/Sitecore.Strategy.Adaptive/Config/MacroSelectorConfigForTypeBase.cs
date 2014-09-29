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
            this.OperatorSelectors = new List<IMacroSelectorForType>();
            this.ValueSelectors = new List<IMacroSelectorForType>();
            this.ConditionSelectors = new List<IConditionSelectorForType>();
        }
        public abstract bool DoesApplyToType(Type type);
        public List<IMacroSelectorForType> OperatorSelectors { get; private set; }
        public List<IMacroSelectorForType> ValueSelectors { get; private set; }
        public List<IConditionSelectorForType> ConditionSelectors { get; private set; }
        protected virtual void AddSelector(IMacroSelectorForType selector, List<IMacroSelectorForType> list)
        {
            Assert.ArgumentNotNull(selector, "selector");
            Assert.ArgumentNotNull(list, "list");
            if (list.Contains(selector))
            {
                return;
            }
            list.Add(selector);
        }
        protected virtual IMacroSelectorForType GetSelector(Type type, List<IMacroSelectorForType> list)
        {
            Assert.ArgumentNotNull(type, "type");
            Assert.ArgumentNotNull(list, "list");
            foreach (var selector in list)
            {
                if (selector.DoesApplyToType(type))
                {
                    return selector;
                }
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
            if (this.ConditionSelectors.Contains(selector))
            {
                return;
            }
            this.ConditionSelectors.Add(selector);
        }
        public virtual IConditionSelectorForType GetConditionSelector(Type type)
        {
            foreach (var selector in this.ConditionSelectors)
            {
                if (selector.DoesApplyToType(type))
                {
                    return selector;
                }
            }
            return null;
        }
    }
}