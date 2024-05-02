using Microsoft.CodeAnalysis;

namespace UnitTest;

public class AllBindablePropsTest : BaseTest<AllBindablePropsSG>
{
    protected override string GetDataFolder()
    {
        return "TestData/AllBindableProps";
    }
}