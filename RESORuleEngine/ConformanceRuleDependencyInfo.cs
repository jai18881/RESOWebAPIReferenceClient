namespace RESORuleEngine
{
    public class ConformanceRuleDependencyInfo
    {
        public string[] BindingRules { get; set; }
        public ConformanceCheckType CheckType { get; set; }
        public ConformanceRuleRelationship RuleRelationship { get; set; }

        public ConformanceRuleDependencyInfo(ConformanceCheckType checkType, ConformanceRuleRelationship ruleRelationship = ConformanceRuleRelationship.None, string[] bindingRules = null)
        {
            this.CheckType = checkType;
            this.RuleRelationship = ruleRelationship;
            this.BindingRules = bindingRules;
        }
    }
}