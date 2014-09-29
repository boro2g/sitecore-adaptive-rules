using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Rules.RuleMacros;
using Sitecore.Strategy.Adaptive.Rules.RuleMacros;
using Sitecore.Strategy.Adaptive.Rules.RuleMacros.Manual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.MacroSelectors.ItemBased.Trees
{
    public class DefaultTreeSelector : IMacroSelectorForItem
    {
        public virtual bool DoesApplyToItem(Item item)
        {
            if (item == null)
            {
                return false;
            }
            return true;
        }
        public virtual IRuleMacro GetMacro(Item item)
        {
            Assert.ArgumentNotNull(item, "item");
            if (!item.HasChildren)
            {
                return null;
            }
            var macro = new ManualTreeMacro();
            macro.RootItem = item;
            return macro;
        }
    }
}