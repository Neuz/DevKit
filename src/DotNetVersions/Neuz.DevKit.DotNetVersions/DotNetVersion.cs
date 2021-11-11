namespace Neuz.DevKit
{
    public class DotNetVersions
    {
        public DotNetVersion C { get; set; }


        public class DotNetVersion
        {
            public string Version { get; }

            public string SpLevel { get; }

            public bool Installed { get; }
        }
    }
}
