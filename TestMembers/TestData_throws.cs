namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers
{
    public abstract record TestData_throws<TException>(string ParamsDescription, TException Exception) : TestData<TException>(ParamsDescription) where TException : Exception
    {
        protected override string Result => $"throws {typeof(TException).Name}";
    }

    public abstract record TestData_throws(string ParamsDescription, Exception Exception) : TestData_throws<Exception>(ParamsDescription, Exception)
    {
        protected override string Result => $"throws {Exception.GetType().Name}";
    }
}
