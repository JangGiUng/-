using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("명령어를 입력하세요:");
        string command = Console.ReadLine();

        if (command.Equals("who", StringComparison.OrdinalIgnoreCase))
        {
            ExecuteWhoCommand();
        }
        else if (command.Equals("who am i", StringComparison.OrdinalIgnoreCase))
        {
            ExecuteWhoAmICommand();
        }
        else
        {
            Console.WriteLine("유효한 명령어가 아닙니다.");
        }
    }

    static void ExecuteWhoCommand()
    {
        Process process = new Process();
        process.StartInfo.FileName = "/usr/bin/who";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        Console.WriteLine(output);
    }

    static void ExecuteWhoAmICommand()
    {
        Process process = new Process();
        process.StartInfo.FileName = "/usr/bin/who";
        process.StartInfo.Arguments = "am i";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        Console.WriteLine(output);
    }
}
