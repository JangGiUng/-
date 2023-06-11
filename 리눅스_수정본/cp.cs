using System;
using System.IO;

public class Cp
{
    public static void CopyFile(string sourcePath, string destinationPath)
    {
        if (File.Exists(destinationPath))
        {
            Console.WriteLine("경고: 대상 위치에 이미 같은 이름의 파일이 존재합니다.");

            Console.WriteLine("덮어쓰기 작업을 실행하시겠습니까? (y/n)");
            string overwriteInput = Console.ReadLine();
            bool overwrite = (overwriteInput == "y" || overwriteInput == "Y");

            if (!overwrite)
            {
                Console.WriteLine("덮어쓰기 작업이 취소되었습니다.");
                return;
            }
        }

        try
        {
            File.Copy(sourcePath, destinationPath, true);
            Console.WriteLine("파일 복사 성공");
        }
        catch (Exception e)
        {
            Console.WriteLine("파일 복사 실패: " + e.Message);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("원본 파일 경로를 입력하세요:");
        string sourcePath = Console.ReadLine();

        Console.WriteLine("복사할 위치를 입력하세요:");
        string destinationPath = Console.ReadLine();

        Cp.CopyFile(sourcePath, destinationPath);
    }
}
