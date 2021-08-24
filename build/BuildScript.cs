using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Context;
using FlubuCore.Context.Attributes.BuildProperties;
using FlubuCore.Scripting;

namespace Build
{
    public class BuildScript : DefaultBuildScript
    {
        [FromArg("nugetKey", "NuGet平台Api Key")]
        public string NuGetKey { get; set; }

        [FromArg("version", "NuGet包版本")]
        public string Version { get; set; } = "0.0.1";

        [BuildConfiguration]
        public string BuildConfiguration { get; set; } = "Release";

        public string OutputDir { get; set; } = "output";


        protected override void ConfigureTargets(ITaskContext context)
        {
            #region Extensions

            var projectName = "Neuz.DevKit.Extensions";
            var extensionsProject = "src/Extensions/Neuz.DevKit.Extensions/Neuz.DevKit.Extensions.csproj";
            var extensionsTestProject = "src/Extensions/Neuz.DevKit.Extensions.Test/Neuz.DevKit.Extensions.Test.csproj";
            var extensionsOutputDir = $"{OutputDir}/{projectName}";
            var extensionsTestResultDir = $"{extensionsOutputDir}/testResult";
            var extensionsNugetDir = $"{extensionsOutputDir}/nuget";

            context.CreateTarget("Extensions.clean")
                   .SetDescription($"清理 - [{projectName}]")
                   .AddCoreTask(x => x.Clean()
                                      .Project(extensionsProject)
                                      .AddDirectoryToClean(extensionsOutputDir, true));

            context.CreateTarget("Extensions.restore")
                   .SetDescription($"还原 - [{projectName}]")
                   .AddCoreTask(x => x.Restore(extensionsProject));

            context.CreateTarget("Extensions.build")
                   .SetDescription($"构建 - [{projectName}]")
                   .DependsOn("Extensions.clean")
                   .DependsOn("Extensions.restore")
                   .AddCoreTask(x => x.Build()
                                      .Project(extensionsProject)
                                      .Configuration(BuildConfiguration));

            context.CreateTarget("Extensions.test")
                   .SetDescription($"测试 - [{projectName}]")
                   .AddCoreTask(x => x.Clean().Project(extensionsTestProject)
                                      .AddDirectoryToClean(extensionsTestResultDir, true))
                   .AddCoreTask(x => x.Restore().Project(extensionsTestProject))
                   .AddCoreTask(x => x.Test()
                                      .Project(extensionsTestProject)
                                      .ListTests());

            context.CreateTarget("Extensions.pack")
                   .SetDescription($"构建NuGet包 -[{projectName}]")
                   .DependsOn("Extensions.build")
                   .DependsOn("Extensions.test")
                   .AddCoreTask(x => x.Pack()
                                      .Project(extensionsProject)
                                      .PackageVersion(Version)
                                      .OutputDirectory(extensionsNugetDir));

            context.CreateTarget("Extensions.publish")
                   .SetDescription($"发布NuGet包 - [{projectName}]")
                   .DependsOn("Extensions.pack")
                   .AddCoreTask(x => x.NugetPush($"{extensionsNugetDir}/Neuz.DevKit.Extensions.{Version}.nupkg")
                                      .ServerUrl("https://www.nuget.org/api/v2/package")
                                      .ApiKey(NuGetKey));

            #endregion

            context.CreateTarget("build")
                   .SetDescription("默认构建")
                   .SetAsDefault()
                   .DependsOn("Extensions.build")
                   .DependsOn("Extensions.test");

            context.CreateTarget("publish")
                   .SetDescription("发布")
                   .DependsOn("build")
                   .DependsOn("Extensions.publish");
        }
    }
}