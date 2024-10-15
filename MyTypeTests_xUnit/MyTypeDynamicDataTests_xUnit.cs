namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_xUnit
{
    public class MyTypeDynamicDataTests_xUnit : GeneralTestMembers
    {
        public MyTypeDynamicDataTests_xUnit()
        {
            InitMyType();
        }

        private static readonly DynamicDataSources DataSources = new();

        public static IEnumerable<object[]> EqualsMyTypeArgs => GetTestData_bool_MyType(DataSources.GetEqualsMyTypeArgs());
        public static IEnumerable<object[]> EqualsObjectArgs => GetTestData_bool_object(DataSources.GetEqualsObjectArgs());
        public static IEnumerable<object[]> GetHashCodeArgs => GetTestData_bool_MyType(DataSources.GetGetHashCodeArgs());

        public static IEnumerable<object[]> GetTestData_bool_MyType(IEnumerable<object[]> argsList)
        {
            foreach (object[] args in argsList)
            {
                string displayName = (string)args[0];
                bool expected = (bool)args[1];
                MyType other = (MyType)args[2];
                TestCase_bool_MyType testData = new(displayName, expected, other);

                yield return testData.ToArray();
            }
        }

        public static IEnumerable<object[]> GetTestData_bool_object(IEnumerable<object[]> argsList)
        {
            foreach (object[] args in argsList)
            {
                string displayName = (string)args[0];
                bool expected = (bool)args[1];
                object obj = args[2];
                TestCase_bool_object testData = new(displayName, expected, obj); 

                yield return testData.ToArray();
            }
        }

        [Theory]
        [MemberData(nameof(EqualsObjectArgs))]
        public void xUnit_Equals_arg_object_returns_expected(TestCase_bool_object testData)
        {
            // Arrange
            // Act
            var actual = _myType.Equals(testData.Obj);

            // Assert
            Assert.Equal((bool)testData.Expected, actual);
        }
    }
}