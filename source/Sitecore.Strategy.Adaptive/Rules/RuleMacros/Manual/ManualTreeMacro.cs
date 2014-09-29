using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Rules.RuleMacros;
using Sitecore.Shell.Applications.Dialogs.ItemLister;
using Sitecore.Strategy.Adaptive.Items;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Sitecore.Strategy.Adaptive.Rules.RuleMacros.Manual
{
    public class ManualTreeMacro : ManualAdaptiveMacroBase
    {
        public string SettingsItemId { get; set; }
        public Item RootItem { get; set; } 

        public override void Execute(XElement element, string name, UrlString parameters, string value)
        {
            Assert.ArgumentNotNull(element, "element");
            Assert.ArgumentNotNull(name, "name");
            Assert.ArgumentNotNull(parameters, "parameters");
            if (value == null || !IsValueSet(element, name, parameters, value))
            {
                value = string.Empty;
            }

            var item = GetAdaptiveTreeMacroSettingsItem(element, name, parameters, value);
            var options = GetSelectItemOptions(item);
            string str = XElement.Parse(element.ToString()).FirstAttribute.Value;
            if (!string.IsNullOrEmpty(str))
            {
                var filterItem = Sitecore.Client.ContentDatabase.GetItem(str);
                if (filterItem != null)
                {
                    options.FilterItem = filterItem;
                }
            }

            options.Root = this.RootItem; 
            
            if (ID.IsID(value))
            {
                var item3 = Sitecore.Client.ContentDatabase.GetItem(new ID(value));
                if (item3 != null)
                {
                    options.SelectedItem = item3;
                }
            }
            var height = this.DefaultWindowHeight;
            var width = this.DefaultWindowWidth;
            if (item != null)
            {
                height = item.WindowHeight;
                width = item.WindowWidth;
            }
            SheerResponse.ShowModalDialog(options.ToUrlString().ToString(), width, height, string.Empty, true);
        }

        public ManualTreeMacro()
        {
            this.DefaultWindowTitle = "Select Item";
            this.DefaultWindowText = "Select the item to use in this rule.";
            this.DefaultWindowIcon = "People/32x32/users3.png";
            this.DefaultWindowHeight = "350px";
            this.DefaultWindowWidth = "600px";
        }
        public string DefaultWindowTitle { get; set; }
        public string DefaultWindowText { get; set; }
        public string DefaultWindowIcon { get; set; }
        public string DefaultWindowHeight { get; set; }
        public string DefaultWindowWidth { get; set; }

        protected virtual SelectItemOptions GetSelectItemOptions(AdaptiveTreeMacroSettingsItem item)
        {
            var options = new SelectItemOptions();
            options.ResultType = SelectItemOptions.DialogResultType.Id;
            if (item != null)
            {
                options.ShowRoot = item.ShowRoot;
                options.IncludeTemplatesForDisplay = item.IncludeTemplatesForDisplay;
                options.IncludeTemplatesForSelection = item.IncludeTemplatesForSelection;
                options.Title = item.WindowTitle;
                options.Text = item.WindowText;
                options.Icon = item.Icon;
            }
            else
            {
                options.Title = this.DefaultWindowTitle;
                options.Text = this.DefaultWindowText;
                options.Icon = this.DefaultWindowIcon;
            }
            return options;
        }

        protected virtual AdaptiveTreeMacroSettingsItem GetAdaptiveTreeMacroSettingsItem(XElement element, string name, UrlString parameters, string value)
        {
            Item item = null;
            if (! string.IsNullOrEmpty(this.SettingsItemId) && ID.IsID(this.SettingsItemId))
            {
                var id = new ID(this.SettingsItemId);
                item = Sitecore.Client.ContentDatabase.GetItem(id);
            }
            if (item == null)
            {
                item = RuleHelper.GetItemFromParameters("settings", element, parameters);
            }
            AdaptiveTreeMacroSettingsItem item2 = item;
            return item2;
        }
    }
}