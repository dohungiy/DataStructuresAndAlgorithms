using SharedKernel.BinaryTree;
using SharedKernel.LinkedList.SinglyLinkedList;
using SharedKernel.Logging;

namespace ConsoleApp;

class Program
{
    static void Main()
    {
        BinaryTree<int> binaryTree = new BinaryTree<int>();

        // Thêm các nút vào cây
        binaryTree.Insert(5);
        binaryTree.Insert(3);
        binaryTree.Insert(7);
        binaryTree.Insert(2);
        binaryTree.Insert(4);
        binaryTree.Insert(8);

        Console.WriteLine("Binary Tree:");
        binaryTree.InOrderTraversal(binaryTree.Root);
        Console.WriteLine();

        // Xóa nút có giá trị là 3
        binaryTree.Delete(3);

        Console.WriteLine("Binary Tree after deleting node with value 3:");
        binaryTree.InOrderTraversal(binaryTree.Root);
        Console.WriteLine();

        // Tìm nút có giá trị là 7
        int valueToSearch = 7;
        BinaryTreeNode<int>? nodeToSearch = binaryTree.Search(valueToSearch);

        if (nodeToSearch != null)
        {
            Console.WriteLine($"Node with value {valueToSearch} found in the tree.");
        }
        else
        {
            Console.WriteLine($"Node with value {valueToSearch} not found in the tree.");
        }

        // Thêm một nút mới có giá trị là 6
        binaryTree.Insert(6);

        Console.WriteLine("Binary Tree after inserting node with value 6:");
        binaryTree.InOrderTraversal(binaryTree.Root);
    }
}