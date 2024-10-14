namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_NUnit;

public class MyTypeDynamicDataTests_NUnit : DynamicDataSources
{
    [SetUp]
    public void Setup()
    {
        InitMyType();
    }

    private static readonly DynamicDataSources DataSources = new();
    private static IEnumerable<TestCaseData> EqualsMyTypeArgs
        => GetTestCaseDataList(nameof(NUnit_Equals_MyType_returns_expected), DataSources.GetEqualsMyTypeArgs());
    private static IEnumerable<TestCaseData> EqualsObjectArgs
        => GetTestCaseDataList(nameof(NUnit_Equals_object_returns_expected), DataSources.GetEqualsObjectArgs());
    private static IEnumerable<TestCaseData> GetHashCodeArgs
        => GetTestCaseDataList(nameof(NUnit_GetHashCode_returns_expected), DataSources.GetGetHashCodeArgs());

    private static IEnumerable<TestCaseData> GetTestCaseDataList(string testMethodName, IEnumerable<object[]> argsArraysList)
    {
        foreach (object[] argsArray in argsArraysList)
        {
            string displayName = DataSources.CreateDisplayName(testMethodName, argsArray);
            TestCaseData testCaseData = new(argsArray[1..]);

            yield return testCaseData.SetName(displayName);
        }
    }

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
}