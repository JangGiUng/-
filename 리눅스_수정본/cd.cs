using System;
using System.IO;

internal class Cd
{
    public static void Main()
    {
        while (true) // 무한 반복
        {
            Console.Write("이동할 디렉토리 경로를 입력하세요 (':q' 또는 'exit'로 종료): ");
            string input = Console.ReadLine();

            if (input == ":q" || input == "exit") // 종료 조건 확인
                break; // 반복문 종료

            string[] inputParts = input.Split(' '); // 입력된 경로와 옵션을 분리

            string directory = inputParts[0]; // 입력된 경로
            string option = (inputParts.Length > 1) ? inputParts[1] : null; // 입력된 옵션

            try
            {
                if (option == "-P") // '-P' 옵션: 심볼릭 링크 경로를 무시하고 절대 경로로 이동.
                {
                    directory = Path.GetFullPath(directory); // 상대경로를 절대 경로로 반환.
                }
                else if (option == "-L") // '-L' 옵션: CD 옵션의 기본 옵션이므로 별도의 행동 필요 없음.
                {

                }
                else if (option == "--help") // '--help' 옵션: 도움말
                {
                    Console.WriteLine("cd 명령어 : 현재 작업 디렉토리를 변경하여 다른 디렉토리로 이동하는 데 사용됩니다.\r\n\r\n'cd' 명령어의 주요 역할은 다음과 같습니다: ");
                    Console.WriteLine("-P : 심볼릭 링크를 무시하고 링크된 대상의 절대 경로로 이동.");
                    Console.WriteLine("-L : cd 명령어의 기본 옵션.");
                    Console.WriteLine("--help : 도움말을 표시.");
                    continue; // 반복문 처음으로 이동
                }
                else if (option != null) // 유효하지 않은 옵션인 경우
                {
                    Console.WriteLine("유효하지 않은 옵션입니다.");
                    continue; // 반복문 처음으로 이동
                }

                Directory.SetCurrentDirectory(directory); // .NET Framework 메서드. 전달된 directory로 현재 작업 디렉토리 변경.

                Console.WriteLine($"현재 작업 디렉토리: {Directory.GetCurrentDirectory()}");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("해당 디렉토리를 찾을 수 없습니다.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"오류 발생: {e.Message}");
            }
        }
    }
}