namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public abstract record TestDataReturns<TStruct>(string ParamsDescription, TStruct Expected) : TestData<TStruct>(ParamsDescription) where TStruct : struct
{
    protected override sealed string Result => $"returns {Expected}";
}
