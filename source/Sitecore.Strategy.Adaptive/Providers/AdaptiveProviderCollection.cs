using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.Providers
{
    public class AdaptiveProviderCollection : ProviderCollection
    {
        public AdaptiveProviderBase this[string name]
        {
            get
            {
                return (base[name] as AdaptiveProviderBase);
            }
        }
    }
}