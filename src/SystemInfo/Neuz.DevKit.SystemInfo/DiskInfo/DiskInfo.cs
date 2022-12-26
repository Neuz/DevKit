namespace Neuz.DevKit.SystemInfo;

/// <summary>
/// 磁盘驱动器信息
/// </summary>
public class DiskInfo
{
    private readonly DriveInfo _info;

    public DiskInfo(DriveInfo info)
    {
        _info = info;
    }

    public string Name => _info.Name;

    public string VolumeLabel => _info.VolumeLabel;

    public DriveType DriveType => _info.DriveType;

    public string DriveTypeString => _info.DriveType.ToString();

    public string DriveFormat => _info.DriveFormat;

    public string RootDirectory => _info.RootDirectory.FullName;

    public bool IsReady => _info.IsReady;

    public long FreeSpace => _info.AvailableFreeSpace;

    public long TotalSize => _info.TotalSize;

    public long UsedSize => _info.TotalSize - _info.AvailableFreeSpace;


    /// <summary>
    /// 获取所有能使用的磁盘
    /// </summary>
    /// <returns></returns>
    public static DiskInfo[] GetDisks(bool isFilter = false)
    {
        return isFilter
                   ? DriveInfo.GetDrives()
                              .Select(d => new DiskInfo(d))
                              .ToArray()
                   : DriveInfo.GetDrives()
                              .Where(d => d.DriveType == DriveType.Fixed)
                              .Where(d => d.TotalSize != 0)
                              .Where(d => d.DriveFormat != "overlay")
                              .Select(d => new DiskInfo(d))
                              .ToArray();
    }
}