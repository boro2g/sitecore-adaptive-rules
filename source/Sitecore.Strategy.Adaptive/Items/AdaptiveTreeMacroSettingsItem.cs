using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Data.Templates;
using Sitecore.Rules;
using Sitecore.Strategy.Adaptive.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.Items
{
    public class AdaptiveTreeMacroSettingsItem : CustomItem
    {
        public AdaptiveTreeMacroSettingsItem(Item innerItem) : base(innerItem) { }
        public static implicit operator AdaptiveTreeMacroSettingsItem(Item item)
        {
            if (item == null)
            {
                return null;
            }
            if (item.TemplateID != TemplateIDs.AdaptiveTreeMacroSettings)
            {
                return null;
            }
            return new AdaptiveTreeMacroSettingsItem(item);
        }
        public static implicit operator Item(AdaptiveTreeMacroSettingsItem item)
        {
            if (item == null)
            {
                return null;
            }
            return item.InnerItem;
        }
        public string WindowTitle
        {
            get
            {
                return this.InnerItem[FieldIDs.WindowTitle];
            }
            set
            {
                this.InnerItem[FieldIDs.WindowTitle] = value;
            }
        }
        public string WindowText
        {
            get
            {
                return this.InnerItem[FieldIDs.WindowText];
            }
        }
        public bool ShowRoot
        {
            get
            {
                CheckboxField field = this.InnerItem.Fields[FieldIDs.ShowRoot];
                if (field == null)
                {
                    return true;
                }
                return field.Checked;
            }
        }
        public virtual string Icon
        {
            get
            {
                return this.InnerItem.Appearance.Icon;
            }
        }
        public string WindowWidth
        {
            get
            {
                return this.InnerItem[FieldIDs.WindowWidth];
            }
        }
        public string WindowHeight
        {
            get
            {
                return this.InnerItem[FieldIDs.WindowHeight];
            }
        }
        protected virtual List<Template> GetTemplateListFromField(Item item, ID fieldId)
        {
            MultilistField field = item.Fields[fieldId];
            if (field == null)
            {
                return null;
            }
            var templates = new List<Template>();

            return templates;
        }
        public List<Template> IncludeTemplatesForSelection
        {
            get
            {
                return GetTemplateListFromField(this.InnerItem, FieldIDs.IncludeTemplatesForSelection);
            }
        }
        public List<Template> IncludeTemplatesForDisplay
        {
            get
            {
                return GetTemplateListFromField(this.InnerItem, FieldIDs.IncludeTemplatesForDisplay);
            }
        }
    }
}