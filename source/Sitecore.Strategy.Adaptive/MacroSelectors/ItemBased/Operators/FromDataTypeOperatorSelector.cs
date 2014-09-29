using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.RuleMacros;
using Sitecore.Strategy.Adaptive.DataTypeResolvers;
using Sitecore.Strategy.Adaptive.Providers;
using Sitecore.Strategy.Adaptive.Rules.RuleMacros.Manual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.MacroSelectors.ItemBased.Operators
{
    public class FromDataTypeOperatorSelector : IMacroSelectorForItem
    {
        public IDataTypeResolver DataTypeResolver { get; set; }
        protected virtual Type GetDataType(Item item)
        {
            if (item == null || this.DataTypeResolver == null)
            {
                return null;
            }
            return this.DataTypeResolver.GetDataType(item);
        }
        public virtual bool DoesApplyToItem(Item item)
        {
            var type = GetDataType(item);
            return (type != null);
        }
        public virtual IRuleMacro GetMacro(Item item)
        {
            var type = GetDataType(item);
            if (type == null)
            {
                return null;
            }
            var macro = AdaptiveManager.Provider.GetOperatorMacro(type);
            return macro;
        }
    }
}