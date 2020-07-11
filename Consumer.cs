using System;
using System.Diagnostics;
using System.Threading;

namespace MultiThread
{
    public class Consumer // 客
    {
        private readonly int consumerId;
        private readonly Table table;

        public Consumer(int i, Table table)
        {
            this.consumerId = i;
            this.table = table;
        }

        public void ThreadStart()
        {
            (new Thread(new ThreadStart(Consume))).Start();
        }

        public void Consume()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (true) {
                // 終わりフラグが立っていたら終了
                if (table.Finished)
                    break;

                // テーブルから料理を取り、消費する
                string id = table.Take();

                // 取った値がnullだったら終わり
                if (string.IsNullOrEmpty(id)) {
                    // テーブルに終わりフラグを置く
                    table.Finished = true;
                    break;
                }

                Dish.Consume();
                Console.WriteLine(id + " ごちそうさん: " + consumerId);
            }
            Console.WriteLine("おあいそ: " + consumerId + ", " + sw.ElapsedMilliseconds);
        }
    }
}
