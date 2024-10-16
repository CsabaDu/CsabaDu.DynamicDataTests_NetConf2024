namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers.ArgsArrays
{
    public enum Framework
    {
        MSTest,
        NUnit,
        xUnit,
    }

    public abstract record TestCase_bool(string TestCase, bool Expected)
    {
        public abstract object[] ToObjectArray(Framework framework);
    }

    public record TestCase_bool_MyType(string TestCase, bool Expected, MyType Other) : TestCase_bool(TestCase, Expected)
    {
        public override object[] ToObjectArray(Framework framework) => framework switch
        {
            Framework.MSTest or
            Framework.NUnit => [TestCase, Expected, Other],
            Framework.xUnit => [this],

            _ => null,
        };

        public override string ToString() => TestCase;
    }

    public record TestCase_bool_object(string TestCase, bool Expected, object Obj) : TestCase_bool(TestCase, Expected)
    {
        public override object[] ToObjectArray(Framework framework) => framework switch
        {
            Framework.MSTest or
            Framework.NUnit => [TestCase, Expected, Obj],
            Framework.xUnit => [this],

            _ => null,
        };

        public override string ToString() => TestCase;
    }
}
