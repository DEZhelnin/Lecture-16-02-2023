using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._02._2023_lecture
{
    public class Consumer
    {
        public void Start()
        {
            var t = new Thread(() =>
            {
                while (true)
                {
                    var tResult = CommonData.Get();
                    var r = new Random();
                    Thread.Sleep(r.Next(2000, 5000));
                    var res = $"{tResult[0]} + {tResult[1]} + {tResult[2]} = {tResult.Sum()}";//создаем строку с суммой всех чисел массива
                    Console.WriteLine(res);//выводим результат на консоль
                }
            });
            t.IsBackground = true;
            t.Start();
        }
    }
}
