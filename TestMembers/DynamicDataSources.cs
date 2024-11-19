namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public class DynamicDataSources : MyTypeTests
{
    #region Dynamic data sources members

    private string _testCase;
    private bool _expected;

    private void InitTestCase(string paramsDescription)
    {
        string expectedToString = _expected.ToString();
        _testCase = $"{paramsDescription} => {expectedToString}";
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
        InitTestCase("Same MyType");
        _obj = GetMyType();
        yield return argsToObjectArray();

        _expected = false;
        InitTestCase("null");
        _obj = null;
        yield return argsToObjectArray();

        InitTestCase("object");
        _obj = new();
        yield return argsToObjectArray();

        InitTestCase("Different MyType");
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
        InitTestCase("Same Quantity, same Label");
        _other = GetMyType();
        yield return argsToObjectArray();

        _expected = false;
        InitTestCase("Different Quantity, same Label");
        _quantity = DifferentQuantity;
        _other = GetMyType();
        yield return argsToObjectArray();

        InitTestCase("Same Quantity, different Label");
        _quantity = TestQuantity;
        _label = DifferentLabel;
        _other = GetMyType();
        yield return argsToObjectArray();

        object[] argsToObjectArray() => ArgsToObjectArray_MyType(argsCode);
    }

    public IEnumerable<object[]> EqualsMyTypeArgsToList(ArgsCode argsCode)
    {
        _expected = false;
        InitTestCase("null");
        _other = null;

        object[] nullMyTypeTestCase = ArgsToObjectArray_MyType(argsCode);
        IEnumerable<object[]> getHashCodeArgs = GetHashCodeArgsToList(argsCode);

        return getHashCodeArgs.Append(nullMyTypeTestCase);
    }
    #endregion
}
