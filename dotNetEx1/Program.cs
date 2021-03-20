using System;

namespace dotNetEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 44, 55, 12, 42, 94, 18, 6, 67};
            Console.WriteLine("Hello World!");
            LinkedList<string> fruits = new LinkedList<string>();
            fruits.Add("apple");
            fruits.Add("banana");
            fruits.Add("orange");
            fruits.reverse();
            BinaryTree<int> numbers = new BinaryTree<int>();
            numbers.Add(11);
            numbers.Add(2);
            numbers.Add(5);
            numbers.Add(15);    
            TreeNode<int> found = numbers.Search(2);
            numbers.Remove(11);
            foreach (var num in arr)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
            InclusionSort<int>.Descending(arr);
            foreach (var num in arr)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit);
            }
        }

    }
}
