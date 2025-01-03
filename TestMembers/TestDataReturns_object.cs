namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public record TestDataReturns_object(string ParamsDescription, bool Expected, object Obj) : TestDataReturns<bool>(ParamsDescription, Expected)
{
    public override object[] ToArgs(ArgsCode argsCode) => argsCode switch
    {
        ArgsCode.Properties => [TestCase, Expected, Obj],
        _ => base.ToArgs(argsCode),
    };
}
