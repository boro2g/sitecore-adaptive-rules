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

namespace Sitecore.Strategy.Adaptive.MacroSelectors.ItemBased.Values
{
    public class FromChildrenValueSelector : IMacroSelectorForItem
    {
        public virtual bool DoesApplyToItem(Item item)
        {
            if (item == null)
            {
                return false;
            }
            return item.HasChildren;
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
            macro.DefaultWindowIcon = item.Appearance.Icon;
            macro.DefaultWindowTitle = "Select Value";
            macro.DefaultWindowText = "Select the value to use in the rule";
            return macro;
        }
    }
}