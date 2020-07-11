using System;
using System.Diagnostics;
using System.Threading;

namespace MultiThread
{
    public class Consumer // �q
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
                // �I���t���O�������Ă�����I��
                if (table.Finished)
                    break;

                // �e�[�u�����痿�������A�����
                string id = table.Take();

                // ������l��null��������I���
                if (string.IsNullOrEmpty(id)) {
                    // �e�[�u���ɏI���t���O��u��
                    table.Finished = true;
                    break;
                }

                Dish.Consume();
                Console.WriteLine(id + " ������������: " + consumerId);
            }
            Console.WriteLine("��������: " + consumerId + ", " + sw.ElapsedMilliseconds);
        }
    }
}
