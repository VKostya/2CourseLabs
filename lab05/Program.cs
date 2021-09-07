using System;
using System.Collections.Generic;

namespace lab05
{
    class Node
    {
        public char value;
        public Node Right;
        public Node Left;
    }

    class Tree
    {
        public Node Root;
        public void direct(Node node)
        {
            Console.WriteLine(node.value);
            if (node.Left != null) direct(node.Left);
            if (node.Right != null) direct(node.Right);
        }

        public void Reverse(Node node)
        {
            if (node.Left != null) Reverse(node.Left);
            Console.WriteLine(node.value);
            if (node.Right != null) Reverse(node.Right);
        }

        public void Terminal(Node node)
        {
            if (node.Left != null) Terminal(node.Left);
            if (node.Right != null) Terminal(node.Right);
            Console.WriteLine(node.value);
        }

        public void TerminalParse(Node node, List<string> List)
        {
            if (node.Left != null) TerminalParse(node.Left, List);
            if (node.Right != null) TerminalParse(node.Right, List);
            List.Add(node.value.ToString());
        }
        public double Solve()
        {
            List<string> symbols = new List<string>() { "*", "/", "+", "-" };
            List<string> buff = new List<string>();
            TerminalParse(Root, buff);
            int i = 0;
            while(buff.Count != 1)
            {
                if (symbols.Contains(buff[i])) 
                {
                    double result = 0;
                    switch (buff[i])
                    {
                        case "+":
                            result = double.Parse(buff[i - 2]) + double.Parse(buff[i - 1]);
                            break;
                        case "-":
                            result = double.Parse(buff[i - 2]) - double.Parse(buff[i - 1]);
                            break;
                        case "*":
                            result = double.Parse(buff[i - 2]) * double.Parse(buff[i - 1]);
                            break;
                        case "/":
                            result = double.Parse(buff[i - 2]) / double.Parse(buff[i - 1]);
                            break;
                    }
                    buff[i] = result.ToString();
                    buff.RemoveAt(i - 2);
                    i--;
                    buff.RemoveAt(i - 1);
                    i--;
                    
                }
                i++;
            }

            return double.Parse(buff[0]);
        }
            
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region firstTask

            Node D = new Node() { value = 'd' };
            Node E = new Node() { value = 'e' };
            Node F = new Node() { value = 'f' };
            Node B = new Node() { value = 'b', Right = E, Left = D };
            Node C = new Node() { value = 'c', Right = F };
            Node A = new Node() { value = 'a', Right = C, Left = B };
            Tree tree = new Tree() { Root = A };
            tree.direct(tree.Root);
            Console.WriteLine();
            tree.Reverse(tree.Root);
            Console.WriteLine();
            tree.Terminal(tree.Root);
            Console.WriteLine();

            #endregion

            #region secondTask

            Node a = new Node() { value = '2'};
            Node b = new Node() { value = '3'};
            Node c = new Node() { value = '7'};
            Node d = new Node() { value = '4'};
            Node e = new Node() { value = '3'};
            Node f = new Node() { value = '+', Left = a, Right = b};
            Node g = new Node() { value = '-', Left = c, Right = d};
            Node h = new Node() { value = '*', Left = f, Right = g};
            Node i = new Node() { value = '/', Left = h, Right = e};

            Tree equation = new Tree() { Root = i };
            Console.WriteLine(equation.Solve());

            #endregion
        }

    }
}
