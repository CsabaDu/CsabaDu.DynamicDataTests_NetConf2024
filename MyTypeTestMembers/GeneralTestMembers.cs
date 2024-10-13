using CsabaDu.DynamicDataTests_NetConf2024.SampleTypes;

namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTestMembers;

public abstract class GeneralTestMembers
{
    protected const string TestLabel = "TestLabel"; // UpperCase
    protected const string DifferentLabel = "testLabel"; // lowerCase
    protected const int TestQuantity = 3;
    protected const int DifferentQuantity = 4;

    protected MyType _myType;
    protected int _quantity;
    protected string _label;
    protected object _obj;
    protected MyType _other;
    protected int _hashCode1;
    protected int _hashCode2;

    protected void InitMyType()
    {
        _quantity = TestQuantity;
        _label = TestLabel;

        _myType = GetMyType();
    }

    protected MyType GetMyType()
    {
        return new(_quantity, _label);
    }
}