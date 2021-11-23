using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchInTree
{

    public class Node 
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node()
            {
                Data = 1,
                Left = new Node()
                {
                    Data = 2,
                    Left = new Node()
                    {
                        Data = 4,
                        Left = new Node()
                        {
                            Data = 8
                        }
                    },
                    Right = new Node()
                    {
                        Data = 5
                    }
                },
                Right = new Node()
                {
                    Data = 3,
                    Left = new Node()
                    {
                        Data = 6,
                        Left = new Node()
                        {
                            Data = 9
                        }
                    },
                    Right = new Node()
                    {
                        Data = 7
                    }
                }
            };
            Console.WriteLine("Enter number for search");
            int number = Int32.Parse(Console.ReadLine());
            
            BFS(node, number);
            DFS(node, number);
        }


        static void BFS(Node node, int number)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);//Положить корень дерева в очередь.

            while (queue.Any())  //Пока очередь не пуста.
            {
                var currentNode = queue.Dequeue(); //Вынуть из очереди элемент.
                Console.WriteLine(currentNode.Data);
                if (currentNode.Data == number)
                {
                    break; //Если элемент искомый, вернуть его и завершить работу алгоритма.
                }

                //Положить все дочерние узлы элемента в очередь.
                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);

                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);
            }
        }

        static void DFS(Node node, int number)
        {

            Stack<Node> stack = new Stack<Node>();
            stack.Push(node); //Положить корень дерева в стек.


            while (stack.Any())  //Пока стэк не пуст.
            {
                var currentNode = stack.Pop(); //Вынуть из стека элемент.
                Console.WriteLine(currentNode.Data);
                if (currentNode.Data == number)
                {
                    break; //Если элемент искомый, вернуть его и завершить работу алгоритма.
                }

                //Положить все дочерние узлы элемента в стек.
                if (currentNode.Left != null)
                    stack.Push(currentNode.Left);

                if (currentNode.Right != null)
                    stack.Push(currentNode.Right);
            }
           
        }

    }
}
