﻿namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_MSTest;

[TestClass]
public sealed class MyTypeStaticDataTests : MyTypeTests
{
    [TestInitialize]
    public void InitMyTypeTests() => InitMyTypeElements();

    #region GetHashCode()

    [TestMethod]
    [DataRow(TestQuantity, TestLabel, true,  DisplayName = "Same Quantity, same Label => are equal")]
    [DataRow(TestQuantity, DifferentLabel, false, DisplayName = "Same Quantity, different Label => are not equal")]
    [DataRow(DifferentQuantity, TestLabel, false, DisplayName = "Different Quantity, same Label => are not equal")]
    public void GetHashCode_returns_expected(int quantity, string label, bool expected)
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
    [DataRow(new object[] { TestQuantity, TestLabel, true }, DisplayName = "Same MyType => true")]
    [DataRow([DifferentQuantity, DifferentLabel, false], DisplayName = "Different MyType => false")]
    public void Equals_object_returns_expected(object[] args)
    {
        // Arrange
        _quantity = (int)args[0];
        _label = (string)args[1];
        _obj = GetMyType();

        bool expected = (bool)args[^1];

        // Act
        var actual = _myType.Equals( _obj);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(null, DisplayName = "null => false")]
    public void Equals_object_arg_null_returns_false(object obj)
    {
        // Arrange & Act
        var actual = _myType.Equals(obj);

        // Assert
        Assert.IsFalse(actual);
    }

    [TestMethod]
    [DataRow("System.Object", DisplayName = "object => false")]
    public void Equals_object_arg_object_returns_false(string paramTypeName)
    {
        // Arrange
        Type paramType = Type.GetType(paramTypeName);
        _obj = Activator.CreateInstance(paramType);

        // Act
        var actual = _myType.Equals(_obj);

        // Assert
        Assert.IsFalse(actual);
    }
    #endregion

    #region Equals(MyType?)

    [TestMethod]
    [DataRow(nameof(NullMyType), false, DisplayName = "null => false")]
    [DataRow(nameof(DifferentQuantityMyType), false, DisplayName = "Different Quantity => false")]
    [DataRow(nameof(DifferentLabelMyType), false, DisplayName = "Different Label => false")]
    [DataRow(nameof(SameMyType), true, DisplayName = "Same MyType => true")]
    public void Equals_MyType_returns_expected(string fieldName, bool expected)
    {
        // Arrange
        Type thisType = GetType();
        FieldInfo paramInfo = thisType.GetField(fieldName, BindingFlags.Static | BindingFlags.NonPublic);
        _other = (MyType)paramInfo.GetValue(null);

        // Act
        var actual = _myType.Equals(_other);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    private static readonly MyType NullMyType = null;
    private static readonly MyType DifferentQuantityMyType = new(DifferentQuantity, TestLabel);
    private static readonly MyType DifferentLabelMyType = new(TestQuantity, DifferentLabel);
    private static readonly MyType SameMyType = new(TestQuantity, TestLabel);
    #endregion
}
