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
        private HashSet<Type> _applicableTypes = new HashSet<Type>();

        public string TypeName { get; set; }

        public override bool DoesApplyToType(Type type)
        {
            return this.ApplicableTypes.Contains(type);
        }

        public override HashSet<Type> ApplicableTypes
        {
            get
            {
                if (_applicableTypes.Count == 0
                && !string.IsNullOrEmpty(this.TypeName))
                {
                    _applicableTypes.Add(Type.GetType(this.TypeName));
                }
                return _applicableTypes;
            }
        }
    }
}