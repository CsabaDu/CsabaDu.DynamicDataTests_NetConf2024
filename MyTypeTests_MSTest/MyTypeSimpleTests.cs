namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_MSTest;

[TestClass]
public sealed class MyTypeSimpleTests : NonDynamicTestMembers
{
    #region Equals(object?)

    [TestMethod]
    public void Equals_object_null_returns_false()
    {
        // Arrange
        _obj = null;

        // Act
        var actual = _myType.Equals(_obj);

        // Assert
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void Equals_object_object_returns_false()
    {
        // Arrange
        _obj = new();

        // Act
        var actual = _myType.Equals(_obj);

        // Assert
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void Equals_object_differentMyType_returns_false()
    {
        // Arrange
        _quantity = DifferentQuantity;
        _label = DifferentLabel;
        _obj = GetMyType();

        // Act
        var actual = _myType.Equals(_obj);

        // Assert
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void Equals_object_sameMyType_returns_true()
    {
        // Arrange
        _quantity = TestQuantity;
        _label = TestLabel;
        _obj = GetMyType();

        // Act
        var actual = _myType.Equals(_obj);

        // Assert
        Assert.IsTrue(actual);
    }
    #endregion

    #region Equals(MyType?)

    [TestMethod]
    public void Equals_MyType_null_returns_false()
    {
        // Arrange
        _other = null;

        // Act
        var actual = _myType.Equals(_other);

        // Assert
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void Equals_MyType_differentQuantity_returns_false()
    {
        // Arrange
        _quantity = DifferentQuantity;
        _other = GetMyType();

        // Act
        var actual = _myType.Equals(_other);

        // Assert
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void Equals_MyType_differentLabel_returns_false()
    {
        // Arrange
        _label = DifferentLabel;
        _other = GetMyType();

        // Act
        var actual = _myType.Equals(_other);

        // Assert
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void Equals_MyType_sameProperties_returns_true()
    {
        // Arrange
        _other = GetMyType();

        // Act
        var actual = _myType.Equals(_other);

        // Assert
        Assert.IsTrue(actual);
    }
    #endregion

    #region GetHashCode()

    [TestMethod]
    public void GetHashCode_differentQuantity_AreNotEqual()
    {
        // Arrange
        _quantity = DifferentQuantity;
        _other = GetMyType();

        // Act
        InitHashCodes();

        // Assert
        Assert.AreNotEqual(_hashCode1, _hashCode2);
    }

    [TestMethod]
    public void GetHashCode_differentLabel_AreNotEqual()
    {
        // Arrange
        _label = DifferentLabel;
        _other = GetMyType();

        // Act
        InitHashCodes();

        // Assert
        Assert.AreNotEqual(_hashCode1, _hashCode2);
    }

    [TestMethod]
    public void GetHashCode_sameProperties_AreEqual()
    {
        // Arrange
        _other = GetMyType();

        // Act
        InitHashCodes();

        // Assert
        Assert.AreEqual(_hashCode1, _hashCode2);
    }
    #endregion
}