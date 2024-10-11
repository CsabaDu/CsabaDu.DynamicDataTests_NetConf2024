namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_MSTest;

[TestClass]
public sealed class MyTypeDynamicDataTests_MSTest : NonDynamicTestMembers
{
    #region Dynamic test members
    private string _testCase;
    private bool _expected;

    private static readonly MyTypeDynamicDataTests_MSTest Instance = new();
    private const string DisplayName = nameof(GetDisplayName);

    private static IEnumerable<object[]> EqualsMyTypeArgs => Instance.GetEqualsMyTypeArgs();
    private static IEnumerable<object[]> EqualsObjectArgs => Instance.GetEqualsObjectArgs();
    private static IEnumerable<object[]> GetHashCodeArgs => Instance.GetGetHashCodeArgs();

    public static string GetDisplayName(MethodInfo testMethod, object[] argsArray)
    {
        string testMethodName = testMethod.Name;
        string testCase = (string)argsArray[0];

        return $"{testMethodName}: {testCase}";
    }
    #endregion

    #region Dynamic data test methods

    [TestMethod]
    [DynamicData(nameof(EqualsObjectArgs), DynamicDataSourceType.Property, DynamicDataDisplayName = DisplayName)]
    public void Equals_arg_object_returns_expected(string testCase, bool expected, object obj)
    {
        // Arrange
        // Act
        var actual = _myType.Equals(obj);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(EqualsMyTypeArgs), DynamicDataSourceType.Property, DynamicDataDisplayName = DisplayName)]
    public void Equals_arg_MyType_returns_expected(string testCase, bool expected, MyType other)
    {
        // Arrange
        // Act
        var actual = _myType.Equals(other);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(GetHashCodeArgs), DynamicDataSourceType.Property, DynamicDataDisplayName = DisplayName)]
    public void GetHashCode_returns_expected(string testCase, bool expected, MyType other)
    {
        // Arrange
        _other = other;
        InitHashCodes();

        // Act
        var actual = _hashCode1 == _hashCode2;

        // Assert
        Assert.AreEqual(expected, actual);
    }
    #endregion

    #region Dynamic data sources

    private IEnumerable<object[]> GetEqualsObjectArgs()
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

    private IEnumerable<object[]> GetGetHashCodeArgs()
    {
        //InitMyType();

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

    private IEnumerable<object[]> GetEqualsMyTypeArgs()
    {
        InitMyType();

        _testCase = "null => false";
        _other = null;
        _expected = false;

        TestCase_bool_MyType args = new(_testCase, _expected, _other);
        object[] nullMyTypeArgsArray = args.ToObjectArray();

        return GetHashCodeArgs.Append(nullMyTypeArgsArray);
    }
    #endregion
}
