namespace CsabaDu.DynamicDataTests_NetConf2024.TestMembers;

public abstract record TestData_returns_bool(string ParamsDescription, bool Expected) : TestData_returns<bool>(ParamsDescription, Expected);
