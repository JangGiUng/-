using System;
using System.IO;

class head
{
    static void Main(string[] args)
    {
        Console.WriteLine("파일명을 입력하세요 (여러 개의 파일을 처리할 수 있습니다. 공백으로 구분합니다. 종료하려면 빈 줄을 입력하세요):");

        string input = Console.ReadLine();
        string[] fileNames = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int lineCount = 10; // 출력할 첫 번째 줄부터의 라인 수
        int byteCount = -1; // 출력할 바이트 수, -1은 기본값으로 전체 출력을 의미
        bool quietMode = false; // 제목을 출력하지 않는 quiet 모드

        // 첫 번째 입력이 옵션인지 확인
        bool hasOptions = false;
        if (fileNames.Length > 0 && fileNames[0].StartsWith("-"))
            hasOptions = true;

        // 첫 번째 입력이 옵션인 경우 처리
        if (hasOptions)
        {
            string option = fileNames[0];

            switch (option)
            {
                case "-n":
                    if (fileNames.Length > 2 && int.TryParse(fileNames[1], out int n))
                        lineCount = n;
                    // 옵션 처리 후 파일명 재조정
                    fileNames = fileNames[2..];
                    break;

                case "-c":
                    if (fileNames.Length > 2 && int.TryParse(fileNames[1], out int c))
                        byteCount = c;
                    // 옵션 처리 후 파일명 재조정
                    fileNames = fileNames[2..];
                    break;

                case "-q":
                    quietMode = true;
                    // 옵션 처리 후 파일명 재조정
                    fileNames = fileNames[1..];
                    break;

                default:
                    Console.WriteLine($"잘못된 옵션: {option}");
                    return;
            }
        }

        foreach (string fileName in fileNames)
        {
            string trimmedFileName = fileName.Trim();

            if (!quietMode)
                Console.WriteLine($"--- {trimmedFileName}의 내용 ---");

            try
            {
                using (StreamReader reader = new StreamReader(trimmedFileName))
                {
                    if (byteCount > -1)
                    {
                        char[] buffer = new char[byteCount];
                        int bytesRead = reader.Read(buffer, 0, byteCount);
                        Console.WriteLine(new string(buffer, 0, bytesRead));
                    }
                    else
                    {
                        for (int i = 0; i < lineCount; i++)
                        {
                            if (reader.EndOfStream)
                                break;

                            string line = reader.ReadLine();
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("파일을 찾을 수 없습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류가 발생했습니다: {ex.Message}");
            }

            Console.WriteLine();
        }
    }
}
