using System;
using System.IO;

class mv
{
    public static void MoveFileOrDirectory(string sourcePath, string destinationPath, string option)
    {
        // 이동할 경로에 이미 존재하는지 확인
        if (Directory.Exists(destinationPath) || File.Exists(destinationPath))//v파일 또는 디렉토리의 존재 확인
        {
            throw new IOException("이동할 경로에 이미 파일 또는 디렉토리가 존재합니다.");//메시지를 가진 오류가 throw, 상위 메서드에서 예외처리.
        }

        if (option == "-f")
        {
            // 파일 이동
            File.Move(sourcePath, destinationPath);
        }
        else if (option == "-d")
        {
            // 디렉토리 이동
            Directory.Move(sourcePath, destinationPath);
        }
        else
        {
            throw new ArgumentException("올바른 옵션을 입력하세요. (파일 이동: -f, 디렉토리 이동: -d)");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("파일 또는 디렉토리 이동을 실행합니다.");
        Console.WriteLine("이동할 파일 또는 디렉토리의 경로를 입력하세요:");
        string sourcePath = Console.ReadLine(); // 사용자로부터 이동할 파일 또는 디렉토리의 경로를 입력 받습니다.

        Console.WriteLine("이동할 위치의 경로를 입력하세요:");
        string destinationPath = Console.ReadLine(); // 사용자로부터 이동할 위치의 경로를 입력 받습니다.

        Console.WriteLine("옵션을 입력하세요 (파일 이동: -f, 디렉토리 이동: -d):");
        string option = Console.ReadLine(); // 사용자로부터 옵션을 입력 받습니다.

        try
        {
            // 파일 또는 디렉토리 이동
            mv.MoveFileOrDirectory(sourcePath, destinationPath, option);

            Console.WriteLine("이동이 완료되었습니다.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("이동 중 오류가 발생했습니다: " + ex.Message);
        }
    }
}


