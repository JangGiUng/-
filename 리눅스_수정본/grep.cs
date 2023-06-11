using System;
using System.IO;
using System.Text.RegularExpressions;// 다양한 상황에서 문자열 패턴 매칭과 검색을 수행하게 해주는 도구,

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("옵션과 패턴을 입력하세요 (예: -in hello):");
        string input = Console.ReadLine();
        string[] inputParts = input.Split(' ');

        if (inputParts.Length < 2)
        {
            Console.WriteLine("잘못된 입력입니다. 옵션과 패턴을 입력해야 합니다.");
            return;
        }

        string options = inputParts[0];
        string pattern = inputParts[1];

        Console.WriteLine("파일 경로를 입력하세요:");
        string filename = Console.ReadLine();

        // 사용자가 *을 포함한 파일명을 입력한 경우
        if (filename.Contains("*"))
        {
            string directoryPath = Path.GetDirectoryName(filename);
            string searchPattern = Path.GetFileName(filename);

            // 파일명에 *.(확장자명)을 입력한 경우
            if (searchPattern.Contains("*"))
            {
                string fileExtension = searchPattern.Replace("*.", "");
                SearchExtension(directoryPath, pattern, fileExtension);
            }
            // 현재 디렉토리 내 모든 파일에서 탐색하는 경우
            else if (searchPattern == "*")
            {
                SearchAll(pattern);
            }
        }
        // 단일 파일명을 입력한 경우
        else
        {
            SearchFile(pattern, filename);
        }
    }

    static void SearchFile(string pattern, string filename)
    {
        // 주어진 파일명이 존재하지 않으면 해당 메시지를 출력하고 종료합니다.
        if (!File.Exists(filename))
        {
            Console.WriteLine($"파일이 존재하지 않습니다: {filename}");
            return;
        }

        try
        {
            // 파일의 모든 줄을 읽어옵니다.
            string[] lines = File.ReadAllLines(filename);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                // 패턴이 해당 줄에 포함되어 있다면, 줄 번호와 함께 해당 줄을 출력합니다.
                if (line.Contains(pattern))
                {
                    Console.WriteLine($"[{filename}:{i + 1}] {line}");
                }
            }
        }
        catch (Exception ex)
        {
            // 파일 읽기나 처리 중에 오류가 발생하면 해당 예외 메시지를 출력합니다.
            Console.WriteLine($"오류 발생: {ex.Message}");
        }
    }

    static void SearchExtension(string directoryPath, string pattern, string fileExtension)
    {
        // 주어진 디렉토리 경로가 존재하지 않으면 해당 메시지를 출력하고 종료합니다.
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine($"디렉토리가 존재하지 않습니다: {directoryPath}");
            return;
        }

        try
        {
            // 주어진 디렉토리에서 확장자에 해당하는 파일들을 검색합니다.
            string[] files = Directory.GetFiles(directoryPath, fileExtension);
            foreach (string file in files)
            {
                // 각 파일에 대해 SearchFile 메서드를 호출하여 패턴을 검색합니다.
                SearchFile(pattern, file);
            }
        }
        catch (Exception ex)
        {
            // 디렉토리나 파일 검색 중에 오류가 발생하면 해당 예외 메시지를 출력합니다.
            Console.WriteLine($"오류 발생: {ex.Message}");
        }
    }

    static void SearchAll(string pattern)
    {
        // 현재 작업 디렉토리를 가져옵니다.
        string currentDirectory = Environment.CurrentDirectory;
        // 현재 디렉토리와 하위 디렉토리의 모든 파일을 검색합니다.
        string[] files = Directory.GetFiles(currentDirectory, "*", SearchOption.AllDirectories);

        foreach (string file in files)
        {
            // 각 파일에 대해 SearchFile 메서드를 호출하여 패턴을 검색합니다.
            SearchFile(pattern, file);
        }
    }

}
