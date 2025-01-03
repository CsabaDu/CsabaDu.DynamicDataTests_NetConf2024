namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public abstract record TestData<T>(string ParamsDescription) where T : notnull
{
    public string TestCase => $"{ParamsDescription} => {Result}";
    protected abstract string Result { get; }
    public override sealed string ToString() => TestCase;

    public virtual object[] ToArgs(ArgsCode argsCode) => argsCode switch
    {
        ArgsCode.Instance => [this],
        _ => null,
    };
}
