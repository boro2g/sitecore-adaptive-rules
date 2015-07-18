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
            this.MacroSelectorConfigsForItem = new HashSet<IMacroSelectorConfigForItem>();
            this.MacroSelectorConfigsForType = new Dictionary<Type, IMacroSelectorConfigForType>();
        }
        public IMacroSelectorForItem DefaultTreeSelector { get; set; }

        private readonly HashSet<Type> _numericTypes = new HashSet<Type>()
        {
                typeof(short),
                typeof(ushort) , 
                typeof(int) , 
                typeof(uint) ,
                typeof(long) ,
                typeof(ulong) , 
                typeof(float) ,
                typeof(double)         
        };
     
        
        public HashSet<IMacroSelectorConfigForItem> MacroSelectorConfigsForItem { get; private set; }
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

        public Dictionary<Type, IMacroSelectorConfigForType> MacroSelectorConfigsForType { get; private set; }
        public virtual void AddMacroSelectorConfig(IMacroSelectorConfigForType config)
        {
            foreach (var type in config.ApplicableTypes)
            {
                foreach (var explodedType in ExplodeType(type))
                {
                    if (!this.MacroSelectorConfigsForType.ContainsKey(explodedType))
                    {
                        this.MacroSelectorConfigsForType.Add(explodedType, config);
                    }
                }
            }
        }

        public virtual IMacroSelectorConfigForType GetMacroSelectorConfig(Type type)
        {
            if (this.MacroSelectorConfigsForType.ContainsKey(type))
            {
                return this.MacroSelectorConfigsForType[type];
            }
            if (this.MacroSelectorConfigsForType.ContainsKey(typeof(System.Object)))
            {
                return this.MacroSelectorConfigsForType[typeof(System.Object)];
            }
            
            return null;
        }

        public virtual IEnumerable<Type> ExplodeType(Type type)
        {
            if (_numericTypes.Contains(type))
            {
                return _numericTypes;
            }
            return new Type[] {type};
        }
    }
}