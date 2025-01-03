namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public abstract record TestData_returns<TStruct>(string ParamsDescription, TStruct Expected) : TestData<TStruct>(ParamsDescription) where TStruct : struct
{
    protected override string Result => $"returns {Expected}";
}
