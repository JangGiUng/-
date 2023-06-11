using System;
using System.IO;

public class FileCopier
{
    public static void CopyFile(string sourcePath, string destinationPath)
    {
        try
        {
            File.Copy(sourcePath, destinationPath);
            Console.WriteLine("File copied successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine("File copy failed: " + e.Message);
        }
    }
}
