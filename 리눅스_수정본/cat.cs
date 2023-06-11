using System;
using System.IO;

class Cat
{
    public static void PrintFile(string option, string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            int lineCount = lines.Length;

            if (option == "-n")
            {
                for (int i = 0; i < lineCount; i++)
                {
                    Console.WriteLine($"{i + 1}: {lines[i]}");
                }
            }
            else if (option == "-r")
            {
                for (int i = lineCount - 1; i >= 0; i--)
                {
                    Console.WriteLine(lines[i]);
                }
            }
            else if (option == "-nr")
            {
                for (int i = lineCount - 1; i >= 0; i--)
                {
                    Console.WriteLine($"{i + 1}: {lines[i]}");
                }
            }
            else
            {
                Console.WriteLine("잘못된 옵션입니다.");
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("파일을 읽는 도중 오류가 발생했습니다: " + ex.Message);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("사용법: cat <옵션> <파일명>");
        Console.WriteLine("옵션:");
        Console.WriteLine("  -n   각 줄에 줄번호를 추가하여 출력");
        Console.WriteLine("  -r   파일의 내용을 역순으로 출력");
        Console.WriteLine("  -nr  각 줄에 줄번호를 추가하고, 파일의 내용을 역순으로 출력");

        Console.Write("명령어 입력: ");
        string input = Console.ReadLine();

        string[] inputs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (inputs.Length < 2)
        {
            Console.WriteLine("올바른 명령어 형식이 아닙니다.");
            return;
        }

        string option = inputs[0];
        string filePath = inputs[1];

        Cat.PrintFile(option, filePath);
    }
}
