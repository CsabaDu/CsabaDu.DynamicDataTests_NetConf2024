namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_xUnit;

public sealed class MyTypeDynamicDataTests_xUnit : MyTypeDynamicDataTests
{
    static MyTypeDynamicDataTests_xUnit() => Framework = FrameworkCode.xUnit;
    public MyTypeDynamicDataTests_xUnit() => _myType = InitMyTypeElements();

    #region Dynamic data test members

    public static IEnumerable<object[]> EqualsMyTypeArgs => DataSources.GetEqualsMyTypeArgs(Framework);
    public static IEnumerable<object[]> EqualsObjectArgs => DataSources.GetEqualsObjectArgs(Framework);
    public static IEnumerable<object[]> GetHashCodeArgs => DataSources.GetGetHashCodeArgs(Framework);
    #endregion

    #region Dynamic data test methods

    [Theory, MemberData(nameof(EqualsObjectArgs))]
    public void xUnit_Equals_arg_object_returns_expected(TestCase_bool_object testData)
    {
        // Arrange & Act
        var actual = _myType.Equals(testData.Obj);

        // Assert
        Assert.Equal(testData.Expected, actual);
    }

    [Theory, MemberData(nameof(EqualsMyTypeArgs))]
    public void xUnit_Equals_arg_MyType_returns_expected(TestCase_bool_MyType testData)
    {
        // Arrange & Act
        var actual = _myType.Equals(testData.Other);

        // Assert
        Assert.Equal(testData.Expected, actual);
    }

    [Theory, MemberData(nameof(GetHashCodeArgs))]
    public void xUnit_GetHashCode_returns_expected(TestCase_bool_MyType testData)
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
