namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public class DynamicDataSources : MyTypeTests
{
    #region Dynamic data sources members

    private string _testCase;
    private bool _expected;

    private string CreateTestCase(string paramsDescription)
    {
        string expectedToString = _expected.ToString();
        return $"{paramsDescription} => {expectedToString}";
    }

    private object[] ArgsToObjectArray_object(ArgsCode argsCode)
    {
        TestData_object args = new(_testCase, _expected, _obj);
        return args.ToObjectArray(argsCode);
    }

    private object[] ArgsToObjectArray_MyType(ArgsCode argsCode)
    {
        TestData_MyType args = new(_testCase, _expected, _other);
        return args.ToObjectArray(argsCode);
    }
    #endregion

    #region Dynamic data sources

    public IEnumerable<object[]> EqualsObjectArgsToList(ArgsCode argsCode)
    {
        InitMyTypeElements();

        _expected = true;
        _testCase = CreateTestCase("Same MyType");
        _obj = GetMyType();
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

        object[] argsToObjectArray() => ArgsToObjectArray_object(argsCode);
    }

    public IEnumerable<object[]> GetHashCodeArgsToList(ArgsCode argsCode)
    {
        InitMyTypeElements();

        _expected = true;
        _testCase = CreateTestCase("Same Quantity, same Label");
        _other = GetMyType();
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

        object[] argsToObjectArray() => ArgsToObjectArray_MyType(argsCode);
    }

    public IEnumerable<object[]> EqualsMyTypeArgsToList(ArgsCode argsCode)
    {
        _expected = false;
        _testCase = CreateTestCase("null");
        _other = null;

        object[] nullMyTypeTestCase = ArgsToObjectArray_MyType(argsCode);
        IEnumerable<object[]> getHashCodeArgs = GetHashCodeArgsToList(argsCode);

        return getHashCodeArgs.Append(nullMyTypeTestCase);
    }
    #endregion
}
