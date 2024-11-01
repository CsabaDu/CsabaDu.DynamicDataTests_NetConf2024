namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers.ArgsArrays
{
    public enum FrameworkCode
    {
        MSTest,
        NUnit,
        xUnit,
    }

    public abstract record TestData(string TestCase, bool Expected)
    {
        public abstract object[] ToObjectArray(FrameworkCode frameworkCode);

        public override string ToString() => TestCase;
    }

    public record TestData_MyType(string TestCase, bool Expected, MyType Other) : TestData(TestCase, Expected)
    {
        public override object[] ToObjectArray(FrameworkCode frameworkCode) => frameworkCode switch
        {
            FrameworkCode.MSTest or FrameworkCode.NUnit => [TestCase, Expected, Other],
            FrameworkCode.xUnit => [this],
            _ => null,
        };

        public override string ToString() => base.ToString();
    }

    public record TestData_object(string TestCase, bool Expected, object Obj) : TestData(TestCase, Expected)
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
