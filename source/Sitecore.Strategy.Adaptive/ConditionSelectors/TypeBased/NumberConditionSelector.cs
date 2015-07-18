using Sitecore.Data;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.Strategy.Adaptive.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.ConditionSelectors.TypeBased
{
    public class NumberConditionSelector : ConditionSelectorForTypeBase
    {

        public NumberConditionSelector() 
            : base (new HashSet<Type>() 
                    {
                        typeof(short) ,
                        typeof(ushort) , 
                        typeof(int) , 
                        typeof(uint) ,
                        typeof(long) ,
                        typeof(ulong) , 
                        typeof(float) ,
                        typeof(double)         
                    })
        {
        }

        public override RuleCondition<T> GetCondition<T>(Type type, AdaptiveConditionBase<T> adaptiveCondition, T ruleContext) 
        {
            var condition = new NumberCompareCondition<T>();
            var left = adaptiveCondition.GetLeftValue(ruleContext);
            if (left != null) 
            {
                condition.LeftValue = double.Parse(left.ToString());
            }
            var right = adaptiveCondition.GetRightValue(ruleContext);
            if (right != null) 
            {
                condition.RightValue= double.Parse(right.ToString());
            }
            condition.OperatorId = adaptiveCondition.Operator.ToString();
            return condition;
        }
    }
}