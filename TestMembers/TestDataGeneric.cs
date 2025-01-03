namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public abstract record TestData<T>(string ParamsDescription) where T : notnull
{
    public string TestCase => $"{ParamsDescription} => {Result}";
    public override sealed string ToString() => TestCase;
    protected abstract string Result { get; }

    public virtual object[] ToArgs(ArgsCode argsCode) => argsCode switch
    {
        ArgsCode.Instance => [this],
        _ => null,
    };
}
