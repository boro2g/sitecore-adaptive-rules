using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Strategy.Adaptive.MacroSelectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.Config
{
    public abstract class MacroSelectorConfigForItemBase : IMacroSelectorConfigForItem
    {
        public MacroSelectorConfigForItemBase()
        {
            this.TreeSelectors = new List<IMacroSelectorForItem>();
            this.OperatorSelectors = new List<IMacroSelectorForItem>();
            this.ValueSelectors = new List<IMacroSelectorForItem>();
        }
        public abstract bool DoesApplyToItem(Item item);
        public List<IMacroSelectorForItem> TreeSelectors { get; private set; }
        public List<IMacroSelectorForItem> OperatorSelectors { get; private set; }
        public List<IMacroSelectorForItem> ValueSelectors { get; private set; }
        protected virtual void AddSelector(IMacroSelectorForItem selector, List<IMacroSelectorForItem> list)
        {
            Assert.ArgumentNotNull(selector, "selector");
            Assert.ArgumentNotNull(list, "list");
            if (list.Contains(selector))
            {
                return;
            }
            list.Add(selector);
        }
        protected virtual IMacroSelectorForItem GetSelector(Item item, List<IMacroSelectorForItem> list)
        {
            Assert.ArgumentNotNull(item, "item");
            Assert.ArgumentNotNull(list, "list");
            foreach (var selector in list)
            {
                if (selector.DoesApplyToItem(item))
                {
                    return selector;
                }
            }
            return null;
        }

        public virtual void AddTreeSelector(IMacroSelectorForItem selector)
        {
            AddSelector(selector, this.TreeSelectors);
        }
        public virtual IMacroSelectorForItem GetTreeSelector(Item item)
        {
            return GetSelector(item, this.TreeSelectors);
        }
        public virtual void AddOperatorSelector(IMacroSelectorForItem selector)
        {
            AddSelector(selector, this.OperatorSelectors);
        }
        public virtual IMacroSelectorForItem GetOperatorSelector(Item item)
        {
            return GetSelector(item, this.OperatorSelectors);
        }
        public virtual void AddValueSelector(IMacroSelectorForItem selector)
        {
            AddSelector(selector, this.ValueSelectors);
        }
        public virtual IMacroSelectorForItem GetValueSelector(Item item)
        {
            return GetSelector(item, this.ValueSelectors);
        }
    }
}