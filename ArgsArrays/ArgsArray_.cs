namespace CsabaDu.DynamicDataTests_NetConf2024.ArgsArrays
{
    public abstract record ArgsArray_
    {
        public string TestCase {  get; init; }

        public ArgsArray_(string testCase)
        {
            TestCase = testCase;
        }

        public virtual object[] ToObjectArray()
        {
            return new object[]
            {
                TestCase,
            };
        }
    }

    public record TestCase_bool_: ArgsArray_
    {
        public bool IsTrue {  get; init; }

        public TestCase_bool_(string testCaee, bool isTrue) : base(testCaee)
        {
            IsTrue = isTrue;
        }

        public override object[] ToObjectArray()
        {
            return new object[]
            {
                TestCase,
                IsTrue,
            };
        }
    }

    public record TestCase_bool_MyType_MyType_ : TestCase_bool_
    {
        MyType Other {  get; init; }

        public TestCase_bool_MyType_MyType_(string testCase, bool isTrue, MyType other) : base(testCase, isTrue)
        {
            Other = other;
        }

        public override object[] ToObjectArray()
        {
            return new object[]
            {
                TestCase,
                IsTrue,
                Other,
            };
        }
    }

    public record TestCase_bool_MyType_object_ : TestCase_bool_
    {
        object Obj { get; init; }

        public TestCase_bool_MyType_object_(string testCase, bool isTrue, MyType myType, object obj) : base(testCase, isTrue)
        {
            Obj = obj;
        }

        public override object[] ToObjectArray()
        {
            return new object[]
            {
                TestCase,
                IsTrue,
                Obj,
            };
        }
    }
}
