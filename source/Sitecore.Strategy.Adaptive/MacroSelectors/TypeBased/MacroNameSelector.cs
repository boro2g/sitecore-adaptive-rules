using Sitecore.CodeDom.Scripts;
using Sitecore.Rules;
using Sitecore.Rules.RuleMacros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.MacroSelectors.TypeBased
{
    public class MacroNameSelector : IMacroSelectorForType
    {
        public string MacroName { get; set; }
        public virtual bool DoesApplyToType(Type type)
        {
            return true;
        }
        public virtual IRuleMacro GetMacro(Type type)
        {
            var macroItem = Sitecore.Client.ContentDatabase.GetItem(RuleIds.MacrosesFolder).Axes.SelectSingleItem(this.MacroName);
            if (macroItem == null)
            {
                return null;
            }
            var macro = ItemScripts.CreateObject(macroItem) as IRuleMacro;
            return macro;
        }
    }
}