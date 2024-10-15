namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers.ArgsArrays
{
    public abstract record TestCase_bool(string TestCase, bool Expected)
    {
        #region MSTest
        public abstract object[] ToObjectArray();
        #endregion

        #region xUnit
        public abstract object[] ToArray();
        #endregion
    }

    public record TestCase_bool_MyType(string TestCase, bool Expected, MyType Other) : TestCase_bool(TestCase, Expected)
    {
        #region MSTest
        public override object[] ToObjectArray() => [TestCase, Expected, Other];
        #endregion

        #region xUnit
        public override object[] ToArray() => [this];
        public override string ToString() => TestCase;
        #endregion
    }

    public record TestCase_bool_object(string TestCase, bool Expected, object Obj) : TestCase_bool(TestCase, Expected)
    {
        #region MSTest
        public override object[] ToObjectArray() => [TestCase, Expected, Obj];
        #endregion

        #region xUnit
        public override object[] ToArray() => [this];
        public override string ToString() => TestCase;
        #endregion
    }
}
