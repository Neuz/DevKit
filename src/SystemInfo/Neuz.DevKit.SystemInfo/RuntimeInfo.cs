using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Neuz.DevKit.SystemInfo;

/// <summary>
/// 有关 .NET 运行时安装的信息、程序系统信息等
/// </summary>
public static class RuntimeInfo
{
    /// <summary>
    /// .Net 运行框架描述
    /// </summary>
    /// <returns>如: .NET 6.0.12, .NET Core 3.1.9</returns>
    public static string FrameworkDescription => RuntimeInformation.FrameworkDescription;

    /// <summary>
    /// 当前进程运行架构
    /// <para>详情见：<see cref="Architecture"/></para>
    /// </summary>
    /// <returns>如： X86, X64, Arm, Arm64, Wasm, S390x </returns>
    public static string ProcessArchitecture => RuntimeInformation.ProcessArchitecture.ToString();

    /// <summary>
    /// .Net 运行框架版本
    /// </summary>
    /// <returns>如：6.0.12, 3.1.9</returns>
    public static string FrameworkVersion => Environment.Version.ToString();

    /// <summary>
    /// 操作系统平台架构
    /// <para>详情见：<see cref="Architecture"/></para>
    /// </summary>
    /// <returns>如： X86, X64, Arm, Arm64, Wasm, S390x </returns>
    public static string OSArchitecture => RuntimeInformation.OSArchitecture.ToString();

    /// <summary>
    /// 操作系统的类型
    /// </summary>
    /// <returns>如：Win32NT</returns>
    public static string OSPlatformID => Environment.OSVersion.Platform.ToString();

    /// <summary>
    /// 操作系统内核版本
    /// </summary>
    /// <returns>如：Microsoft Windows NT 10.0.22621.0</returns>
    public static string OSVersion => Environment.OSVersion.VersionString;

    /// <summary>
    /// 操作系统内核 Service Pack 版本
    /// </summary>
    public static string OSServicePack => Environment.OSVersion.ServicePack;

    /// <summary>
    /// 操作系统的描述
    /// </summary>
    /// <returns>如：Microsoft Windows 10.0.22621</returns>
    public static string OSDescription => RuntimeInformation.OSDescription;

    /// <summary>
    /// 当前进程是否64位
    /// </summary>
    public static bool Is64BitProcess => Environment.Is64BitProcess;

    /// <summary>
    /// 当前操作系统是否为 64 位操作系统
    /// </summary>
    public static bool Is64BitOS => Environment.Is64BitOperatingSystem;

    /// <summary>
    /// CPU核心数，即：当前进程可用的处理器数
    /// <para>4核心8线程的 CPU，这里会获取到 8</para>
    /// </summary>
    public static int ProcessorCount => Environment.ProcessorCount;

    /// <summary>
    /// 当前计算机的名称
    /// </summary>
    public static string MachineName => Environment.MachineName;

    /// <summary>
    /// 当前用户名
    /// </summary>
    public static string UserName => Environment.UserName;

    /// <summary>
    /// 当前用户关联的网络域名
    /// </summary>
    public static string UserDomainName => Environment.UserDomainName;

    /// <summary>
    /// 当前进程是否在用户交互模式中运行
    /// </summary>
    public static bool IsUserInteractive => Environment.UserInteractive;

    /// <summary>
    /// 系统根目录
    /// <para>Linux下为null</para>
    /// </summary>
    public static string SystemDirectory => Environment.SystemDirectory;

    /// <summary>
    /// 当前进程目录
    /// </summary>
    public static string CurrentDirectory => Environment.CurrentDirectory;
}