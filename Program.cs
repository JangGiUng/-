
using System;
using System.Collections;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

class Node
{
    public String data;
    public Node? next;

    public Node(String data)
    {
        this.data = data;
        next = null;

    }

}
class LinkedList
{
    Node? head;//시작 노드

    public void push(String data)//삽입
    {
        Node body=new Node(data);
        body.next = head;
        head = body;

    }
    public void pop(String key)//삭제
    {
        Node? temp = head;
        Node? prev = null;

        if (temp != null & temp.data == key)
        {
            head=temp.next;
            return;
        }

        while(temp != null&&temp.data!=key)
        {
            prev = temp;
            temp=temp.next;
        }

        if (temp == null)
        {
            return;
        }

        prev.next = temp.next;

    }

    public String LinkHead()
    {
        if (head == null)
        {
            return "No";
        }
           
        return head.data;

    }
    public String LinkTail()
    {
        Node ptr;
        ptr = head;
        while (ptr.next != null)
        {
            ptr = ptr.next;
        }
        return ptr.data;
    }

    public void retrun() 
    {
        Console.Write("현재 링크드 주차장에 주차된 차는 ");
        if (head != null){
            
            for (Node node = head; node != null; node = node.next)
            {
                Console.Write(node.data + "번");
                if(node.next != null)
                {
                    Console.Write(",");
                }

            }
            Console.WriteLine("입니다.");
        }
        else
        {
            Console.WriteLine("없습니다. ");
        }
       

    }




}//링크드


public class Array
{
    string[] arr;
    int top;

    public Array(int data)
    {
        this.arr = new string[data];
        this.top = -1;

    
    }

    public void push(string data)
    {
        this.arr[++top] = data;
    }

    public string pop()
    {
        String Data = "";
        if (top==-1)
        {
            return "no";
        }
        else
        {
            Data = this.arr[this.top];
            this.arr[this.top] = "";
            this.top--;
            return Data;
        }
        
    }

    public int leng()
    {
        return this.arr.Length;
    }

    public String arrHead()
    {
        
        return arr[top];

    }
    public String arrTail()
    {
        int temp = 0;
        String tail = arr[temp];
        while (arr[++temp] != "")
        {
            tail = arr[++temp];
        }
        return tail;
    }

    public void retrun()
    {
        Console.Write("현재 배열 주차장에 주차된 차는 ");
        if (arr[0] != "")
        {

            for (int i=0;i<this.arr.Length;i++)
            {
                Console.Write(arr[i] + "번");
                int next = i + 1;
                if (next!=arr.Length)
                {
                    Console.Write(",");

                }

            }
            Console.WriteLine("입니다.");
        }
        else
        {
            Console.WriteLine("없습니다. ");
        }


    }


}//배열


class Report
{
    static void Main(String[] args)
    {
        LinkedList stakckList= new LinkedList();

        Array stackArgs= new Array(10);

        int leng=stackArgs.leng();

        Random parking=new Random();

        for (int i = 0; i < leng; i++)
        {
            
            stakckList.push(parking.Next(1, 20) + "");
            stackArgs.push(parking.Next(1, 20) + "");

            Console.WriteLine("링크드 주차장에 {0}번 자동차가, 배열 주차장에는 {1}번 자동차가 주차되었습니다.", stakckList.LinkHead(), stackArgs.arrHead());
            Console.WriteLine();

        }

        stakckList.retrun();
        stackArgs.retrun();
        Console.WriteLine();

        for (int i = leng-1; i >= 0; i--)
        {
            String key=stakckList.LinkTail();

            stakckList.pop(key);

            Console.WriteLine("링크드 주차장에 {0}번 자동차가, 배열 주차장에는 {1}번 자동차가 나갑니다.", key, stackArgs.pop());
            Console.WriteLine();

        }


        
        stakckList.retrun();
        stackArgs.retrun();




    }
}