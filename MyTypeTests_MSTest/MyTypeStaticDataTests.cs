namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_MSTest;

[TestClass]
public sealed class MyTypeStaticDataTests : TestRoot
{
    [TestInitialize]
    public void InitMyTypeTests()
    {
        InitMyType();
    }

    #region GetHashCode()

    [TestMethod]
    [DataRow(true, TestQuantity, TestLabel, DisplayName = "Same Quantity, same Label => are equal")]
    [DataRow(false, TestQuantity, DifferentLabel, DisplayName = "Same Quantity, different Label => are not equal")]
    [DataRow(false, DifferentQuantity, TestLabel, DisplayName = "Different Quantity, same Label => are not equal")]
    public void GetHashCode_returns_expected(bool expected, int quantity, string label)
    {
        // Arrange
        _other = new(quantity, label);
        InitHashCodes(_other);

        // Act
        var actual = _hashCode1 == _hashCode2;

        // Assert
        Assert.AreEqual(expected, actual);
    }
    #endregion

    #region Equals(object?)

    [TestMethod]
    [DataRow(false, TestQuantity, DifferentLabel, DisplayName = "Same MyType => true")]
    [DataRow(false, DifferentQuantity, TestLabel, DisplayName = "Different MyType => false")]

    public void Equals_object_returns_expected(bool expected, int quantity, string label)
    {
        // Arrange
        _obj = new MyType(quantity, label);

        // Act
        var actual = _myType.Equals( _obj);

        // Assert
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void Equals_object_arg_null_returns_false()
    {
        // Arrange
        _obj = null;

        // Act
        var actual = _myType.Equals(_obj);

        // Assert
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void Equals_object_arg_object_returns_false()
    {
        // Arrange
        _obj = new();

        // Act
        var actual = _myType.Equals(_obj);

        // Assert
        Assert.IsFalse(actual);
    }
    #endregion

    #region Equals(MyType?)

    private static readonly MyType SameMyType = new(TestQuantity, TestLabel);
    private static readonly MyType DifferentQuantityMyType = new(DifferentQuantity, TestLabel);
    private static readonly MyType DifferentLabelMyType = new(TestQuantity, DifferentLabel);
    private static readonly MyType NullMyType = null;

    [TestMethod]
    [DataRow(false, nameof(NullMyType), DisplayName = "null => false")]
    [DataRow(false, nameof(DifferentQuantityMyType), DisplayName = "Different Quantity => false")]
    [DataRow(false, nameof(DifferentLabelMyType), DisplayName = "Different Label => false")]
    [DataRow(true, nameof(SameMyType), DisplayName = "Same MyType => true")]
    public void Equals_MyType_returns_expected(bool expected, string otherName)
    {
        // Arrange
        FieldInfo otherInfo = typeof(MyTypeStaticDataTests).GetField(otherName, BindingFlags.Static | BindingFlags.NonPublic);
        _other = (MyType)otherInfo.GetValue(null);

        // Act
        var actual = _myType.Equals(_other);

        // Assert
        Assert.AreEqual(expected, actual);
    }
    #endregion
}
