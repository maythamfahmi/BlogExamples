using System.IO.Compression;

namespace TempFiles;

public class Program
{
    public static void Main(string[] args)
    {
        File.Delete(@"C:\temp\out\file1.txt.gz");

        AppDomain.CurrentDomain.ProcessExit += new EventHandler(GzipCompressor.ActionOnExit);
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GzipCompressor.ActionOnExit);

        var zip = new GzipCompressor();

        zip.Compress(@"C:\temp\in\file1.txt", @"C:\temp\out\file1.txt.gz");
    }
}

public class GzipCompressor : ICompressor
{
    private static FileInfo? _tmpFileInfo;

    public void Compress(string input, string output)
    {
        _tmpFileInfo = CreateTempFile();

        using (FileStream originalFileStream = File.OpenRead(input))
        using (FileStream compressedFileStream = File.OpenWrite(_tmpFileInfo!.FullName))
        using (GZipStream compressor = new GZipStream(compressedFileStream, CompressionMode.Compress))
        {
            originalFileStream.CopyTo(compressor);
        }

        File.Copy(_tmpFileInfo.FullName, output);
        File.Delete(_tmpFileInfo.FullName);
    }

    public static void ActionOnExit(object? sender, EventArgs e)
    {
        File.Delete(_tmpFileInfo.FullName);
    }

    public FileInfo? CreateTempFile()
    {
        var fileName = Path.GetTempFileName();
        FileInfo? fileInfo = new FileInfo(fileName)
        {
            Attributes = FileAttributes.Temporary
        };

        return fileInfo;
    }
}

public interface ICompressor
{
    public void Compress(string input, string output);
}