﻿namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_MSTest;

[TestClass]
public sealed class MyTypeDynamicDataTests_MSTest : MyTypeDynamicDataTests
{
    [TestInitialize]
    public void InitMyTypeTests()
    {
        _myType = InitMyType();
    }

    #region Dynamic data test members

    private static IEnumerable<object[]> EqualsMyTypeArgs => DataSources.GetEqualsMyTypeArgs(FrameworkCode.MSTest);
    private static IEnumerable<object[]> EqualsObjectArgs => DataSources.GetEqualsObjectArgs(FrameworkCode.MSTest);
    private static IEnumerable<object[]> GetHashCodeArgs => DataSources.GetGetHashCodeArgs(FrameworkCode.MSTest);

    private const string DisplayName = nameof(GetDisplayName);

    public static string GetDisplayName(MethodInfo testMethod, object[] argsArray)
    {
        return CreateDisplayName(testMethod.Name, argsArray);
    }
    #endregion

    #region Dynamic data test methods

    [TestMethod, DynamicData(nameof(EqualsObjectArgs), DynamicDataSourceType.Property, DynamicDataDisplayName = DisplayName)]
    public void MSTest_Equals_arg_object_returns_expected(string testCase, bool expected, object obj)
    {
        // Arrange
        // Act
        var actual = _myType.Equals(obj);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod, DynamicData(nameof(EqualsMyTypeArgs), DynamicDataSourceType.Property, DynamicDataDisplayName = DisplayName)]
    public void MSTest_Equals_arg_MyType_returns_expected(string testCase, bool expected, MyType other)
    {
        // Arrange
        // Act
        var actual = _myType.Equals(other);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod, DynamicData(nameof(GetHashCodeArgs), DynamicDataSourceType.Property, DynamicDataDisplayName = DisplayName)]
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
