using Sitecore.Data.Items;
using Sitecore.Strategy.Adaptive.MacroSelectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Strategy.Adaptive.Config
{
    public interface IMacroSelectorConfigForItem
    {
        bool DoesApplyToItem(Item item);
        IMacroSelectorForItem GetTreeSelector(Item item);
        IMacroSelectorForItem GetOperatorSelector(Item item);
        IMacroSelectorForItem GetValueSelector(Item item);
    }
}
