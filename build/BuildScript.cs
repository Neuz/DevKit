using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Context;
using FlubuCore.Context.Attributes.BuildProperties;
using FlubuCore.Scripting;

namespace BuildScript
{
    public class BuildScript : DefaultBuildScript
    {
        [FromArg("nugetKey")]
        public string NuGetKey { get; set; }

        [BuildConfiguration]
        public string BuildConfiguration { get; set; } = "Release";

        public string OutputDir { get; set; } = "output";


        protected override void ConfigureTargets(ITaskContext context)
        {
            #region Extensions

            var projectName = "Neuz.DevKit.Extensions";
            var extensionsProject = "src/Extensions/Neuz.DevKit.Extensions/Neuz.DevKit.Extensions.csproj";
            var extensionsTestProject = "src/Extensions/Neuz.DevKit.Extensions.Test/Neuz.DevKit.Extensions.test.csproj";
            var extensionsOutputDir = $"{OutputDir}/{projectName}";
            var extensionsTestResultDir = $"{extensionsOutputDir}/testResult";

            context.CreateTarget("Extensions.clean")
                   .SetDescription($"清理 - [{projectName}]")
                   .AddCoreTask(x => x.Clean()
                                      .Project(extensionsProject));

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
                                      .AddDirectoryToClean(extensionsTestResultDir,true))
                   .AddCoreTask(x => x.Restore().Project(extensionsTestProject))
                   .AddCoreTask(x => x.Test()
                                      .Project(extensionsTestProject)
                                      .ListTests());

            context.CreateTarget("Extensions.pack")
                   .SetDescription($"构建NuGet包 -[{projectName}]")


            context.CreateTarget("Extensions")
                   .SetDescription($"默认 - [{projectName}]")
                   .DependsOn("Extensions.build")
                   .DependsOn("Extensions.test");

            #endregion
        }
    }
}