using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ThreadPoolBasic
{
    class Program
    {
        //线程池启动的默认都是后台线程，如果进程的所有前台线程都结束了，所有的后台线程就会停止
        //不能把入池的线程改为前台线程
        //不能给入池的线程涉恶之优先级或名称
        //入池的线程只能用于时间较短的任务。如果要线程一直运行，就应使用Thread类创建一个线程
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(DownLoad);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 模拟多个任务进行下载
        /// </summary>
        static void DownLoad(Object state)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Downloading ...:" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            }
        }
    }
}
