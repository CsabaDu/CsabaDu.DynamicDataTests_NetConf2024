namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers
{
    public abstract record TestDataGeneric(string ParamsDescription)
    {
        public string TestCase => $"{ParamsDescription} => {Result}";
        protected abstract string Result { get; }

        public virtual object[] ToArgs(ArgsCode argsCode) => argsCode switch
        {
            ArgsCode.Instance => [this],
            _ => null,
        };
    }

    public abstract record TestDataReturns<TStruct>(string ParamsDescription, TStruct Expected) : TestDataGeneric(ParamsDescription) where TStruct : struct
    {
        protected override sealed string Result => $"returns {Expected}";
        public override sealed string ToString() => TestCase;
    }


    public record TestDataReturns_object(string ParamsDescription, bool Expected, object Obj) : TestDataReturns<bool>(ParamsDescription, Expected)
    {
        public override object[] ToArgs(ArgsCode argsCode) => argsCode switch
        {
            ArgsCode.Properties => [TestCase, Expected, Obj],
            _ => base.ToArgs(argsCode),
        };
    }

    public record TestDataReturns_MyType(string ParamsDescription, bool Expected, MyType Other) : TestDataReturns<bool>(ParamsDescription, Expected)
    {
        public override object[] ToArgs(ArgsCode argsCode) => argsCode switch
        {
            ArgsCode.Properties => [TestCase, Expected, Other],
            _ => base.ToArgs(argsCode),
        };
    }

    public abstract record TestDataThrows<TException>(string ParamsDescription, TException Exception) : TestDataGeneric(ParamsDescription) where TException : Exception
    {
        protected override sealed string Result => $"throws {typeof(Exception).Name}";
        public override sealed string ToString() => TestCase;
    }
}
