using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Matrix
    {
        // передача нового экземпляра передача палочки в истофете многопоточна
        static readonly object locker = new object();
        // рандом чисел
        Random rand;
        //случайно подпираться будут числа для рандома
        const string litters = "ABCDEFGHIJKLMNOPRSTUV123456789";
        //св-во которое бдует хранит текующую колонку в которой падает цепочка
        public int Column { get; set; }
        // конструктор который будет инициализировать эту колонку
        // где будет находится конкретная цепочка символов
        public Matrix(int col)
        {
            Column = col;
            //Tick поможет сформировать случайное зерно для генерации случайных чисел
            rand = new Random((int)DateTime.Now.Ticks);
        }
        private char GetChar()
        {
            //Выбираем от 0 до 30 символов в litters
            return litters.ToCharArray()[rand.Next(0, 30)];
        }
        public void Move()
        {
            int leght;
            int count;
            while (true)
            {
                // leght = текущий размер цепочки
                //count = макс длина цепочки
                leght = 0;
                count = rand.Next(3, 6);
                Thread.Sleep(rand.Next(20, 1000));
                //for будет считать 40 пунктов вниз где конце строки
                for(int i = 0; i < 40; i++)
                {
                    // объект синхронизации где будет выполнять 1 поток
                    lock (locker)
                    {
                        Console.CursorTop = 0;
                        Console.ForegroundColor = ConsoleColor.Black;
                        //затираем все изображение в котором есть в
                        //этом столбике для прорисовки в будущем
                        for (int j = 0; j < i; j++)
                        {
                            Console.CursorLeft = Column;
                            Console.WriteLine("■");  ///----------/////
                        }
                        // если тек. длина меньше чем макс. длина, тогда увеличиваем тек. длину.
                        if (leght < count) leght++;
                        // Если тек. длина равна макс. длине тогда сбрасиваем макс. длину
                        else if (leght == count) count = 0;
                        // Если мы достигли конца экрана тогда мы тек длину начинаем отнимать на 1 чтобы уменьшалась и остался 1 символ
                        if (39 - i < leght) leght--;
                        // Мы устанавливаем положение курсора в хвост цепочки (i - leght + 1) + прорисоваем хвост цепочки до последних -2 символов(j < leght-2)
                        Console.CursorTop = i - leght + 1;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        for (int j = 0; j < leght-2; j++)
                        {
                            //возвращаем курсор в текущую колонку и гетчар будет возвращать случайный символ
                            Console.CursorLeft = Column;
                            Console.WriteLine(GetChar());
                        }
                        if (leght >= 2)
                        {
                            //если мы находимся > или = на 2 символе тогда рисуем все зеленым возвращаем в тек. колонку и получаем текущий символ
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.CursorLeft = Column;
                            Console.WriteLine(GetChar());
                        }
                        if (leght >= 1)
                        {
                            //если длина символа осталась в конце 1 символом тогда рисуем белым
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.CursorLeft = Column;
                            Console.WriteLine(GetChar());
                        }
                        Thread.Sleep(20);
                    }
              //---------------------------------------------------------------------------------------------------------//
                    // ДЛЯ ЗАПУСКА MAIN
                    // устан. размер окна. Создаем ссылку на экземпляр матрицы
                    // и в цикле постепенно создаем экземпляр матрицы и в каждой колоднке
                    //Console.SetWindowSize(80, 40);
                    //Matrix instance;
                    //for (int i = 0; i < 40; i++)
                    //{
                    //    instance = new Matrix(i * 2);
                    //    new Thread(instance.Move).Start();
                    //}
              //---------------------------------------------------------------------------------------------------------//
                }
            }
        }

    }
}
