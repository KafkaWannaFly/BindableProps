using Microsoft.CodeAnalysis;

namespace UnitTest;

public class BindableReadOnlyPropTest : BaseTest<BindableReadOnlyPropSG>
{
    protected override string GetDataFolder()
    {
        return "TestData/BindableReadOnlyProp";
    }
}