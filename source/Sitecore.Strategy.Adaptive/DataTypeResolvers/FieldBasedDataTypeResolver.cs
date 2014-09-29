using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Sitecore.Strategy.Adaptive.DataTypeResolvers
{
    public class FieldBasedDataTypeResolver : IDataTypeResolver
    {
        public string FieldId { get; set; }
        public virtual Type GetDataType(Item item)
        {
            Assert.ArgumentNotNull(item, "item");
            Type type = null;
            var value = item[new ID(this.FieldId)];
            if (! string.IsNullOrEmpty(value))
            {
                type = Type.GetType(value);
            }
            Assert.IsTrue(type != null, string.Format("The type {0} specified in the field {1} could not be resolved", value, this.FieldId));
            return type;
        }
    }
}