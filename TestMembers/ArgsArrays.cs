namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers.ArgsArrays
{
    public enum FrameworkCode { MSTest, NUnit, xUnit, }

    public abstract record TestCase_bool(string TestCase, bool Expected)
    {
        public abstract object[] ToObjectArray(FrameworkCode frameworkCode);

        public override string ToString() => TestCase;
    }

    public record TestCase_bool_MyType(string TestCase, bool Expected, MyType Other) : TestCase_bool(TestCase, Expected)
    {
        public override object[] ToObjectArray(FrameworkCode frameworkCode) => frameworkCode switch
        {
            FrameworkCode.MSTest or FrameworkCode.NUnit => [TestCase, Expected, Other],
            FrameworkCode.xUnit => [this],
            _ => null,
        };

        public override string ToString() => base.ToString();
    }

    public record TestCase_bool_object(string TestCase, bool Expected, object Obj) : TestCase_bool(TestCase, Expected)
    {
        public override object[] ToObjectArray(FrameworkCode frameworkCode) => frameworkCode switch
        {
            FrameworkCode.MSTest or FrameworkCode.NUnit => [TestCase, Expected, Obj],
            FrameworkCode.xUnit => [this],
            _ => null,
        };

        public override string ToString() => base.ToString();
    }
}
