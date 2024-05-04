using Microsoft.CodeAnalysis;

namespace UnitTest;

public class BindablePropTest : BaseTest<BindablePropSG>
{
    protected override string GetDataFolder()
    {
        return "TestData/BindableProp";
    }
}