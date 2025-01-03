namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public record TestDataReturns_MyType(string ParamsDescription, bool Expected, MyType Other) : TestDataReturns<bool>(ParamsDescription, Expected)
{
    public override object[] ToArgs(ArgsCode argsCode) => argsCode switch
    {
        ArgsCode.Properties => [TestCase, Expected, Other],
        _ => base.ToArgs(argsCode),
    };
}
