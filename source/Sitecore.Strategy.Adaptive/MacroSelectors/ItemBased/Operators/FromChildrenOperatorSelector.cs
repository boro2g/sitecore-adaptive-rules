using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Rules.RuleMacros;
using Sitecore.Strategy.Adaptive.Rules.RuleMacros;
using Sitecore.Strategy.Adaptive.Rules.RuleMacros.Manual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.MacroSelectors.ItemBased.Operators
{
    public class FromChildrenOperatorSelector : IMacroSelectorForItem
    {
        public string OperatorsFolderId { get; set; }
        public virtual bool DoesApplyToItem(Item item)
        {
            if (item == null)
            {
                return false;
            }
            return item.HasChildren;
        }
        public virtual IRuleMacro GetMacro(Item item)
        {
            Assert.ArgumentNotNull(item, "item");
            if (!item.HasChildren)
            {
                return null;
            }
            Assert.IsNotNullOrEmpty(this.OperatorsFolderId, "OperatorsFolderId must have a value");
            Assert.IsTrue(ID.IsID(this.OperatorsFolderId), "OperatorsFolderId must be a valid ID");
            var folderId = new ID(this.OperatorsFolderId);
            var folderItem = Sitecore.Client.ContentDatabase.GetItem(folderId);
            Assert.IsNotNull(folderItem, string.Format("Cannot locate the item {0} which was specified for OperatorsFolderId", this.OperatorsFolderId));
            var macro = new ManualTreeMacro();
            macro.RootItem = folderItem;
            macro.DefaultWindowIcon = folderItem.Appearance.Icon;
            macro.DefaultWindowTitle = "Select Operator";
            macro.DefaultWindowText = "Select the operator to use in the rule";
            return macro;
        }
    }
}