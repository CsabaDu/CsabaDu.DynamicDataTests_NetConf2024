namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public record TestData_object_returns_bool(string ParamsDescription, bool Expected, object Obj) : TestData_returns_bool(ParamsDescription, Expected)
{
    public override object[] ToArgs(ArgsCode argsCode) => argsCode switch
    {
        ArgsCode.Properties => [TestCase, Expected, Obj],
        _ => base.ToArgs(argsCode),
    };
}
