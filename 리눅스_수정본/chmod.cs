using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("옵션, 모드, 대상명 입력 (예: +rwx 파일명): ");
        string input = Console.ReadLine(); // 옵션, 모드, 대상명 입력 받기

        // 입력된 문자열을 공백으로 분할하여 배열로 저장
        string[] tokens = input.Split(' ');

        if (tokens.Length < 2 || tokens.Length > 3)
        {
            Console.WriteLine("잘못된 입력입니다.");
            return;
        }

        string options = ""; // 옵션 초기화
        string mode = "";
        string filePath = "";

        if (tokens.Length == 2)
        {
            mode = tokens[0];
            filePath = tokens[1];
        }
        else if (tokens.Length == 3)
        {
            options = tokens[0];
            mode = tokens[1];
            filePath = tokens[2];
        }

        // 옵션에 따라 처리
        foreach (char option in options)
        {
            switch (option)
            {
                case '+':
                    AddPermissions(filePath, mode);
                    break;
                case '-':
                    RemovePermissions(filePath, mode);
                    break;
                case '=':
                    SetPermissions(filePath, mode);
                    break;
                default:
                    Console.WriteLine("잘못된 옵션입니다.");
                    break;
            }
        }

        // 모드와 대상명 출력
        Console.WriteLine("모드: " + mode);
        Console.WriteLine("대상명: " + filePath);
    }

    static void AddPermissions(string filePath, string mode)
    {
        try
        {
            // 파일 권한을 변경할 파일 경로로 FileInfo 객체 생성
            FileInfo fileInfo = new FileInfo(filePath);

            // 현재 권한을 가져옴
            FileAttributes currentAttributes = fileInfo.Attributes;

            // 변경할 권한 값을 8진수로 해석하여 파일 권한 설정
            int octalPermissions = Convert.ToInt32(mode, 8);

            // 현재 권한에 추가
            fileInfo.Attributes = currentAttributes | (FileAttributes)octalPermissions;

            Console.WriteLine("파일 권한이 변경되었습니다.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("파일 권한 변경 중 오류가 발생했습니다: " + ex.Message);
        }
    }

    static void RemovePermissions(string filePath, string mode)
    {
        try
        {
            // 파일 권한을 변경할 파일 경로로 FileInfo 객체 생성
            FileInfo fileInfo = new FileInfo(filePath);

            // 현재 권한을 가져옴
            FileAttributes currentAttributes = fileInfo.Attributes;

            // 변경할 권한 값을 8진수로 해석하여 파일 권한 설정
            int octalPermissions = Convert.ToInt32(mode, 8);

            // 현재 권한에서 제거
            fileInfo.Attributes = currentAttributes & ~(FileAttributes)octalPermissions;

            Console.WriteLine("파일 권한이 변경되었습니다.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("파일 권한 변경 중 오류가 발생했습니다: " + ex.Message);
        }
    }

    static void SetPermissions(string filePath, string mode)
    {
        try
        {
            // 파일 권한을 변경할 파일 경로로 FileInfo 객체 생성
            FileInfo fileInfo = new FileInfo(filePath);

            // 변경할 권한 값을 8진수로 해석하여 파일 권한 설정
            int octalPermissions = Convert.ToInt32(mode, 8);

            // 권한을 직접 설정
            fileInfo.Attributes = (FileAttributes)octalPermissions;

            Console.WriteLine("파일 권한이 변경되었습니다.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("파일 권한 변경 중 오류가 발생했습니다: " + ex.Message);
        }
    }
}
