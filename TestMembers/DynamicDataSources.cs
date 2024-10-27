namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public class DynamicDataSources : MyTypeTests
{
    #region Dynamic data sources members

    private string _testCase;
    private bool _expected;

    private string CreateTestCase(string paramsDescription)
    {
        string expectedValue = _expected.ToString();
        return $"{paramsDescription} => {expectedValue}";
    }
    #endregion

    #region Dynamic data sources

    public IEnumerable<object[]> GetEqualsObjectArgs(FrameworkCode frameworkCode)
    {
        _expected = true;
        _testCase = CreateTestCase("Same MyType");
        _obj = InitMyTypeElements();
        yield return argsToObjectArray();

        _expected = false;
        _testCase = CreateTestCase("null");
        _obj = null;
        yield return argsToObjectArray();

        _testCase = CreateTestCase("object");
        _obj = new();
        yield return argsToObjectArray();

        _testCase = CreateTestCase("Different MyType");
        _quantity = DifferentQuantity;
        _label = DifferentLabel;
        _obj = GetMyType();
        yield return argsToObjectArray();

        object[] argsToObjectArray()
        {
            TestCase_bool_object args = new(_testCase, _expected, _obj);
            return args.ToObjectArray(frameworkCode);
        }
    }

    public IEnumerable<object[]> GetGetHashCodeArgs(FrameworkCode frameworkCode)
    {
        _expected = true;
        _testCase = CreateTestCase("Same Quantity, same Label");
        _other = InitMyTypeElements();
        yield return argsToObjectArray();

        _expected = false;
        _testCase = CreateTestCase("Different Quantity, same Label");
        _quantity = DifferentQuantity;
        _other = GetMyType();
        yield return argsToObjectArray();

        _testCase = CreateTestCase("Same Quantity, different Label");
        _quantity = TestQuantity;
        _label = DifferentLabel;
        _other = GetMyType();
        yield return argsToObjectArray();

        object[] argsToObjectArray()
        {
            TestCase_bool_MyType args = new(_testCase, _expected, _other);
            return args.ToObjectArray(frameworkCode);
        }
    }

    public IEnumerable<object[]> GetEqualsMyTypeArgs(FrameworkCode frameworkCode)
    {
        _expected = false;
        _testCase = CreateTestCase("null");
        _other = null;

        TestCase_bool_MyType args = new(_testCase, _expected, _other);
        object[] nullMyTypeTestCase = args.ToObjectArray(frameworkCode);
        IEnumerable<object[]> getHashCodeArgs = GetGetHashCodeArgs(frameworkCode);

        return getHashCodeArgs.Append(nullMyTypeTestCase);
    }
    #endregion
}
