using Sitecore.Data.Items;
using Sitecore.Strategy.Adaptive.ConditionSelectors.TypeBased;
using Sitecore.Strategy.Adaptive.MacroSelectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Strategy.Adaptive.Config
{
    public interface IMacroSelectorConfigForType
    {
        bool DoesApplyToType(Type type);
        HashSet<Type> ApplicableTypes { get; }
        IMacroSelectorForType GetOperatorSelector(Type type);
        IMacroSelectorForType GetValueSelector(Type type);
        IConditionSelectorForType GetConditionSelector(Type type);
    }
}
