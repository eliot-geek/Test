using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Product
        /// </summary>
        class Product
        {
            // Полей
            /// <summary>
            /// Field Price
            /// </summary>
            private int price;
            /// <summary>
            /// Field name
            /// </summary>
            private string name;
            /// <summary>
            /// Field Count
            /// </summary>
            private int count;

            /// <summary>
            /// Property Price
            /// </summary>
            public int Price { get { return price; } set { price = value; } } // Свойства
            /// <summary>
            /// Property Name
            /// </summary>
            public string Name { get { return name; } set { name = value; } }
            /// <summary>
            /// Property Count
            /// </summary>
            public int Count { get { return count; } set { count = value; } }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="name"></param>
            /// <param name="price"></param>
            /// <param name="count"></param>
            public Product(string name, int price, int count)  // Конструтор
            {
                this.price = price;
                this.name = name;
                this.count = count;
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="name"></param>
            /// <param name="price"></param>
            public Product(string name, int price)
            {
                this.price = price;
                this.name = name;
                this.count = 1;
            }

            /// <summary>
            /// Display
            /// </summary>
            public void Print()
            {
                Console.WriteLine("\nТовар: " + name + ", цена за шт.: " + price.ToString() + ", количество: " + count.ToString()); // формат показа в консоль
            }

            public static explicit operator Product(int v)
            {
                throw new NotImplementedException();
            }
        }
        
        /// <summary>
        /// Order Class
        /// </summary>
        class Order
        {
            public List<Product> products;

            /// <summary>
            /// Show information (price)
            /// </summary>
            public void printInfo()
            {
                int fullprice = 0;
                for (int i = 0; i < products.Count; i++)
                {
                    products[i].Print(); // показать товар
                    fullprice = products[i].Count * products[i].Price; // рассчитать полную цену (количество * цена)
                    Console.WriteLine("Полная цена: " + fullprice.ToString()); // показать полную цену на консоли
                }
            }
            /// <summary>
            /// Find minimum
            /// </summary>
            /// <returns></returns>
            public Product findMinProduct()
            {
                Product res = products.OrderBy(p => p.Price).FirstOrDefault(); // linq чтобы найти минимальный
                return (res); // вернуть результат
            }
            /// <summary>
            /// Find maximum
            /// </summary>
            /// <returns></returns>
            public Product findMaxProduct()
            {
                Product res = products.OrderBy(p => p.Price).LastOrDefault(); // linq чтобы найти максимальный
                return (res); // вернуть результат
            }
        }

        static void Main(string[] args)
        {
            Order order = new Order(); // создание объекта
            order.products = new List<Product>();
            
            int n;
            Console.Write("Введите количество товаров : ");
            n = Int32.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string name; // name
                int price; // price
                int count; // count
                Console.WriteLine("Введите название товара");
                name = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                price = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите количество товара");
                count = Int32.Parse(Console.ReadLine());

                order.products.Add(new Product(name, price, count)); // добавить каждый продукт
            }

            order.printInfo();
            Console.WriteLine("\nСамый дорогой заказ по стоимости: " + order.findMaxProduct().Name); // максимальный
            Console.WriteLine("Самый дешевый заказ по стоимости: " + order.findMinProduct().Name); // минимальный
            Console.ReadKey();
        }
    }
}