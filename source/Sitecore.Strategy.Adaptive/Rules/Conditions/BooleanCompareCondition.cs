using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace Sitecore.Strategy.Adaptive.Rules.Conditions
{
    public class BooleanCompareCondition<T> : OperatorCondition<T> where T : RuleContext
    {
        public bool LeftValue { get; set; }
        public bool RightValue { get; set; }

        protected virtual bool Compare(bool leftValue, bool rightValue)
        {
            if (ID.Parse(OperatorId) == Items.ItemIDs.BooleanOperatorTrue)
            {
                return LeftValue == RightValue;
            }

            if (ID.Parse(OperatorId) == Items.ItemIDs.BooleanOperatorFalse)
            {
                return LeftValue != RightValue;
            }

            return false;
        }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");

            return this.Compare(this.LeftValue, this.RightValue);
        }
    }
}