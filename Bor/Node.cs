using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bor
{
    class Node
    {
        public char key; // часть ключа
        public List<Node> nodes = new List<Node>(); // список потомков
        public object value = null; // значение, если нет то null

        public Node(char key)
        {
            this.key = key;
        }

        public Node(char key, Node node)
        {
            this.key = key;
            this.nodes.Add(node);
        }

        public Node(char key, Node node, object value)
        {
            this.key = key;
            this.nodes.Add(node);
            this.value = value;
        }
    }
}
