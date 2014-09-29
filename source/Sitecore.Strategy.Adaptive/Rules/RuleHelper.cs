using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Sitecore.Strategy.Adaptive.Rules
{
    public static class RuleHelper
    {
        public static ID GetItemIdFromParameters(string attributeName, XElement element, UrlString parameters)
        {
            var attribute = element.Attribute(parameters[attributeName]);
            if (attribute == null || !ID.IsID(attribute.Value))
            {
                return null;
            }
            var id = new ID(attribute.Value);
            return id;
        }
        public static Item GetItemFromParameters(string attributeName, XElement element, UrlString parameters)
        {
            var attribute = element.Attribute(parameters[attributeName]);
            if (attribute == null)
            {
                return null;
            }
            if (!ID.IsID(attribute.Value))
            {
                return Sitecore.Client.ContentDatabase.GetItem(attribute.Value);
            }
            var id = new ID(attribute.Value);
            return Sitecore.Client.ContentDatabase.GetItem(id);
        }

    }
}