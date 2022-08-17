using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class train3_7_2
    {
        struct train
        {
            public string punkt;
            public int number;
            public DateTime date;

            public train(string punkt, int number, DateTime date)
            {
                this.punkt = punkt;
                this.number = number;
                this.date = date;
            }

            public static void addtoarray(train[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine("Введите название пункта назначения:  ");
                    string destination = Console.ReadLine();
                    destination = String.IsNullOrEmpty(destination) ? "Не выбран пункт назначения" : destination;

                    Console.WriteLine("Введите номер поезда: ");
                    string number = Console.ReadLine();
                    number = String.IsNullOrEmpty(number) ? "Не выбран номер поезда" : number;

                    Console.WriteLine("Введите дату: ");
                    string departure = Console.ReadLine();
                    DateTime time = String.IsNullOrEmpty(departure) ? DateTime.Now : DateTime.Parse(departure);

                    array[i] = new train(destination, Int32.Parse(number), time);

                }
            }
            public static void Show(train[] train)
            {

                for (int i = 0; i < train.Length; i++)
                {
                    Console.WriteLine("пункт отправления: {0}, номер поезда:  {1}, дата отправления{2}", train[i].punkt, train[i].number, train[i].date);
                }
            }
            public static void Search(train[] train)
            {
                Console.WriteLine("Поиск пункта назначения");
                string punkt = Console.ReadLine();
                bool check = true;
                for (int i = 0; i < train.Length; i++)
                {
                    while (check == true)
                    {
                        if (train[i].punkt == punkt)
                        {
                            Console.WriteLine("пункт отправления: {0}, номер поезда:  {1}, дата отправления{2}", train[i].punkt, train[i].number, train[i].date);
                            check = false;
                        }
                    }
                }
            }
        }
        public static void start()
        {
            train[] array = new train[1];
            train.addtoarray(array);
            train.Show(array);
            train.Search(array);
        }
    }
}
