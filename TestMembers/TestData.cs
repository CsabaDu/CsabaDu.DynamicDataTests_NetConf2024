namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers
{
    public enum ArgsCode
    {
        Properties,
        Instance,
    }

    public abstract record TestData(string TestCase, bool Expected)
    {
        public abstract object[] ToArgs(ArgsCode argsCode);

        public override sealed string ToString() => TestCase;
    }

    public record TestData_object(string TestCase, bool Expected, object Obj) : TestData(TestCase, Expected)
    {
        public override object[] ToArgs(ArgsCode argsCode) => argsCode switch
        {
            ArgsCode.Properties => [TestCase, Expected, Obj],
            ArgsCode.Instance => [this],
            _ => null,
        };
    }

    public record TestData_MyType(string TestCase, bool Expected, MyType Other) : TestData(TestCase, Expected)
    {
        public override object[] ToArgs(ArgsCode argsCode) => argsCode switch
        {
            ArgsCode.Properties => [TestCase, Expected, Other],
            ArgsCode.Instance => [this],
            _ => null,
        };
    }
}
