using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Rules.RuleMacros;
using Sitecore.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Sitecore.Strategy.Adaptive.Rules.RuleMacros
{
    public abstract class AdaptiveMacroBase : IAdaptiveMacro
    {
        public Item DependecyItem { get; set; }
        public abstract void Execute(XElement element, string name, UrlString parameters, string value);
        protected virtual bool IsValueSet(XElement element, string name, UrlString parameters, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            if (parameters != null && value.Equals(parameters.ToString()))
            {
                return false;
            }
            return true;
        }
    }
}