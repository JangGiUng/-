using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("시작 디렉토리와 검색 패턴을 입력하세요 (예: /경로/시작/디렉토리 *.txt): ");
        string input = Console.ReadLine();

        string[] inputParts = input.Split(' ');
        if (inputParts.Length != 2)
        {
            Console.WriteLine("잘못된 입력입니다. 시작 디렉토리와 검색 패턴을 공백으로 구분하여 입력하세요.");
            return;
        }

        string startPath = inputParts[0];
        string searchPattern = inputParts[1];

        Console.WriteLine("파일을 검색 중입니다...");

        FindFiles(startPath, searchPattern);

        Console.WriteLine("검색이 완료되었습니다.");
    }

    static void FindFiles(string directory, string searchPattern)
    {
        try
        {
            // find 명령어의 기본 동작: 현재 디렉토리에서 파일 찾기
            string[] files = Directory.GetFiles(directory, searchPattern);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

            // 서브디렉토리로 재귀적으로 진입
            string[] subDirectories = Directory.GetDirectories(directory);
            foreach (string subDirectory in subDirectories)
            {
                FindFiles(subDirectory, searchPattern);
            }
        }
        catch (UnauthorizedAccessException)
        {
            // 접근 권한이 없는 디렉토리인 경우 무시
        }
        catch (DirectoryNotFoundException)
        {
            // 디렉토리를 찾을 수 없는 경우 무시
        }
    }

    static void FindPrint0(string directory, string searchPattern)
    {
        try
        {
            // findprint0: 줄 바꿈 없이 출력
            string[] files = Directory.GetFiles(directory, searchPattern);
            foreach (string file in files)
            {
                Console.Write(file + '\0');
            }

            // 서브디렉토리로 재귀적으로 진입
            string[] subDirectories = Directory.GetDirectories(directory);
            foreach (string subDirectory in subDirectories)
            {
                FindPrint0(subDirectory, searchPattern);
            }
        }
        catch (UnauthorizedAccessException)
        {
            // 접근 권한이 없는 디렉토리인 경우 무시
        }
        catch (DirectoryNotFoundException)
        {
            // 디렉토리를 찾을 수 없는 경우 무시
        }
    }

    static void FindByName(string directory, string searchPattern, string name)
    {
        try
        {
            // FindByName: 이름으로 파일 찾기
            string[] files = Directory.GetFiles(directory, searchPattern);
            foreach (string file in files)
            {
                if (Path.GetFileName(file).Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(file);
                }
            }

            // 서브디렉토리로 재귀적으로 진입
            string[] subDirectories = Directory.GetDirectories(directory);
            foreach (string subDirectory in subDirectories)
            {
                FindByName(subDirectory, searchPattern, name);
            }
        }
        catch (UnauthorizedAccessException)
        {
            // 접근 권한이 없는 디렉토리인 경우 무시
        }
        catch (DirectoryNotFoundException)
        {
            // 디렉토리를 찾을 수 없는 경우 무시
        }
    }

    static void FindEmpty(string directory)
    {
        try
        {
            // FindEmpty: 빈 디렉토리 검색
            string[] files = Directory.GetFiles(directory);
            if (files.Length == 0)
            {
                Console.WriteLine(directory);
            }

            // 서브디렉토리로 재귀적으로 진입
            string[] subDirectories = Directory.GetDirectories(directory);
            foreach (string subDirectory in subDirectories)
            {
                FindEmpty(subDirectory);
            }
        }
        catch (UnauthorizedAccessException)
        {
            // 접근 권한이 없는 디렉토리인 경우 무시
        }
        catch (DirectoryNotFoundException)
        {
            // 디렉토리를 찾을 수 없는 경우 무시
        }
    }

    static void FindDelete(string directory, string searchPattern)
    {
        try
        {
            // FindDelete: 검색된 파일 삭제
            string[] files = Directory.GetFiles(directory, searchPattern);
            foreach (string file in files)
            {
                File.Delete(file);
                Console.WriteLine($"파일 삭제: {file}");
            }

            // 서브디렉토리로 재귀적으로 진입
            string[] subDirectories = Directory.GetDirectories(directory);
            foreach (string subDirectory in subDirectories)
            {
                FindDelete(subDirectory, searchPattern);
            }
        }
        catch (UnauthorizedAccessException)
        {
            // 접근 권한이 없는 디렉토리인 경우 무시
        }
        catch (DirectoryNotFoundException)
        {
            // 디렉토리를 찾을 수 없는 경우 무시
        }
    }

    enum FileType
    {
        File,
        Directory
    }
}
