using System.Collections.Generic;
using System.Threading;

namespace MultiThread
{
    public sealed class Table // �e�[�u��
    {
        // �e�[�u���ɒu�����Ƃ��ł��闿���̍ő吔
        private readonly int max = 100;
        private readonly Queue<string> queue = new Queue<string>(); // �e�[�u���̎���
        private readonly object lockObject = new object();
        private bool finished = false;

        public void Put(string dish)
        {
            Monitor.Enter(lockObject);

            try {
                while (queue.Count >= max) {
                    // �e�[�u���������ς��ŗ�����u�����Ƃ��ł��Ȃ�������A
                    // �E�F�C�g�Z�b�g�ɓ���
                    Monitor.Wait(lockObject);
                }
                queue.Enqueue(dish);

                // �E�F�C�g�Z�b�g�̃X���b�h���N����
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
                // �I�����Ă���null��Ԃ�
                //if (finished)
                //    return null;

                while (queue.Count == 0) {
                    // �e�[�u���ɗ������Ȃ�������A�E�F�C�g�Z�b�g�ɓ���
                    Monitor.Wait(lockObject);
                }
                dish = queue.Dequeue();
                // null����ꂽ��I���t���O�𗧂Ă�
                //if (dish == null)
                //    finished = true;

                // �E�F�C�g�Z�b�g�̃X���b�h���N����
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
