
using System;
using System.Collections.Generic;

namespace GraphsTraversal
{

    public class Node //Вершина
    {
        public string Name { get; set; }
        public List<Edge> Edges { get; set; } 
        public Node(string name)
        {
            Name = name;
            Edges = new List<Edge>();
        }
        public void AddEdge(Edge newEdge)
        {
            Edges.Add(newEdge);
        }
        public void AddEdge(Node vertex, int weight)
        {
            AddEdge(new Edge(vertex, weight));
        }

        public override string ToString() => Name;

    }

    public class Edge //Ребро
    {
        public int Weight { get; set; } 
        public Node Node { get; set; } 
        public Edge (Node node, int weight)
        {
            Node = node;
            Weight = weight;
        }
        
    
}

    public class Graph
    {
        public List<Node> Vertices { get; }

        public Graph()
        {
            Vertices = new List<Node>();
        }

        public void AddVertex(string vertexName)
        {
            Vertices.Add(new Node(vertexName));
        }

        public Node FindVertex(string vertexName)
        {
            foreach (var v in Vertices)
            {
                if (v.Name.Equals(vertexName))
                {
                    return v;
                }
            }

            return null;
        }

        public void AddEdge(string firstVertexName, string secondVertexName, int weight)
        {
            var v1 = FindVertex(firstVertexName);
            var v2 = FindVertex(secondVertexName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
                v2.AddEdge(v1, weight);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            //добавление вершин
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");

            //добавление ребер
            graph.AddEdge("A", "B", 3);
            graph.AddEdge("A", "C", 2);
            graph.AddEdge("B", "C", 9);
            graph.AddEdge("B", "D", 10);
            graph.AddEdge("C", "D", 8);
            graph.AddEdge("C", "E", 5);
            graph.AddEdge("D", "E", 3);
            graph.AddEdge("D", "F", 1);
            graph.AddEdge("E", "F", 3);


            
            Console.WriteLine("Enter Any graph Vertex (A, B, C, D, E, F)");
            var value = Console.ReadLine();

            BFS(graph, value);
            DFS(graph, value);
        }


        static void BFS(Graph graph, string value)
        {
            Queue<Node> queue = new Queue<Node>();
            List<Node> arr = new List<Node>();

            queue.Enqueue(graph.Vertices[0]);

            while (queue.Count > 0)  //Пока очередь не пуста.
            {
                var currentNode = queue.Dequeue(); //Вынуть из очереди элемент.
                arr.Add(currentNode);

                Console.WriteLine(currentNode.Name);
                if (currentNode.Name == value)
                {
                    Console.WriteLine("^ This is searched Vertex" + "\n");
                    break; //Если элемент искомый, вернуть его и завершить работу алгоритма.
                }
                //Положить все дочерние узлы элемента в очередь.
                foreach (var item in currentNode.Edges)
                {
                    if (!arr.Exists(x => x.Equals(item.Node)) && !queue.Contains(item.Node)) { queue.Enqueue(item.Node); }
              
                } 
            }
        }

        static void DFS(Graph graph, string value)
        {
            Stack<Node> stack = new Stack<Node>();
            List<Node> arr = new List<Node>();

            stack.Push(graph.Vertices[0]);
            while (stack.Count > 0)  //Пока очередь не пуста.
            {
                var currentNode = stack.Pop(); //Вынуть из очереди элемент.
                arr.Add(currentNode);

                Console.WriteLine(currentNode.Name);
                if (currentNode.Name == value)
                {
                    Console.WriteLine("^ This is searched Vertex" + "\n");
                    break; //Если элемент искомый, вернуть его и завершить работу алгоритма.
                }
                //Положить все дочерние узлы элемента в очередь.
                foreach (var item in currentNode.Edges)
                {
                    if (!arr.Exists(x => x.Equals(item.Node)) && !stack.Contains(item.Node)) { stack.Push(item.Node); }

                }
            }
        }

    }
}
