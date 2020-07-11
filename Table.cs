using System.Collections.Generic;
using System.Threading;

namespace MultiThread
{
    public sealed class Table // テーブル
    {
        // テーブルに置くことができる料理の最大数
        private readonly int max = 100;
        private readonly Queue<string> queue = new Queue<string>(); // テーブルの実体
        private readonly object lockObject = new object();
        private bool finished = false;

        public void Put(string dish)
        {
            Monitor.Enter(lockObject);

            try {
                while (queue.Count >= max) {
                    // テーブルがいっぱいで料理を置くことができなかったら、
                    // ウェイトセットに入る
                    Monitor.Wait(lockObject);
                }
                queue.Enqueue(dish);

                // ウェイトセットのスレッドを起こす
                Monitor.PulseAll(lockObject);
            } catch {
            } finally {
                Monitor.Exit(lockObject);
            }
        }

        public string Take()
        {
            Monitor.Enter(lockObject);

            string dish = string.Empty;

            try {
                // 終了してたらnullを返す
                //if (finished)
                //    return null;

                while (queue.Count == 0) {
                    // テーブルに料理がなかったら、ウェイトセットに入る
                    Monitor.Wait(lockObject);
                }
                dish = queue.Dequeue();
                // nullが取れたら終了フラグを立てる
                //if (dish == null)
                //    finished = true;

                // ウェイトセットのスレッドを起こす
                Monitor.PulseAll(lockObject);
            } catch {
            } finally {
                Monitor.Exit(lockObject);
            }

            return dish;
        }

        public bool Finished
        {
            get { return finished; }
            set { finished = value; }
        }
    }
}
