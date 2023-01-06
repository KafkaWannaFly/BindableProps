using Microsoft.CodeAnalysis;

namespace UnitTest;

public class AttachedPropTest
{
    private readonly IIncrementalGenerator _generator = new AttachedPropSG();
    
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
                Directory.GetCurrentDirectory(),
                "TestData",
                "AttachedPropTest",
                "SimpleUsage.txt"
            )
        );

        var generatedCode = TestHelper.GetGeneratedOutput(sourceCode, _generator);

        var expectedCode = File.ReadAllText(
            Path.Combine(
                Directory.GetCurrentDirectory(),
                "TestData",
                "AttachedPropTest",
                "SimpleUsage.expected.txt"
            )
        );
        
        expectedCode = TestHelper.RemoveAllWhiteSpace(expectedCode);
        generatedCode = TestHelper.RemoveAllWhiteSpace(generatedCode ?? "");

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
                "TestData",
                "AttachedPropTest",
                "FullSettings.txt"
            )
        );

        var generatedCode = TestHelper.GetGeneratedOutput(sourceCode, _generator);

        var expectedCode = File.ReadAllText(
            Path.Combine(
                Directory.GetCurrentDirectory(),
                "TestData",
                "AttachedPropTest",
                "FullSettings.expected.txt"
            )
        );
        
        generatedCode = TestHelper.RemoveAllWhiteSpace(generatedCode ?? "");
        expectedCode = TestHelper.RemoveAllWhiteSpace(expectedCode);

        generatedCode.Should().NotBeNullOrEmpty()
            .And
            .BeEquivalentTo(expectedCode);
    }
}