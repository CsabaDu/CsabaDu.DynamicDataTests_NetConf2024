namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public abstract record TestDataThrows<TException>(string ParamsDescription, TException Exception) : TestData<TException>(ParamsDescription) where TException : Exception
{
    protected override sealed string Result => $"throws {typeof(Exception).Name}";
}
