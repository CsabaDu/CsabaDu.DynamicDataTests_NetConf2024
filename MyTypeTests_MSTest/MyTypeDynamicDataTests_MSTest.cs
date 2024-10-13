namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_MSTest;

[TestClass]
public sealed class MyTypeDynamicDataTests_MSTest : DynamicDataSources
{
    [TestInitialize]
    public void InitMyTypeTests()
    {
        InitMyType();
    }

    #region Dynamic test members
    private static readonly CsabaDu.DynamicDataTests_NetConf2024.MyTypeTestMembers.DynamicDataSources DynamicDataSources = new();
    private const string DisplayName = nameof(GetDisplayName);

    private static IEnumerable<object[]> EqualsMyTypeArgs => DynamicDataSources.GetEqualsMyTypeArgs();
    private static IEnumerable<object[]> EqualsObjectArgs => DynamicDataSources.GetEqualsObjectArgs();
    private static IEnumerable<object[]> GetHashCodeArgs => DynamicDataSources.GetGetHashCodeArgs();

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
        InitHashCodes(other);

        // Act
        var actual = _hashCode1 == _hashCode2;

        // Assert
        Assert.AreEqual(expected, actual);
    }
    #endregion
}
