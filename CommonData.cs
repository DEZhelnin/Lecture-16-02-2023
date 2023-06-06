using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._02._2023_lecture
{
    public static class CommonData //это класс общих данных, хранилище 
    { //static чтобы CommonData был единственным и общим для всех

        //Пусть у нас 3 продюсера => создадим массив на 3 эл-та
        private static int _maxQueueLength = 2;
        private static Queue<int>[] tResult = { new(), new(), new() }; //очереди для результатов каждого продюсера
        private static object locker = new();
        public static  void Put(int index, int value) //метод для записи числа в какой-то поток 
       
        {
            if (index >= 0 && index < tResult.Length)
            {
                lock (locker)
                {
                    while (tResult[index].Count >= _maxQueueLength)
                    {
                        Console.WriteLine($"Producer{index}: место занято, значение еще не получено");
                        Monitor.Wait(locker);
                    }
                    Console.WriteLine($"Producer{index}: добавление результата {value}");

                    tResult[index].Enqueue(value);
                    Monitor.PulseAll(locker);//будим все спящие потоки (в нащем случае Consumer)
                                             //чтобы проверить, что все изменились в массиве
                }
            }
        }

        public static int[] Get()//метод для получения 
        {
            lock (locker){// используем для синхронизации потоков (другие потоки не смогут войти, пока не вернется значение)
                
                //var isAllSet = tResult.All(value => value != -1);//предикат, с помощью которого
                                                                 //проверяем, что все эл-ты != -1
                while (!tResult.All(value => value.Count>0))
                {
                    Console.WriteLine("Consumer: данные еще не готовы");
                    Monitor.Wait(locker);//ждем , пока все вернут значение
                    //wait снимает блокировку на время, когда поток спит
                    
                }
                Console.WriteLine("Consumer: данные  готовы");
                var res = new[] { tResult[0].Dequeue(), tResult[1].Dequeue(), tResult[2].Dequeue() };//возращаем клон массива
                Monitor.PulseAll(locker);
                return res;
            } 
        }
   }
}
