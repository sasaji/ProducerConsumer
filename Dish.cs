using System;
using System.Threading;

namespace MultiThread
{
    public class Dish
    {
        public static void Produce()
        {
            Thread.Sleep(100); // 5秒ごとに1料理作成できる
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            Thread.Sleep(rnd.Next(1000));
        }

        public static void Consume()
        {
            Thread.Sleep(1000); // 消費には時間がかかる
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            Thread.Sleep(rnd.Next(1000));
        }
    }
}
