using Sitecore.Diagnostics;
using Sitecore.Strategy.Adaptive.DataTypeResolvers;
using Sitecore.Strategy.Adaptive.Providers;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Sitecore.Strategy.Adaptive.Rules.RuleMacros
{
    public class AdaptiveValueMacro : AdaptiveMacroBase
    {
        public override void Execute(XElement element, string name, UrlString parameters, string value)
        {
            if (!this.IsValueSet(element, name, parameters, value))
            {
                value = string.Empty;
            }
            var macro = AdaptiveManager.Provider.GetValueMacro(element, name, parameters);
            if (macro != null)
            {
                macro.Execute(element, name, parameters, value);
                return;
            }
            SheerResponse.Input("Enter value", value);
        }
    }
}