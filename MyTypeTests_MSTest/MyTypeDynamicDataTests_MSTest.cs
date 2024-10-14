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
    private static readonly DynamicDataSources DataSources = new();
    private const string DisplayName = nameof(GetDisplayName);

    private static IEnumerable<object[]> EqualsMyTypeArgs => DataSources.GetEqualsMyTypeArgs();
    private static IEnumerable<object[]> EqualsObjectArgs => DataSources.GetEqualsObjectArgs();
    private static IEnumerable<object[]> GetHashCodeArgs => DataSources.GetGetHashCodeArgs();

    public static string GetDisplayName(MethodInfo testMethod, object[] argsArray)
    {
        string testMethodName = testMethod.Name;
        string testCase = (string)argsArray[0];

        return DataSources.CreateDisplayName(testMethodName, argsArray);
    }
    #endregion

    #region Dynamic data test methods

    [TestMethod]
    [DynamicData(nameof(EqualsObjectArgs), DynamicDataSourceType.Property, DynamicDataDisplayName = DisplayName)]
    public void MSTest_Equals_arg_object_returns_expected(string testCase, bool expected, object obj)
    {
        // Arrange
        // Act
        var actual = _myType.Equals(obj);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(EqualsMyTypeArgs), DynamicDataSourceType.Property, DynamicDataDisplayName = DisplayName)]
    public void MSTest_Equals_arg_MyType_returns_expected(string testCase, bool expected, MyType other)
    {
        // Arrange
        // Act
        var actual = _myType.Equals(other);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(GetHashCodeArgs), DynamicDataSourceType.Property, DynamicDataDisplayName = DisplayName)]
    public void MSTest_GetHashCode_returns_expected(string testCase, bool expected, MyType other)
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
