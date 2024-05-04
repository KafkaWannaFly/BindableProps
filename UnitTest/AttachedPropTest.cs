using Microsoft.CodeAnalysis;

namespace UnitTest;

public class AttachedPropTest : BaseTest<AttachedPropSG>
{
    protected override string GetDataFolder()
    {
        return "TestData/AttachedProp";
    }
}