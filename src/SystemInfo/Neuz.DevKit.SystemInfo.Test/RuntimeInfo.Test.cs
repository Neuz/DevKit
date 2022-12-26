namespace Neuz.DevKit.SystemInfo.Test;

[TestClass]
public class RuntimeInfoTest
{
    [TestMethod]
    public void RuntimeInfoTest_1()
    {
        Console.WriteLine(".Net 运行框架描述： " + RuntimeInfo.FrameworkDescription);
        Console.WriteLine(".Net 运行框架版本： " + RuntimeInfo.FrameworkVersion);
        Console.WriteLine("当前进程运行架构： " + RuntimeInfo.ProcessArchitecture);
        Console.WriteLine("操作系统平台架构： " + RuntimeInfo.OSArchitecture);
        Console.WriteLine("操作系统的类型： " + RuntimeInfo.OSPlatformID);
        Console.WriteLine("操作系统内核版本： " + RuntimeInfo.OSVersion);
        Console.WriteLine("操作系统内核 Service Pack 版本： " + RuntimeInfo.OSServicePack);
        Console.WriteLine("操作系统的描述： " + RuntimeInfo.OSDescription);
        Console.WriteLine("当前进程是否64位： " + RuntimeInfo.Is64BitProcess);
        Console.WriteLine("是否为 64 位操作系统： " + RuntimeInfo.Is64BitOS);
        Console.WriteLine("CPU核心数： " + RuntimeInfo.ProcessorCount);
        Console.WriteLine("当前计算机的名称： " + RuntimeInfo.MachineName);
        Console.WriteLine("当前用户名： " + RuntimeInfo.UserName);
        Console.WriteLine("当前用户关联的网络域名： " + RuntimeInfo.UserDomainName);
        Console.WriteLine("当前进程是否在用户交互模式中运行： " + RuntimeInfo.IsUserInteractive);
        Console.WriteLine("系统根目录： " + RuntimeInfo.SystemDirectory);
        Console.WriteLine("当前进程目录： " + RuntimeInfo.CurrentDirectory);
    }
}