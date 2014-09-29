using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Configuration;

namespace Sitecore.Strategy.Adaptive.Providers
{
    public static class AdaptiveManager
    {
        private static readonly ProviderHelper<AdaptiveProviderBase, AdaptiveProviderCollection> _helper;
        static AdaptiveManager()
        {
            _helper = new ProviderHelper<AdaptiveProviderBase, AdaptiveProviderCollection>("adaptiveManager");
        }

        public static AdaptiveProviderBase Provider
        {
            get
            {
                return _helper.Provider;
            }
        }
        public static AdaptiveProviderCollection Providers
        {
            get
            {
                return _helper.Providers;
            }
        }
    }
}