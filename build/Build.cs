using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Pack);

    private const string CoreProjectName = "DarkLinesOfCode";
    private const string PackageProjectName = "DarkLinesOfCode.Package";

    [Solution] readonly Solution Solution;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    readonly Configuration Configuration = Configuration.Release;

    Target Clean => _ => _
        .Before(RestoreCore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
        });

    Target RestoreCore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution.GetProject(CoreProjectName)));
        });

    Target CompileCore => _ => _
        .DependsOn(RestoreCore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution.GetProject(CoreProjectName))
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target RestorePackage => _ => _
        .DependsOn(CompileCore)
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution.GetProject(PackageProjectName)));
        });

    Target CompilePackage => _ => _
        .DependsOn(RestorePackage)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution.GetProject(PackageProjectName))
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target Pack => _ => _
        .DependsOn(CompilePackage)
        .Executes(() =>
        {
            DotNetPack(s => s
              .SetProject(Solution.GetProject(PackageProjectName))
              .SetConfiguration(Configuration)
              .EnableNoBuild()
              .EnableNoRestore()
              .SetOutputDirectory(ArtifactsDirectory));
        });
}
