using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Rules.RuleMacros;
using Sitecore.Strategy.Adaptive.MacroSelectors;
using Sitecore.Strategy.Adaptive.Rules.RuleMacros;
using Sitecore.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Sitecore.Strategy.Adaptive.Config
{
    public class MacroConfiguration
    {
        public MacroConfiguration()
        {
            this.MacroSelectorConfigsForItem = new List<IMacroSelectorConfigForItem>();
            this.MacroSelectorConfigsForType = new List<IMacroSelectorConfigForType>();
        }
        public IMacroSelectorForItem DefaultTreeSelector { get; set; }

        public List<IMacroSelectorConfigForItem> MacroSelectorConfigsForItem { get; private set; }
        public virtual void AddMacroSelectorConfig(IMacroSelectorConfigForItem config)
        {
            if (this.MacroSelectorConfigsForItem.Contains(config))
            {
                return;
            }
            this.MacroSelectorConfigsForItem.Add(config);
        }
        public virtual IMacroSelectorConfigForItem GetMacroSelectorConfig(Item item)
        {
            foreach (var selector in this.MacroSelectorConfigsForItem)
            {
                if (selector.DoesApplyToItem(item))
                {
                    return selector;
                }
            }
            return null;
        }

        public List<IMacroSelectorConfigForType> MacroSelectorConfigsForType { get; private set; }
        public virtual void AddMacroSelectorConfig(IMacroSelectorConfigForType config)
        {
            if (this.MacroSelectorConfigsForType.Contains(config))
            {
                return;
            }
            this.MacroSelectorConfigsForType.Add(config);
        }
        public virtual IMacroSelectorConfigForType GetMacroSelectorConfig(Type type)
        {
            foreach (var selector in this.MacroSelectorConfigsForType)
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