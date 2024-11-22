namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public abstract class MyTypeDynamicDataTests : MyTypeTests
{
    protected static ArgsCode ArgsCode { get; set; }

    protected static readonly DynamicDataSources DataSources = new();

    protected static string CreateDisplayName(string testMethodName, object[] args)
    {
        return args[0] switch
        {
            TestData testData => createDisplayName(testData.TestCase),
            string testCase => createDisplayName(testCase),
            _ => createDisplayName(createTestCase()),
        };

        string createDisplayName(string testCase) => $"{testMethodName}: {testCase}";
        string createTestCase() => string.Join(", ", args.Select(arg => arg.ToString()));
    }
}
