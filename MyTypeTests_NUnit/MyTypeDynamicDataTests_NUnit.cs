namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_NUnit;

[TestFixture]
public sealed class MyTypeDynamicDataTests_NUnit : MyTypeDynamicDataTests
{
    [OneTimeSetUp]
    public void SetupMyTypeTestsClass() => ArgsCode = ArgsCode.Properties;

    #region Dynamic data test members

    private static IEnumerable<TestCaseData> EqualsMyTypeArgsList
    => GetDataList(nameof(NUnit_Equals_MyType_returns_expected), DataSources.EqualsMyTypeArgsToList(ArgsCode));
    private static IEnumerable<TestCaseData> EqualsObjectArgsList
    => GetDataList(nameof(NUnit_Equals_object_returns_expected), DataSources.EqualsObjectArgsToList(ArgsCode));
    private static IEnumerable<TestCaseData> GetHashCodeArgsList
    => GetDataList(nameof(NUnit_GetHashCode_returns_expected), DataSources.GetHashCodeArgsToList(ArgsCode));

    private static IEnumerable<TestCaseData> GetDataList(string testMethodName, IEnumerable<object[]> argsList)
    {
        foreach (object[] args in argsList)
        {
            string displayName = CreateDisplayName(testMethodName, args);
            TestCaseData data = new(args[1..]);
            yield return data.SetName(displayName);
        }
    }
    #endregion

    #region Dynamic data test methods

    [TestCaseSource(nameof(EqualsObjectArgsList))]
    public void NUnit_Equals_object_returns_expected(bool expected, object obj)
    {
        // Arrange & Act
        var actual = _myType.Equals(obj);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(EqualsMyTypeArgsList))]
    public void NUnit_Equals_MyType_returns_expected(bool expected, MyType other)
    {
        // Arrange & Act
        var actual = _myType.Equals(other);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(GetHashCodeArgsList))]
    public void NUnit_GetHashCode_returns_expected(bool expected, MyType other)
    {
        // Arrange
        InitHashCodes(other);

        // Act
        var actual = _hashCode1 == _hashCode2;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    #endregion
}