namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public abstract class MyTypeDynamicDataTests : MyTypeTests
{
    protected static readonly DynamicDataSources DataSources = new();

    protected static string CreateDisplayName(string testMethodName, object[] args)
    {
        string testCase = (string)args[0];

        return $"{testMethodName}: {testCase}";
    }
}
