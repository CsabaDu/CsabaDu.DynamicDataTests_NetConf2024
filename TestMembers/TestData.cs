namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers
{
    public abstract record TestData(string ParamsDescription)
    {
        protected abstract string Result { get; }
        public string TestCase => $"{ParamsDescription} => {Result}";

        public override sealed string ToString() => TestCase;
        public virtual object[] ToArgs(ArgsCode argsCode) => argsCode switch
        {
            ArgsCode.Instance => [this],
            _ => null,
        };
    }

    public abstract record TestData<T>(string ParamsDescription) : TestData(ParamsDescription) where T : notnull;
}
