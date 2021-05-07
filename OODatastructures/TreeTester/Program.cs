using System;

namespace TreeTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World, here comes a nice Binary sorted tree !");

            //Demo code to use the BinaryTreePrinter class to show a BST in the Console window

            //Create a test tree with some nodes
            NodeInt root = new NodeInt(10);
            root.Left = new NodeInt(8);
            root.Right = new NodeInt(25);
            root.Left.Left = new NodeInt(3);
            root.Left.Right = new NodeInt(9); 
            root.Right.Left = new NodeInt(22);
            root.Right.Right = new NodeInt(27);
            //.....

            //Just call the 'Print' method on the root node of your tree and the whole tree will magically show in the console !
            //Extra info.
            //** Name your own Node class also 'NodeInt' (or use my NodeInt class)
            //** Make sure that it has the properties : Left, Right and Value
            //** You do not have to add the Print() method on your Node class. This is automatically done for you by the BinaryTreePrinter class
            root.Print();
        }
    }
}
