using CsabaDu.DynamicDataTests_NetConf2024.MyTypeTestMembers;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace CsabaDu.DynamicDataTests_NetConf2024.MyTypeTests_NUnit;

public class Tests : GeneralTestMembers
{
    [SetUp]
    public void Setup()
    {
        InitMyType();
    }

    //[Test, TestCaseSource(nameof(TestCases))]
    //public void Test1()
    //{
    //    Assert.Pass();
    //}
}