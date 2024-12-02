namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public abstract class MyTypeDynamicDataTests : MyTypeTests
{
    protected static ArgsCode ArgsCode { get; set; }

    protected static readonly DynamicDataSources DataSources = new();

    protected static string CreateDisplayName(string testMethodName, object[] args)
    {
        return $"{testMethodName}: {getTestCase()}";

        string getTestCase() => args[0] switch
        {
            TestData testData => testData.TestCase,
            string testCase  => testCase,
            _ => string.Join(", ", args.Select(arg => arg.ToString())),
        };
    }
}
