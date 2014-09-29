using Sitecore.Data;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.Strategy.Adaptive.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.Sample.Rules.Conditions
{
    // where item 1 is [id1,Tree,root={495B562E-5DF9-458F-B646-329DCA2BF5E0},item 1] 
    // and item 2 is [id2,AdaptiveTree,dependency=id1,item 2] 
    public class SimpleAdaptiveTestCondition<T> : RuleCondition<T> where T : RuleContext
    {
        public ID Id1 { get; set; }
        public ID Id2 { get; set; }

        public override void Evaluate(T ruleContext, RuleStack stack)
        {
        }
    }
}