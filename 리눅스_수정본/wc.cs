using System;
using System.IO;
using System.Linq;

class WCCommand
{
    static void Main(string[] args)
    {
        Console.Write("wc [옵션] [파일이름] 형태로 입력(옵션은 생략 가능) : ");
        string command = Console.ReadLine();

        string[] commandParts = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (commandParts.Length < 1)
        {
            Console.WriteLine("잘못된 입력입니다. 형식: wc [옵션] [파일이름]");
            return;
        }

        string filePath = commandParts.LastOrDefault();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("파일이 존재하지 않습니다.");
            return;
        }

        bool countLines = false;
        bool countWords = false;
        bool countChars = false;

        try
        {
            for (int i = 0; i < commandParts.Length - 1; i++)
            {
                switch (commandParts[i])
                {
                    case "-l":
                        countLines = true;
                        break;
                    case "-w":
                        countWords = true;
                        break;
                    case "-c":
                        countChars = true;
                        break;
                    default:
                        throw new ArgumentException($"잘못된 옵션: {commandParts[i]}");
                }
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        if (!countLines && !countWords && !countChars)
        {
            countLines = true;
            countWords = true;
            countChars = true;

            int lineCount = 0;
            int wordCount = 0;
            int charCount = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineCount++;
                    charCount += line.Length;
                    string[] words = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    wordCount += words.Length;
                }
            }

            Console.WriteLine($"{lineCount} {wordCount} {charCount} {filePath}");
            return;
        }

        // 옵션이 입력된 경우 해당 옵션에 따라 처리를 진행하고 끝내기
        if (countLines)
        {
            int lineCount = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            Console.WriteLine($"라인 수: {lineCount}");
        }

        if (countWords)
        {
            int wordCount = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                string[] words = content.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                wordCount = words.Length;
            }
            Console.WriteLine($"단어 수: {wordCount}");
        }

        if (countChars)
        {
            int charCount = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                charCount = content.Length;
            }
            Console.WriteLine($"문자 수: {charCount}");
        }
    }
}
