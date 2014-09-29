using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Strategy.Adaptive.MacroSelectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.Config
{
    public class TypeBasedMacroSelectorConfig : MacroSelectorConfigForTypeBase
    {
        public string TypeName { get; set; }
        public override bool DoesApplyToType(Type type)
        {
            if (type == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(this.TypeName))
            {
                return false;
            }
            var type2 = Type.GetType(this.TypeName);
            if (type2 == null)
            {
                return false;
            }
            if (type.Equals(type2))
            {
                return true;
            }
            return false;
        }
    }
}