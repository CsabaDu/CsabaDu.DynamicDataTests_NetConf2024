namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public record TestData_object_returns_bool(string ParamsDescription, object Obj, bool Expected) : TestData_returns_bool(ParamsDescription, Expected)
{
    public override object[] ToArgs(ArgsCode argsCode) => argsCode switch
    {
        ArgsCode.Properties => [TestCase, Obj, Expected],
        _ => base.ToArgs(argsCode),
    };
}
