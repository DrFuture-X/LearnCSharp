using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4.ThreadLock
{
    //使用锁解决资源单个资源占用的问题
    internal class Program
    {
        private static int apple = 10;              //10个苹果
        private static object locker = new object();//创建锁

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => EatApple("张三"));
            Thread t2 = new Thread(() => EatApple("李四"));
            t1.IsBackground = true;
            t2.IsBackground = true;
            t1.Name = "线程1";
            t2.Name = "线程2";
            t1.Start();
            t2.Start();
            Console.ReadKey();
        }
        private static void EatApple(string name)
        {
            while (true)
            {

                lock (locker)//加锁
                {
                    Console.WriteLine(Thread.CurrentThread.Name + "==");
                    apple -= 1;
                    Console.WriteLine(name + "正在吃苹果");
                    Thread.Sleep(1000);
                    Console.WriteLine(name + "吃完了,还剩" + apple + "个苹果\n");
                    if (apple <= 1)//变为1 不然会吃-1个苹果
                        break;
                    Console.WriteLine(Thread.CurrentThread.Name + "++");
                }
            }
        }
    }
}
