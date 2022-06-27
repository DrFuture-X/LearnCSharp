using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.ThreadLock2
{
    internal class Program
    {
        //使用多个锁解决多个资源冲突的问题，需要设计锁定顺序，使资源锁的顺序一致，
        //防止出现死锁（锁冲突）问题
        static void Main(string[] args)
        {
            StateObject state = new StateObject();

            for (int i = 0; i < 20; i++)
            {
                Thread t1 = new Thread(state.ChangeState1);
                Thread t2 = new Thread(state.ChangeState2);
                t1.Start();
                t2.Start();
            }

            Console.ReadKey();
        }
    }
}
