using Microsoft.CodeAnalysis;

namespace UnitTest;

public class BaseTest<TGenerator> where TGenerator : IIncrementalGenerator, new()
{
    private readonly IIncrementalGenerator _generator = new TGenerator();

    protected virtual string GetDataFolder()
    {
        return string.Empty;
    }

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
                GetDataFolder(),
                "SimpleUsage.txt"
            )
        );

        var generatedCode = TestHelper.GetGeneratedOutput(sourceCode, _generator);
        generatedCode = TestHelper.RemoveAllWhiteSpace(generatedCode ?? "");

        var expectedCode = File.ReadAllText(
            Path.Combine(
                Directory.GetCurrentDirectory(),
                GetDataFolder(),
                "SimpleUsage.expected.txt"
            )
        );
        expectedCode = TestHelper.RemoveAllWhiteSpace(expectedCode);

        generatedCode.Should().NotBeNullOrEmpty()
            .And
            .BeEquivalentTo(expectedCode);
    }

    [Fact]
    public void ShouldGenerateCodeWithFullSettings()
    {
        var sourceCode = File.ReadAllText(
            Path.Combine(
                Directory.GetCurrentDirectory(),
                GetDataFolder(),
                "FullSettings.txt"
                )
            );

        var generatedCode = TestHelper.GetGeneratedOutput(sourceCode, _generator);
        generatedCode = TestHelper.RemoveAllWhiteSpace(generatedCode ?? "");

        var expectedCode = File.ReadAllText(
            Path.Combine(
                Directory.GetCurrentDirectory(),
                GetDataFolder(),
                "FullSettings.expected.txt"
                )
            );
        expectedCode = TestHelper.RemoveAllWhiteSpace(expectedCode);

        generatedCode.Should().NotBeNullOrEmpty()
            .And
            .BeEquivalentTo(expectedCode);
    }
}
