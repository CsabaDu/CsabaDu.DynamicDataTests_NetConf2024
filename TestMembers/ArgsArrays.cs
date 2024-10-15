namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers
{
    public abstract record TestCase_bool(string TestCase, bool Expected)
    {
        public abstract object[] ToObjectArray();
        public abstract object[] ToArray();
    }

    public record TestCase_bool_MyType(string TestCase, bool Expected, MyType Other) : TestCase_bool(TestCase, Expected)
    {
        public override object[] ToObjectArray() => [TestCase, Expected, Other];
        public override object[] ToArray() => [this];
        public override string ToString() => TestCase;
    }

    public record TestCase_bool_object(string TestCase, bool Expected, object Obj) : TestCase_bool(TestCase, Expected)
    {
        public override object[] ToObjectArray() => [TestCase, Expected, Obj];
        public override object[] ToArray() => [this];
        public override string ToString() => TestCase;
    }
}
