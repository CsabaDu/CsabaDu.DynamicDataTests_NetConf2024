namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public class DynamicDataSources : GeneralTestMembers
{
    #region Dynamic data sources members

    private string _testCase;
    private bool _expected;

    public static string CreateDisplayName(string testMethodName, object[] args)
    {
        string testCase = (string)args[0];

        return $"{testMethodName}: {testCase}";
    }
    #endregion

    #region Dynamic data sources

    public IEnumerable<object[]> GetEqualsObjectArgs()
    {
        _testCase = "null => false";
        _obj = null;
        _expected = false;
        yield return argsToObjectArray();

        _testCase = "object => false";
        _obj = new();
        yield return argsToObjectArray();

        _testCase = "Same MyType => true";
        _quantity = TestQuantity;
        _label = TestLabel;
        _obj = GetMyType();
        _expected = true;
        yield return argsToObjectArray();

        _testCase = "Different MyType => false";
        _quantity = DifferentQuantity;
        _label = DifferentLabel;
        _obj = GetMyType();
        _expected = false;
        yield return argsToObjectArray();

        #region argsToObjectArray
        object[] argsToObjectArray()
        {
            TestCase_bool_object args = new(_testCase, _expected, _obj);

            return args.ToObjectArray();
        }
        #endregion
    }

    public IEnumerable<object[]> GetGetHashCodeArgs()
    {
        _testCase = "Different Quantity, same Label => false";
        _quantity = DifferentQuantity;
        _label = TestLabel;
        _other = GetMyType();
        _expected = false;
        yield return argsToObjectArray();

        _testCase = "Same Quantity, same Label => true";
        _quantity = TestQuantity;
        _other = GetMyType();
        _expected = true;
        yield return argsToObjectArray();

        _testCase = "Same Quantity, different Label => false";
        _label = DifferentLabel;
        _other = GetMyType();
        _expected = false;
        yield return argsToObjectArray();

        #region argsToObjectArray
        object[] argsToObjectArray()
        {
            TestCase_bool_MyType args = new(_testCase, _expected, _other);

            return args.ToObjectArray();
        }
        #endregion
    }

    public IEnumerable<object[]> GetEqualsMyTypeArgs()
    {
        _testCase = "null => false";
        _other = null;
        _expected = false;

        TestCase_bool_MyType args = new(_testCase, _expected, _other);
        object[] nullMyTypeArgsArray = args.ToObjectArray();

        return GetGetHashCodeArgs().Append(nullMyTypeArgsArray);
    }
    #endregion
}
