namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public record TestData_MyType_returns_bool(string ParamsDescription, bool Expected, MyType Other) : TestData_returns_bool(ParamsDescription, Expected)
{
    public override object[] ToArgs(ArgsCode argsCode) => argsCode switch
    {
        ArgsCode.Properties => [TestCase, Expected, Other],
        _ => base.ToArgs(argsCode),
    };
}
