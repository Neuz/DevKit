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

            var extensionsProjectName   = "Neuz.DevKit.Extensions";
            var extensionsProject       = "src/Extensions/Neuz.DevKit.Extensions/Neuz.DevKit.Extensions.csproj";
            var extensionsTestProject   = "src/Extensions/Neuz.DevKit.Extensions.Test/Neuz.DevKit.Extensions.Test.csproj";
            var extensionsOutputDir     = $"{OutputDir}/{extensionsProjectName}";
            var extensionsTestResultDir = $"{extensionsOutputDir}/testResult";
            var extensionsNugetDir      = $"{extensionsOutputDir}/nuget";

            context.CreateTarget("Extensions.clean")
                   .SetDescription($"清理 - [{extensionsProjectName}]")
                   .AddCoreTask(x => x.Clean()
                                      .Project(extensionsProject)
                                      .AddDirectoryToClean(extensionsOutputDir, true));

            context.CreateTarget("Extensions.restore")
                   .SetDescription($"还原 - [{extensionsProjectName}]")
                   .AddCoreTask(x => x.Restore(extensionsProject));

            context.CreateTarget("Extensions.build")
                   .SetDescription($"构建 - [{extensionsProjectName}]")
                   .DependsOn("Extensions.clean")
                   .DependsOn("Extensions.restore")
                   .AddCoreTask(x => x.Build()
                                      .Project(extensionsProject)
                                      .Configuration(BuildConfiguration));

            context.CreateTarget("Extensions.test")
                   .SetDescription($"测试 - [{extensionsProjectName}]")
                   .AddCoreTask(x => x.Clean().Project(extensionsTestProject)
                                      .AddDirectoryToClean(extensionsTestResultDir, true))
                   .AddCoreTask(x => x.Restore().Project(extensionsTestProject))
                   .AddCoreTask(x => x.Test()
                                      .Project(extensionsTestProject)
                                      .ListTests());

            context.CreateTarget("Extensions.pack")
                   .SetDescription($"构建NuGet包 -[{extensionsProjectName}]")
                   .DependsOn("Extensions.build")
                   .DependsOn("Extensions.test")
                   .AddCoreTask(x => x.Pack()
                                      .Project(extensionsProject)
                                      .PackageVersion(Version)
                                      .OutputDirectory(extensionsNugetDir));

            context.CreateTarget("Extensions.publish")
                   .SetDescription($"发布NuGet包 - [{extensionsProjectName}]")
                   .DependsOn("Extensions.pack")
                   .AddCoreTask(x => x.NugetPush($"{extensionsNugetDir}/Neuz.DevKit.Extensions.{Version}.nupkg")
                                      .ServerUrl("https://www.nuget.org/api/v2/package")
                                      .ApiKey(NuGetKey));

            #endregion

            #region Api.DNSPod

            var apiDNSPodProjectName   = "Neuz.DevKit.Api.DNSPod";
            var apiDNSPodProject       = "src/Api/Neuz.DevKit.Api.DNSPod/Neuz.DevKit.Api.DNSPod.csproj";
            var apiDNSPodTestProject   = "src/Api/Neuz.DevKit.Api.DNSPod.Test/Neuz.DevKit.Api.DNSPod.Test.csproj";
            var apiDNSPodOutputDir     = $"{OutputDir}/{apiDNSPodProjectName}";
            var apiDNSPodTestResultDir = $"{apiDNSPodOutputDir}/testResult";
            var apiDNSPodNugetDir      = $"{apiDNSPodOutputDir}/nuget";

            context.CreateTarget("Api.DNSPod.clean")
                   .SetDescription($"清理 - [{apiDNSPodProjectName}]")
                   .AddCoreTask(x => x.Clean()
                                      .Project(apiDNSPodProject)
                                      .AddDirectoryToClean(apiDNSPodOutputDir, true));

            context.CreateTarget("Api.DNSPod.restore")
                   .SetDescription($"还原 - [{apiDNSPodProjectName}]")
                   .AddCoreTask(x => x.Restore(apiDNSPodProject));

            context.CreateTarget("Api.DNSPod.build")
                   .SetDescription($"构建 - [{apiDNSPodProjectName}]")
                   .DependsOn("Api.DNSPod.clean")
                   .DependsOn("Api.DNSPod.restore")
                   .AddCoreTask(x => x.Build()
                                      .Project(apiDNSPodProject)
                                      .Configuration(BuildConfiguration));

            context.CreateTarget("Api.DNSPod.test")
                   .SetDescription($"测试 - [{apiDNSPodProjectName}]")
                   .AddCoreTask(x => x.Clean().Project(apiDNSPodTestProject)
                                      .AddDirectoryToClean(apiDNSPodTestResultDir, true))
                   .AddCoreTask(x => x.Restore().Project(apiDNSPodTestProject))
                   .AddCoreTask(x => x.Test()
                                      .Project(apiDNSPodTestProject)
                                      .ListTests());

            context.CreateTarget("Api.DNSPod.pack")
                   .SetDescription($"构建NuGet包 -[{apiDNSPodProjectName}]")
                   .DependsOn("Api.DNSPod.build")
                   .DependsOn("Api.DNSPod.test")
                   .AddCoreTask(x => x.Pack()
                                      .Project(apiDNSPodProject)
                                      .PackageVersion(Version)
                                      .OutputDirectory(apiDNSPodNugetDir));

            context.CreateTarget("Api.DNSPod.publish")
                   .SetDescription($"发布NuGet包 - [{apiDNSPodProjectName}]")
                   .DependsOn("Api.DNSPod.pack")
                   .AddCoreTask(x => x.NugetPush($"{apiDNSPodNugetDir}/Neuz.DevKit.Api.DNSPod.{Version}.nupkg")
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