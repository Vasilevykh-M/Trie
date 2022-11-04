using System;

namespace Bor
{
    class Program
    {

        static int userChoise()
        {
            int select;
            Console.WriteLine("Выберите что хотите сделать:");
            Console.WriteLine("     1) Создать эллемент");
            Console.WriteLine("     2) Удалить эллемент");
            Console.WriteLine("     3) Вывести эллемент");
            Console.WriteLine("     4) Распечатать дерево");
            Console.WriteLine("     5) Выйти");
            select = Convert.ToInt32(Console.ReadLine());
            return select;
        }
        static void Main(string[] args)
        {
            Trie tr = new Trie();
            int select;
            bool flag = true;
            string key;
            int value;
            while (flag == true) {
                select = userChoise();
                switch (select)
                {
                    case 1:
                        Console.WriteLine("По какому ключу");
                        key = Console.ReadLine();

                        Console.WriteLine("Какое значение записать");
                        value  = Convert.ToInt32(Console.ReadLine());
                        tr.add(key, value);

                        break;

                    case 2:
                        Console.WriteLine("По какому ключу");
                        key = Console.ReadLine();
                        tr.delete(key);
                        break;

                    case 3:
                        Console.WriteLine("По какому ключу");
                        key = Console.ReadLine();
                        tr.find(key);
                        break;

                    case 4:
                        tr.printTree(tr.root);
                        break;
                    case 5:
                        flag = false;
                        break;
                }
            }
        }
    }
}
