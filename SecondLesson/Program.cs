using System;

namespace SecondLesson1
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class LinkedList : ILinkedList
    {
        Node head; // первый элемент
        Node tail; // последний элемент
        int count;  // количество элементов в списке


        public void AddNode(int value)
        {
            var node = new Node { Value = value };

            if (head == null)
                head = node;
            else
            {
                tail.NextNode = node;
                node.PrevNode = tail;
            }
            tail = node;
            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { Value = value };
            var nextInCurrentNode = node.NextNode;
            node.NextNode = newNode;
            nextInCurrentNode.PrevNode = newNode;
            newNode.NextNode = nextInCurrentNode;
            newNode.PrevNode = node;

        }

        public Node FindNode(int searchValue)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                    return currentNode;
                currentNode = currentNode.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            return count;
        }

        public void RemoveNode(int index)
        {
            if (index == 0)
            {
                var newStartNode = head.NextNode;
                head = newStartNode;
                head.NextNode = null;
            }

            int currentIndex = 0;
            var currentNode = head;
            while (currentNode != null)
            {
                if (currentIndex == index - 1)
                {
                    var nextNode = currentNode.NextNode.NextNode;
                    var prevNode = currentNode.NextNode.PrevNode;
                    currentNode.NextNode = nextNode;
                    currentNode.NextNode.PrevNode = prevNode;
                }

                currentNode = currentNode.NextNode;
                currentIndex++;
            }
        }

        public void RemoveNode(Node node)
        {
            var prevNode = node.PrevNode;
            var nextNode = node.NextNode;
            if (prevNode == null)
            {
                node.NextNode.PrevNode = null;
                head = node.NextNode;
            }
            else if (nextNode == null)
            {
                node.PrevNode.NextNode = null;
                tail = node.PrevNode;
            }
            else
            {
                node.PrevNode.NextNode = nextNode;
                node.NextNode.PrevNode = prevNode;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            // Код для проверки реализации интерфейса. Проверяла в дебаге с точкой останова в конце.

            var node = new LinkedList();
            node.AddNode(1);
            node.AddNode(2);
            node.AddNode(4);
            node.AddNodeAfter(node.FindNode(2), 3);
            node.AddNode(5);
            node.AddNode(6);
            var count = node.GetCount();
            node.RemoveNode(3);
            node.AddNode(7);
            node.AddNode(8);
            node.RemoveNode(node.FindNode(1));
            node.RemoveNode(node.FindNode(8));
            node.AddNode(10);
            node.AddNode(11);
            node.AddNode(12);
            node.RemoveNode(node.FindNode(11));
            
        }
    }
}
