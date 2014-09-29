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
    // and item 2 operator is [Operator,AdaptiveOperator,dependency=id3,operator]
    // and item 2 value is [Value,AdaptiveValue,dependency=id3,value]
    public class ComplexAdaptiveTestCondition<T> : AdaptiveConditionBase<T> where T : RuleContext
    {
        public ID Id1 { get; set; }
        public ID Id2 { get; set; }
        public override object GetLeftValue(T ruleContext)
        {
            return null;
        }
        public override object GetRightValue(T ruleContext)
        {
            return null;
        }
        public override Type GetDataType(T ruleContext)
        {
            return null;
        }
    }
}