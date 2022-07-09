using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class AllBindablePropsTest
    {
        IIncrementalGenerator generator = new AllBindablePropsSG();

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

            var generatedCode = TestHelper.GetGeneratedOutput(sourceCode, generator);

            generatedCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public void ShouldGenerateBasicCode()
        {
            var sourceCode = File.ReadAllText(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "TestData",
                    "AllBindableProps",
                    "SimpleUsage.txt"
                    )
                );

            var generatedCode = TestHelper.GetGeneratedOutput(sourceCode, generator);
            generatedCode = TestHelper.RemoveAllWhiteSpace(generatedCode ?? "");

            var expectedCode = File.ReadAllText(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "TestData",
                    "AllBindableProps",
                    "SimpleUsage.expected.txt"
                    )
                );
            expectedCode = TestHelper.RemoveAllWhiteSpace(expectedCode);

            generatedCode.Should().NotBeNullOrEmpty()
                .And
                .BeEquivalentTo(expectedCode);
        }

        [Fact]
        public void ShouldNotGenerateIgnoredPropAndBindablePropAndBindableProperty()
        {
            var sourceCode = File.ReadAllText(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "TestData",
                    "AllBindableProps",
                    "WithIgnoredPropAndBindableProp.txt"
                    )
                );

            var generatedCode = TestHelper.GetGeneratedOutput(sourceCode, generator);
            generatedCode = TestHelper.RemoveAllWhiteSpace(generatedCode ?? "");

            var expectedCode = File.ReadAllText(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "TestData",
                    "AllBindableProps",
                    "WithIgnoredPropAndBindableProp.expected.txt"
                    )
                );
            expectedCode = TestHelper.RemoveAllWhiteSpace(expectedCode);

            generatedCode.Should().NotBeNullOrEmpty()
                .And
                .BeEquivalentTo(expectedCode);
        }
    }
}
