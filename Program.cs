//Сегодня рассмтариваем паттерн "производитель - поставщик"
// Это значит, что из нескольких потоков  (producers) мы получим 
//по итогу какой-то общий результат в "поставщике" (consumer)

using _16._02._2023_lecture;
Consumer consumer = new Consumer();//создали получателя

Producer p1 = new Producer(0);//создаем продюсеров
Producer p2 = new Producer(1);
Producer p3 = new Producer(2);

consumer.Start();

p1.Start();
p2.Start();
p3.Start();

Console.ReadKey();// предотвращаем ситуацию, что перодюсеры спят все время работы программы