using System;
using System.Threading;

namespace MultiThread
{
    public class Dish
    {
        public static void Produce()
        {
            Thread.Sleep(100); // 5•b‚²‚Æ‚É1—¿—ì¬‚Å‚«‚é
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            Thread.Sleep(rnd.Next(1000));
        }

        public static void Consume()
        {
            Thread.Sleep(1000); // Á”ï‚É‚ÍŠÔ‚ª‚©‚©‚é
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            Thread.Sleep(rnd.Next(1000));
        }
    }
}
