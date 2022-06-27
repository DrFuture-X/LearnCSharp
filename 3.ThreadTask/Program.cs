using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.ThreadTask
{
    class Program
    {
        //Task在后台是使用ThreadTool进行管理的，也就是在后台运行
        static void Main(string[] args)
        {
            //1.使用TaskFactory创建任务
            //TaskFactory tf = new TaskFactory();
            //tf.StartNew(Download);

            //2.使用Task创建任务
            //Task t = new Task(Download);
            //t.Start();

            //3.连续任务，t1任务下载完成后进行t2任务，t2任务是提示信息，依次后推
            Task t1 = new Task(Download_1);
            Task t2 = t1.ContinueWith(ShowAlert);
            Task t3 = t2.ContinueWith(Download_2);
            Task t4 = t3.ContinueWith(ShowAlert);
            t1.Start();

            Console.ReadKey();
        }

        static void Download()
        {
            Console.WriteLine("Download...");
        }

        static void Download_1()
        {
            Console.WriteLine("Download_1...");
            Thread.Sleep(2000);
        }
        static void Download_2(Task task)
        {
            Console.WriteLine("Download_2...");
            Thread.Sleep(2000);
        }
        static void ShowAlert(Task task)
        {
            Console.WriteLine(task.Id + " xxx download completed");
        }
    }
}
