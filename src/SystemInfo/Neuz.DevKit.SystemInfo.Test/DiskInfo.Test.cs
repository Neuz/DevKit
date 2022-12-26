namespace Neuz.DevKit.SystemInfo.Test;

[TestClass]
public class DiskInfoTest
{
    [TestMethod]
    public void DiskInfoTest_1()
    {
        var aa = DiskInfo.GetDisks();
        foreach (var diskInfo in aa)
        {
            Console.WriteLine(diskInfo.Name);
            Console.WriteLine(diskInfo.VolumeLabel);
            Console.WriteLine(diskInfo.DriveTypeString);
            Console.WriteLine(diskInfo.DriveType);
            Console.WriteLine(diskInfo.DriveFormat);
            Console.WriteLine(diskInfo.IsReady);
            Console.WriteLine(diskInfo.RootDirectory);
            Console.WriteLine(diskInfo.TotalSize);
            Console.WriteLine(diskInfo.UsedSize);
            Console.WriteLine(diskInfo.FreeSpace);


            Console.WriteLine("---------");
        }
    }
}