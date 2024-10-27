namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public class DynamicDataSources : MyTypeTests
{
    #region Dynamic data sources members

    private string _testCase;
    private bool _expected;
    #endregion

    #region Dynamic data sources

    public IEnumerable<object[]> GetEqualsObjectArgs(FrameworkCode frameworkCode)
    {
        _expected = true;
        _testCase = "Same MyType => true";
        _obj = InitMyTypeElements();
        yield return argsToObjectArray();

        _expected = false;
        _testCase = "null => false";
        _obj = null;
        yield return argsToObjectArray();

        _testCase = "object => false";
        _obj = new();
        yield return argsToObjectArray();

        _testCase = "Different MyType => false";
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
        _testCase = "Same Quantity, same Label => true";
        _other = InitMyTypeElements();
        yield return argsToObjectArray();

        _expected = false;
        _testCase = "Different Quantity, same Label => false";
        _quantity = DifferentQuantity;
        _other = GetMyType();
        yield return argsToObjectArray();

        _testCase = "Same Quantity, different Label => false";
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
        _testCase = "null => false";
        _other = null;

        TestCase_bool_MyType args = new(_testCase, _expected, _other);
        object[] nullMyTypeTestCase = args.ToObjectArray(frameworkCode);
        IEnumerable<object[]> getHashCodeArgs = GetGetHashCodeArgs(frameworkCode);

        return getHashCodeArgs.Append(nullMyTypeTestCase);
    }
    #endregion
}
