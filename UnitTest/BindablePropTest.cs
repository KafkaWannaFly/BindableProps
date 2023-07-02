using Microsoft.CodeAnalysis;

namespace UnitTest
{
    public class BindablePropTest
    {
        private readonly IIncrementalGenerator _generator = new BindablePropSG();

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
                    "BindablePropTest",
                    "SimpleUsage.txt"
                    )
                );

            var generatedCode = TestHelper.GetGeneratedOutput(sourceCode, _generator);
            generatedCode = TestHelper.RemoveAllWhiteSpace(generatedCode ?? "");

            var expectedCode = File.ReadAllText(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "TestData",
                    "BindablePropTest",
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
                    "TestData",
                    "BindablePropTest",
                    "FullSettings.txt"
                    )
                );

            var generatedCode = TestHelper.GetGeneratedOutput(sourceCode, _generator);
            generatedCode = TestHelper.RemoveAllWhiteSpace(generatedCode ?? "");

            var expectedCode = File.ReadAllText(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "TestData",
                    "BindablePropTest",
                    "FullSettings.expected.txt"
                    )
                );
            expectedCode = TestHelper.RemoveAllWhiteSpace(expectedCode);

            generatedCode.Should().NotBeNullOrEmpty()
                .And
                .BeEquivalentTo(expectedCode);
        }
    }
}