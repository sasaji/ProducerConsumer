using System;
using System.Threading;

namespace MultiThread
{
    public class Dish
    {
        public static void Produce()
        {
            Thread.Sleep(100); // 5�b���Ƃ�1�����쐬�ł���
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            Thread.Sleep(rnd.Next(1000));
        }

        public static void Consume()
        {
            Thread.Sleep(1000); // ����ɂ͎��Ԃ�������
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            Thread.Sleep(rnd.Next(1000));
        }
    }
}
