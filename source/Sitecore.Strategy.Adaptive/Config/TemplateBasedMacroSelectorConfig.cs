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
    public class TemplateBasedMacroSelectorConfig : MacroSelectorConfigForItemBase
    {
        public string TemplateId { get; set; }
        public override bool DoesApplyToItem(Item item)
        {
            if (item == null 
            ||  string.IsNullOrEmpty(this.TemplateId) 
            ||  !ID.IsID(this.TemplateId))
            {
                return false;
            }

            var id = new ID(this.TemplateId);

            return (item.TemplateID.Equals(id));
        }
    }
}