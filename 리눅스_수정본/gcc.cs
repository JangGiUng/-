using System;
using System.Diagnostics;//프로세스 사용 가능 하게 설정.

class Gcc
{
    static void Main(string[] args)
    {
        Console.WriteLine("컴파일할 파일과 실행 파일의 이름을 gcc [컴파일 파일 명] -o [실행 파일 명] 형태로 입력하세요:");
        string input = Console.ReadLine();

        // 입력을 공백으로 분리하여 배열로 저장합니다.
        string[] inputParts = input.Split(' ');

        // 입력 형식이 올바른지 확인합니다. "gcc [소스 파일] -o [실행 파일]" 형식이어야 합니다.
        if (inputParts.Length != 4 || inputParts[0] != "gcc" || inputParts[2] != "-o")
        {
            Console.WriteLine("올바른 형식으로 입력하세요. 예: gcc [소스 파일] -o [실행 파일]");
            return;
        }

        // 입력에서 소스 파일과 실행 파일의 경로를 가져옵니다.
        string sourceFilePath = inputParts[1];
        string outputFilePath = inputParts[3];

        // 프로세스를 생성하여 C# 컴파일러를 실행합니다.
        Process process = new Process();
        process.StartInfo.FileName = "csc";  // C# 컴파일러 경로
        process.StartInfo.Arguments = $"/out:{outputFilePath} {sourceFilePath}";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        process.Start();

        // 컴파일러의 출력과 에러 메시지를 읽어옵니다.
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();

        process.WaitForExit();

        // 컴파일 성공 여부에 따라 결과를 출력합니다.
        if (process.ExitCode == 0)
        {
            Console.WriteLine("컴파일 성공");
            Console.WriteLine($"출력 파일: {outputFilePath}");
        }
        else
        {
            Console.WriteLine("컴파일 실패");
            Console.WriteLine($"에러 메시지: {error}");
        }
    }
}
