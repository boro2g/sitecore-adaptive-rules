using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Rules;
using Sitecore.Rules.RuleMacros;
using Sitecore.Strategy.Adaptive.Providers;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Sitecore.Strategy.Adaptive.Rules.RuleMacros
{
    public class AdaptiveTreeMacro : AdaptiveMacroBase
    {
        public override void Execute(XElement element, string name, UrlString parameters, string value)
        {
            var macro = AdaptiveManager.Provider.GetTreeMacro(element, name, parameters);
            if (macro != null)
            {
                macro.Execute(element, name, parameters, value);
                return;
            }
            SheerResponse.Alert("No tree macro could be resolved.");
        }
    }
}