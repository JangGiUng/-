using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("사용법: rm <파일_경로>");
            return;
        }

        string filePath = args[0];

        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("파일이 성공적으로 삭제되었습니다.");
            }
            else
            {
                Console.WriteLine("파일을 찾을 수 없습니다.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("오류가 발생했습니다: " + ex.Message);
        }
    }
}
