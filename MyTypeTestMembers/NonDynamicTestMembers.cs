namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTestMembers;

[TestClass]
public abstract class NonDynamicTestMembers : GeneralTestMembers
{
    [TestInitialize]
    public void InitMyTypeTests()
    {
        InitMyType();
    }

    protected void InitHashCodes()
    {
        _hashCode1 = _myType.GetHashCode();
        _hashCode2 = _other.GetHashCode();
    }
}
