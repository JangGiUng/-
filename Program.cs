
using System;
using System.Collections;

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


class Report
{
    static void Main(String[] args)
    {
        LinkedList stakckList= new LinkedList();

        String[] stackArgs= new String[10];

        Random parking=new Random();

        for(int i=0; i<stackArgs.Length; i++)
        {
            
            stakckList.push(parking.Next(1, 20) + "");

            stackArgs[i]= parking.Next(1, 20) + "";

            Console.WriteLine("링크드 주차장에 {0}번 자동차가, 배열 주차장에는 {1}번 자동차가 주차되었습니다.", stakckList.LinkHead(), stackArgs[i]);
            Console.WriteLine();

        }

        stakckList.retrun();

        Console.Write("현재 배열 주차장에 주차된 차는 ");
        if (stackArgs[0] != null)
        {
            for (int i = 0; i < stackArgs.Length; i++)
            {
                Console.Write(stackArgs[i]+"번");
                if (i < stackArgs.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("입니다. ");
        }
        else
        {
            Console.WriteLine("없습니다. ");
        }
        Console.WriteLine();


        for (int i = stackArgs.Length-1; i >=0; i--)
        {
            String key = stakckList.LinkTail();

            Console.WriteLine("링크드 주차장에 {0}번 자동차가, 배열 주차장에는 {1}번 자동차가 빠져나갑니다.", key, stackArgs[i]);
            Console.WriteLine();

            stakckList.pop(key);
            stackArgs[i] = "";

        }

        stakckList.retrun();

        Console.Write("현재 배열 주차장에 주차된 차는 ");
        if (stackArgs[0] != "")
        {
            for (int i = 0; i < stackArgs.Length; i++)
            {
                Console.Write(stackArgs[i] + "번");
                if (i < stackArgs.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("입니다. ");
        }
        else
        {
            Console.WriteLine("없습니다. ");
        }


    }
}