using Sitecore.Data.Items;
using Sitecore.Rules.RuleMacros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Strategy.Adaptive.MacroSelectors
{
    public interface IMacroSelectorForType
    {
        bool DoesApplyToType(Type type);
        IRuleMacro GetMacro(Type type);
    }
}
