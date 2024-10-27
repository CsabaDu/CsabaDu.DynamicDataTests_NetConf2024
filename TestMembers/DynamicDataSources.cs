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

    private object[] ArgsToObjectArray_object(FrameworkCode frameworkCode)
    {
        TestCase_bool_object args = new(_testCase, _expected, _obj);
        return args.ToObjectArray(frameworkCode);
    }

    private object[] ArgsToObjectArray_MyType(FrameworkCode frameworkCode)
    {
        TestCase_bool_MyType args = new(_testCase, _expected, _other);
        return args.ToObjectArray(frameworkCode);
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

        object[] argsToObjectArray() => ArgsToObjectArray_object(frameworkCode);
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

        object[] argsToObjectArray() => ArgsToObjectArray_MyType(frameworkCode);
    }

    public IEnumerable<object[]> GetEqualsMyTypeArgs(FrameworkCode frameworkCode)
    {
        _expected = false;
        _testCase = CreateTestCase("null");
        _other = null;

        object[] nullMyTypeTestCase = ArgsToObjectArray_MyType(frameworkCode);
        IEnumerable<object[]> getHashCodeArgs = GetGetHashCodeArgs(frameworkCode);

        return getHashCodeArgs.Append(nullMyTypeTestCase);
    }
    #endregion
}
