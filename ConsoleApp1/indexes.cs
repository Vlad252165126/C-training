using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public  class indexes
    {
        public void start()
        {
            bool _insertMode = true;
            Stock _stock;
            _stock = new Stock();

            while (_insertMode)
            {
                try
                {
                    Console.Write("Введите название товара:");
                    var name = Console.ReadLine();
                    Console.Write("Введите название магазина:");
                    var storeName = Console.ReadLine();
                    Console.Write("Введите стоимость товара:");
                    var price = decimal.Parse(Console.ReadLine());

                    var good = new Good(name, storeName, price);
                    _stock.AddGood(good);
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка ввода");
                }


                var answer = new ConsoleKeyInfo();
                while (answer.Key != ConsoleKey.Y)
                {
                    if (answer.Key == ConsoleKey.N)
                    {
                        _insertMode = false;
                        break;
                    }

                    Console.Write("Добавить еще один товар? (y - да, n - нет):");
                    answer = Console.ReadKey();
                    Console.WriteLine();
                }
            }

            Console.Write("Введите название товара для поиска:");
            var findName = Console.ReadLine();

            var foundGood = _stock[findName];
            Console.WriteLine(foundGood == null ? "Такого товара нет" : $"{foundGood.Name}, {foundGood.Price}, {foundGood.StoreName}");

            Console.ReadLine();
        }
    }
    public class Good
    {
        private string _name;
        private string _storeName;
        private decimal _price;

        public string Name => _name;

        public string StoreName => _storeName;

        public decimal Price => _price;

        public Good(string name, string storeName, decimal price)
        {
            _name = name;
            _storeName = storeName;
            _price = price;
        }
    }
    public class Stock
    {
        private List<Good> _goods;

        public Good this[int index] => _goods[index];

        public Good this[string name] => _goods.FirstOrDefault(g => g.Name.Equals(name));

        public Stock()
        {
            _goods = new List<Good>();
        }

        public void AddGood(Good good)
        {
            _goods.Add(good);
        }

        public void SortByPrice()
        {
            _goods = _goods.OrderBy(g => g.Price).ToList();
        }

        public void SortByName()
        {
            _goods = _goods.OrderBy(g => g.Name).ToList();
        }

        public void SortByStoreName()
        {
            _goods = _goods.OrderBy(g => g.StoreName).ToList();
        }

       
    }
    }
  

    



