using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._02._2023_lecture
{
    public class Producer
    {
        private const int maxCount = 5;//кол-во итераций в цикле
        private int num;
        public int Num =>num;//свойство на чтение
        public Producer(int num)
        {
            this.num = num;
        }
        public void Start()//задаем какую-то функцию для работы продюсера(пока у нас имитация, поэтому просто sllep )
        {
            var t = new Thread(() =>//создается эта функция внутри потока
            {
                var iter = 0;// счетчик итераций
                while (iter++ < maxCount)
                {
                    var r = new Random();
                    Thread.Sleep(r.Next(2000, 5000));//время сна (от 2 до 5 сек)
                    var result = r.Next(1000);

                    Console.WriteLine($"Producer №{num}: {result}");

                    CommonData.Put(num, result);
                }
            });
            t.IsBackground = true;//поток фоновый
            t.Start();
        }
    }
}
