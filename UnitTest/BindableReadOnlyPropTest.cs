using Microsoft.CodeAnalysis;

namespace UnitTest;

public class BindableReadOnlyPropTest
{
    private readonly IIncrementalGenerator _generator = new BindableReadOnlyPropSG();

    private readonly string _testFolder = Path.Combine(
        Directory.GetCurrentDirectory(),
        "TestData",
        "BindableReadOnlyProp"
    );

    [Fact]
    public void ShouldDoNothing()
    {
        var sourceCode = File.ReadAllText(
            Path.Combine(
                Directory.GetCurrentDirectory(),
                "TestData",
                "Shared",
                "NoUseAtAll.txt"
            )
        );

        var generatedCode = TestHelper.GetGeneratedOutput(sourceCode, _generator);

        generatedCode.Should().BeNullOrEmpty();
    }

    [Fact]
    public void ShouldGenerateBasicCode()
    {
        var sourceCode = File.ReadAllText(
            Path.Combine(
                _testFolder,
                "SimpleUsage.txt"
            )
        );

        var generatedCode = TestHelper.GetGeneratedOutput(sourceCode, _generator);
        generatedCode = TestHelper.RemoveAllWhiteSpace(generatedCode ?? "");

        var expectedCode = File.ReadAllText(
            Path.Combine(
                Directory.GetCurrentDirectory(),
                _testFolder,
                "SimpleUsage.expected.txt"
            )
        );
        expectedCode = TestHelper.RemoveAllWhiteSpace(expectedCode);

        generatedCode.Should().NotBeNullOrEmpty()
            .And
            .BeEquivalentTo(expectedCode);
    }
}