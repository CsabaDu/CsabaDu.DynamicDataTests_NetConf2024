namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_xUnit;

public sealed class MyTypeDynamicDataTests_xUnit : MyTypeDynamicDataTests
{
    static MyTypeDynamicDataTests_xUnit() => ArgsCode = ArgsCode.Instance;

    #region Dynamic data test members

    public static IEnumerable<object[]> EqualsMyTypeArgsList => DataSources.EqualsMyTypeArgsToList(ArgsCode);
    public static IEnumerable<object[]> EqualsObjectArgsList => DataSources.EqualsObjectArgsToList(ArgsCode);
    public static IEnumerable<object[]> GetHashCodeArgsList => DataSources.GetHashCodeArgsToList(ArgsCode);
    #endregion

    #region Dynamic data test methods

    [Theory, MemberData(nameof(EqualsObjectArgsList))]
    public void xUnit_Equals_arg_object_returns_expected(TestData_object testData)
    {
        // Arrange & Act
        var actual = _myType.Equals(testData.Obj);

        // Assert
        Assert.Equal(testData.Expected, actual);
    }

    [Theory, MemberData(nameof(EqualsMyTypeArgsList))]
    public void xUnit_Equals_arg_MyType_returns_expected(TestData_MyType testData)
    {
        // Arrange & Act
        var actual = _myType.Equals(testData.Other);

        // Assert
        Assert.Equal(testData.Expected, actual);
    }

    [Theory, MemberData(nameof(GetHashCodeArgsList))]
    public void xUnit_GetHashCode_returns_expected(TestData_MyType testData)
    {
        // Arrange
        InitHashCodes(testData.Other);

        // Act
        var actual = _hashCode1 == _hashCode2;

        // Assert
        Assert.Equal(testData.Expected, actual);
    }
    #endregion
}
