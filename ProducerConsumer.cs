namespace MultiThread
{
    public class ProducerConsumer
    {
        const int producerCount = 1;
        const int consumerCount = 4;

        public static void JobStart()
        {
            Table table = new Table(); // 共有スペースであるテーブル

            for (int i = 0; i < producerCount; i++) {
                (new Producer(i, table)).ThreadStart();
            }
            for (int i = 0; i < consumerCount; i++) {
                (new Consumer(i, table)).ThreadStart();
            }
        }
    }
}
