﻿namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public class DynamicDataSources : MyTypeTests
{
    #region Dynamic data sources members

    private string _paramsDescription;
    private bool _expected;

    private TestData_object TestData_object => new(TestCase, _expected, _obj);
    private TestData_MyType TestData_MyType => new(TestCase, _expected, _other);
    private string TestCase => $"{_paramsDescription} => {_expected.ToString()}";

    private static object[] TestDataToArgs(TestData testData, ArgsCode argsCode)
    => testData.ToArgs(argsCode);
    #endregion

    #region Dynamic data sources

    public IEnumerable<object[]> EqualsObjectArgsToList(ArgsCode argsCode)
    {
        InitMyTypeElements();

        _expected = true;
        _paramsDescription = "Same MyType";
        _obj = GetMyType();
        yield return testDataToArgs();

        _expected = false;
        _paramsDescription = "null";
        _obj = null;
        yield return testDataToArgs();

        _paramsDescription = "object";
        _obj = new();
        yield return testDataToArgs();

        _paramsDescription = "Different MyType";
        _quantity = DifferentQuantity;
        _label = DifferentLabel;
        _obj = GetMyType();
        yield return testDataToArgs();

        object[] testDataToArgs() => TestDataToArgs(TestData_object, argsCode);
    }

    public IEnumerable<object[]> GetHashCodeArgsToList(ArgsCode argsCode)
    {
        InitMyTypeElements();

        _expected = true;
        _paramsDescription = "Same Quantity, same Label";
        _other = GetMyType();
        yield return testDataToArgs();

        _expected = false;
        _paramsDescription = "Different Quantity, same Label";
        _quantity = DifferentQuantity;
        _other = GetMyType();
        yield return testDataToArgs();

        _paramsDescription = "Same Quantity, different Label";
        _quantity = TestQuantity;
        _label = DifferentLabel;
        _other = GetMyType();
        yield return testDataToArgs();

        object[] testDataToArgs() => TestDataToArgs(TestData_MyType, argsCode);
    }

    public IEnumerable<object[]> EqualsMyTypeArgsToList(ArgsCode argsCode)
    {
        _expected = false;
        _paramsDescription = "null";
        _other = null;

        object[] nullMyTypeArgs = TestDataToArgs(TestData_MyType, argsCode);
        IEnumerable<object[]> getHashCodeArgsList = GetHashCodeArgsToList(argsCode);

        return getHashCodeArgsList.Append(nullMyTypeArgs);
    }
    #endregion
}
