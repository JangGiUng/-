using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("명령어와 옵션, 파일을 입력하세요 (예: who -a /var/log/wtmp):");
        string input = Console.ReadLine();

        string[] inputParts = input.Split(' ', 3);
        string command = inputParts.Length > 0 ? inputParts[0] : string.Empty;
        string option = inputParts.Length > 1 ? inputParts[1] : "-a";
        string file = inputParts.Length > 2 ? inputParts[2] : string.Empty;

        if (command.Equals("who", StringComparison.OrdinalIgnoreCase))
        {
            if (!IsValidOption(option))
            {
                Console.WriteLine("유효하지 않은 옵션입니다.");
                return;
            }
            else
            {
                ExecuteWhoCommand(option, file);
            }
        }
        else if (command.Equals("whoami", StringComparison.OrdinalIgnoreCase))
        {
            ExecuteWhoCommand("-m", file);
        }
        else
        {
            Console.WriteLine("유효한 명령어가 아닙니다.");
        }
    }

    static bool IsValidOption(string option)
    {
        string[] validOptions = { "-a", "-b", "-d", "-l", "-m", "-p" };
        return Array.IndexOf(validOptions, option) >= 0;
    }

    static void ExecuteWhoCommand(string option, string file)
    {
        string command = $"/usr/bin/who {option} {file}";

        Process process = new Process();
        process.StartInfo.FileName = "/bin/bash";
        process.StartInfo.Arguments = $"-c \"{command}\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        Console.WriteLine(output);
    }


}
