namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_NUnit;

[TestFixture]
public sealed class MyTypeDynamicDataTests_NUnit : DynamicDataSources
{
    #region Dynamic data test members

    [SetUp]
    public void SetupMyTypeTests()
    {
        InitMyType();
    }

    private static readonly DynamicDataSources DataSources = new();
    private static IEnumerable<TestCaseData> EqualsMyTypeArgs
        => GetTestCaseSource(nameof(NUnit_Equals_MyType_returns_expected), DataSources.GetEqualsMyTypeArgs());
    private static IEnumerable<TestCaseData> EqualsObjectArgs
        => GetTestCaseSource(nameof(NUnit_Equals_object_returns_expected), DataSources.GetEqualsObjectArgs());
    private static IEnumerable<TestCaseData> GetHashCodeArgs
        => GetTestCaseSource(nameof(NUnit_GetHashCode_returns_expected), DataSources.GetGetHashCodeArgs());

    private static IEnumerable<TestCaseData> GetTestCaseSource(string testMethodName, IEnumerable<object[]> argsList)
    {
        foreach (object[] args in argsList)
        {
            string displayName = CreateDisplayName(testMethodName, args);
            TestCaseData testCaseData = new(args[1..]);

            yield return testCaseData.SetName(displayName);
        }
    }
    #endregion

    #region Dynamic data test methods

    [Test, TestCaseSource(nameof(EqualsObjectArgs))]
    public void NUnit_Equals_object_returns_expected(bool expected, object obj)
    {
        // Arrange
        // Act
        var actual = _myType.Equals(obj);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, TestCaseSource(nameof(EqualsMyTypeArgs))]
    public void NUnit_Equals_MyType_returns_expected(bool expected, MyType other)
    {
        // Arrange
        // Act
        var actual = _myType.Equals(other);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, TestCaseSource(nameof(GetHashCodeArgs))]
    public void NUnit_GetHashCode_returns_expected(bool expected, MyType other)
    {
        // Arrange
        InitHashCodes(other);

        // Act
        var actual = _hashCode1 == _hashCode2;

        // Act
        Assert.That(actual, Is.EqualTo(expected));
    }
    #endregion
}