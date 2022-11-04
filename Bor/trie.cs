using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bor
{
    class Trie
    {
        public Node root = new Node('\''); // корень дерева


        public Tuple<Node, bool, string> findNode(string key)
        {
            Node curNode = this.root; // текущий узел
            bool find_flag = false; // флаг на то была ли найдена часть кдюча в текущем узле

            while (key.Length != 0) // пока не перебрали все символы ключа
            {
                find_flag = false;
                foreach (Node node in curNode.nodes) // смотрим всех потомков текущего узла
                {
                    if (node.key == key[0]) // если их символ совпадает с ключом
                    {
                        curNode = node; // делаем его текущим
                        find_flag = true; // и сообщаем о том что мы успешного его обнаружили
                    }
                }
                if (find_flag == false) // если ключ и не был обнаружен то прерывает обход
                    break;
                key = key.Substring(1, key.Length - 1);
            }

            if (find_flag == true && curNode.value != null) // если мы нашли ключ вернем его
                return new Tuple<Node, bool, string>(curNode, true, key);

            if (find_flag == false && key.Length > 0 || find_flag == true && curNode.value == null) // ключ не нашли но нашли место где окначивается его часть
                return new Tuple<Node, bool, string>(curNode, false, key);

            // нет даже подключа
            return new Tuple<Node, bool, string>(null, false, key);
        }


        // поиск обьекта по ключу
        public void find(string key)
        {
            Node node;
            bool flag;
            Tuple<Node, bool, string> result = findNode(key);
            node = result.Item1;
            flag = result.Item2;

            if (flag == false)
            {
                Console.WriteLine("Key not found");
                return;
            }

            Console.WriteLine(String.Format("Key: {0}     Value: {1}", key, node.value.ToString()));
        }
        // добавление ключа
        public void add(string key, object value = null)
        {
            Node node;
            bool flag;
            string key_;
            Tuple<Node, bool, string> result = findNode(key);
            node = result.Item1;
            flag = result.Item2;
            key_ = result.Item3;

            if(flag == true)
                return;

            Node curNode = this.root;

            if (node != null)
                curNode = node;

            while(key_.Length != 0)
            {
                Node newNode = new Node(key_[0]);
                curNode.nodes.Add(newNode);
                curNode = newNode;
                key_ = key_.Substring(1, key_.Length - 1);
            }

            curNode.value = value;

        }

        //удаление ключа
        public bool delete(string key)
        {
            Node node;
            bool flag;
            string key_;
            Tuple<Node, bool, string> result = findNode(key);
            node = result.Item1;
            flag = result.Item2;
            key_ = result.Item3;

            if (flag == true)
            {
                node.value = null;
                return true;
            }
            return false;
        }

        //вывод всего дерева
        public void printTree(Node root, int depth = 0)
        {
            string tab = "";
            for (int i=0;i<depth;i++)
            {
                tab += '\t';
            }

            foreach(Node node in root.nodes)
            {
                string value = "";
                if (node.value != null)
                {
                    value = Convert.ToString(node.value);
                }
                Console.WriteLine(tab + node.key +": " + value);
                printTree(node, depth + 1);
            }
        }
    }
}
