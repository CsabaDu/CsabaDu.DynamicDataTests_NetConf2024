namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers
{
    public abstract record ArgsArrays(string TestCase)
    {
        public virtual object[] ToObjectArray() => [TestCase];
    }

    public record TestCase_bool(string TestCase, bool IsTrue) : ArgsArrays(TestCase)
    {
        public override object[] ToObjectArray() => [TestCase, IsTrue];
    }

    public record TestCase_bool_MyType(string TestCase, bool IsTrue, MyType Other) : TestCase_bool(TestCase, IsTrue)
    {
        public override object[] ToObjectArray() => [TestCase, IsTrue, Other];
    }

    public record TestCase_bool_object(string TestCase, bool IsTrue, object Obj) : TestCase_bool(TestCase, IsTrue)
    {
        public override object[] ToObjectArray() => [TestCase, IsTrue, Obj];
    }
}
