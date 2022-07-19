using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using System.Collections.Immutable;
using System.Composition;
using System.Threading.Tasks;

namespace DarkLinesOfCode
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(DarkLinesOfCodeCodeFixProvider)), Shared]
    public class DarkLinesOfCodeCodeFixProvider : CodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create<string>();

        public override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            return Task.CompletedTask;
        }
    }
}
