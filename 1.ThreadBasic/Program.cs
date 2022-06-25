using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1.ThreadBasic
{
    class Program
    {
        // 1、使用线程直接调用方法
        public static void Fun()
        {
            Console.WriteLine("Started");
            Thread.Sleep(3000);
            Console.WriteLine("Completed");
        }

        // 3、在线程中传递单个参数
        // 模拟开启一个线程从一个地址下载东西
        public static void DownLoad(Object o)
        {
            string str = o as string;
            Console.WriteLine("从" + str + "下载内容");
        }

        // 4、在线程中传递多个参数
        //传递多个参数需要在结构体中定义参数数据
        public struct Data
        {
            public string name;
            public int age;
        }

        public static void UseData(Object o)
        {
            Data data = (Data)o;
            Console.WriteLine("Name:" + data.name + "\n" + "Age:" + data.age);
        }

        static void ThreadChild()
        {
            Console.WriteLine("Child thread " + Thread.CurrentThread.Name + " start");
            Console.WriteLine("Child thread ID" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            Console.WriteLine("Child thread " + Thread.CurrentThread.Name + " end");
        }


        static void Main(string[] args)
        {
            // 1、使用线程直接调用方法
            //Thread thread1 = new Thread(Fun);
            //thread1.Start();

            // 2、使用lamda表达式实现线程中的内容
            //Thread thread2 = new Thread(()=>
            //{
            //    //同时打印子进程的ID
            //    Console.WriteLine("Child Thread" + Thread.CurrentThread.ManagedThreadId);
            //});
            //thread2.Start();

            //================在线程中传递参数======================

            // 3、在线程中传递单个参数
            //Thread thread3 = new Thread(DownLoad);
            //thread3.Start("http://www.xxx.xxx");

            // 4、在线程中传递多个参数
            //Data data = new Data();
            //data.name = "ZLY";
            //data.age = 10;
            //Thread thread4 = new Thread(UseData);
            //thread4.Start(data);

            //5、在自定义类中传递数据参数
            //var downloadTool = new DownloadTool("http://www.xxx.xxx", "asdfg");
            //Thread thread5 = new Thread(downloadTool.Download);
            //thread5.Start();

            //6、前台线程与后台线程
            //如果是前台线程，那么主线程停止后线程会继续执行
            //如果是后台线程，那么主线程停止后线程会停止执行
            Thread thread6 = new Thread(ThreadChild);
            thread6.IsBackground = false;
            thread6.Start();
            Console.WriteLine("Mian thread ending now");
            Console.WriteLine("Mian thread ID " + Thread.CurrentThread.ManagedThreadId);

            Console.ReadLine();
        }
    }
}
