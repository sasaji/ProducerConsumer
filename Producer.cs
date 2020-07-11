using System;
using System.Threading;

namespace MultiThread
{
    public class Producer // 料理人
    {
        const int dishCount = 50;
        private readonly int producerId;
        private readonly Table table;
        private static int id = 1;
        private readonly object lockObject = new object();

        public Producer(int i, Table table)
        {
            this.producerId = i;
            this.table = table;
        }

        public void ThreadStart()
        {
            (new Thread(new ThreadStart(Produce))).Start();
        }

        private void Produce()
        {
            string dish;

            while (id <= dishCount) {
                lock (lockObject) // idの値を排他制御するためのロック
                    dish = "No." + id++;

                // 料理（dish）を作成して、テーブルに置く
                Dish.Produce();
                table.Put(dish);
                Console.WriteLine(dish + " できたよ: " + producerId);
            }

            // 最後にnullを置く
            table.Put(null);
            Console.WriteLine("おしまい: " + producerId);
            return;
        }
    }
}
