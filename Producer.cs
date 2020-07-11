using System;
using System.Threading;

namespace MultiThread
{
    public class Producer // �����l
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
                lock (lockObject) // id�̒l��r�����䂷�邽�߂̃��b�N
                    dish = "No." + id++;

                // �����idish�j���쐬���āA�e�[�u���ɒu��
                Dish.Produce();
                table.Put(dish);
                Console.WriteLine(dish + " �ł�����: " + producerId);
            }

            // �Ō��null��u��
            table.Put(null);
            Console.WriteLine("�����܂�: " + producerId);
            return;
        }
    }
}
